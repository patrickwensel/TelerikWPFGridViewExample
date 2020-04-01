using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using System.Windows;

namespace Telerik.Windows.Examples.GridView.Hierarchy.SelfReference
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example
	{
        public Example()
        {
            InitializeComponent();
        }

        void RadGridView1_RowLoaded(object sender, RowLoadedEventArgs e)
        {
            GridViewRow row = e.Row as GridViewRow;
            Employee employee = e.DataElement as Employee;

            if (row != null && employee != null)
            {
                row.IsExpandable = this.HasSubordinates(employee);
            }
        }

        private bool HasSubordinates(Employee employee)
        {
            return
            (from emp in (IEnumerable<Employee>)this.RadGridView1.ItemsSource
             where emp.ReportsTo == employee.EmployeeID
             select emp).Any();
        }

        private void RadGridView1_DataLoading(object sender, GridViewDataLoadingEventArgs e)
        {
            GridViewDataControl dataControl = (GridViewDataControl) sender;
            if (dataControl.ParentRow != null)
            {
                dataControl.GridLinesVisibility = GridLinesVisibility.None;
                dataControl.ShowGroupPanel = false;
                dataControl.AutoGenerateColumns = false;
                dataControl.CanUserFreezeColumns = false;
                dataControl.IsReadOnly = true;
                dataControl.ChildTableDefinitions.Clear();


                GridViewDataColumn column = new GridViewDataColumn();
                column.DataMemberBinding = new Binding("EmployeeID");
                dataControl.Columns.Add(column);

                column = new GridViewDataColumn();
                column.DataMemberBinding = new Binding("FirstName");
                dataControl.Columns.Add(column);

                column = new GridViewDataColumn();
                column.DataMemberBinding = new Binding("LastName");
                dataControl.Columns.Add(column);

                column = new GridViewDataColumn();
                column.DataMemberBinding = new Binding("Title");
                dataControl.Columns.Add(column);
            }
        }
	}
}
