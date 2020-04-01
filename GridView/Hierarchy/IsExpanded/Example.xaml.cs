using System;
using Telerik.Windows.Controls.GridView;

namespace Telerik.Windows.Examples.GridView.Hierarchy.IsExpanded
{
    public partial class Example : System.Windows.Controls.UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void OnRadGridViewDataLoading(object sender, Controls.GridView.GridViewDataLoadingEventArgs e)
        {
            var dataControl = (GridViewDataControl)sender;
            if (dataControl.ParentRow != null)
            {

                dataControl.RowIndicatorVisibility = System.Windows.Visibility.Hidden;
                dataControl.GridLinesVisibility = GridLinesVisibility.None;
                dataControl.ShowGroupPanel = false;
                dataControl.CanUserFreezeColumns = false;
                dataControl.IsReadOnly = true;
            }
        }
    }
}