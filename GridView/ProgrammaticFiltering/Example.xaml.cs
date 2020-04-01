using Telerik.Windows.Controls.GridView;
using System;
using Telerik.Windows.Data;
namespace Telerik.Windows.Examples.GridView.ProgrammaticFiltering
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
        public Example()
        {
            InitializeComponent();

			this.radGridView.FilterDescriptors.SuspendNotifications();

			IColumnFilterDescriptor birthDateFilter = this.radGridView.Columns["CompanyName"].ColumnFilterDescriptor;
			birthDateFilter.SuspendNotifications();
			
			birthDateFilter.FieldFilter.Filter1.Operator = FilterOperator.Contains;
			birthDateFilter.FieldFilter.Filter1.Value = "Delikatessen";
			birthDateFilter.FieldFilter.Filter1.IsCaseSensitive = true;
			
			birthDateFilter.FieldFilter.LogicalOperator = FilterCompositionLogicalOperator.Or;
			
			birthDateFilter.FieldFilter.Filter2.Operator = FilterOperator.Contains;
			birthDateFilter.FieldFilter.Filter2.Value = "market";
			birthDateFilter.FieldFilter.Filter2.IsCaseSensitive = false;
			
			birthDateFilter.ResumeNotifications();

			IColumnFilterDescriptor countryFilter = this.radGridView.Columns["Country"].ColumnFilterDescriptor;
			countryFilter.SuspendNotifications();
			
			countryFilter.DistinctFilter.AddDistinctValue("USA");
			countryFilter.DistinctFilter.AddDistinctValue("Canada");
			countryFilter.DistinctFilter.AddDistinctValue("Germany");
			
			countryFilter.ResumeNotifications();

			this.radGridView.FilterDescriptors.ResumeNotifications();
        }

		private void OnDistinctValuesLoading(object sender, GridViewDistinctValuesLoadingEventArgs e)
		{
			// This will make the grid display absolutely all distinct values for 
			// each column regardless of what filters might exist on other columns.
			var filterDistinctValues = false;
			e.ItemsSource = this.radGridView.GetDistinctValues(e.Column, filterDistinctValues);
		}
    }
}
