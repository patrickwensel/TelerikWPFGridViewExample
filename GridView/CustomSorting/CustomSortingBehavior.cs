using System.Linq;
using System.Windows;
using System.ComponentModel;

namespace Telerik.Windows.Controls.GridView.CustomSorting
{
    public class CustomSortingBehavior
    {
        private RadGridView grid = null;

        public CustomSortingBehavior(RadGridView grid)
        {
            this.grid = grid;
        }

        public static readonly DependencyProperty IsEnabledProperty
            = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(CustomSortingBehavior),
                new PropertyMetadata(new PropertyChangedCallback(OnIsEnabledPropertyChanged)));

        public static void SetIsEnabled(DependencyObject dependencyObject, bool enabled)
        {
            dependencyObject.SetValue(IsEnabledProperty, enabled);
        }

        public static bool GetIsEnabled(DependencyObject dependencyObject)
        {
            return (bool) dependencyObject.GetValue(IsEnabledProperty);
        }

        private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            RadGridView grid = dependencyObject as RadGridView;
            if (grid != null)
            {
                if ((bool) e.NewValue)
                {
                    CustomSortingBehavior menu = new CustomSortingBehavior(grid);
                    menu.Attach();
                }
            }
        }

        private void Attach()
        {
            if (grid != null)
            {
                grid.Sorting += Sorting;
            }
        }

        private void Sorting(object sender, GridViewSortingEventArgs e)
        {
            if (e.Column.UniqueName == "CustomerID")
            {
                e.Cancel = true;

                ColumnSortDescriptor descriptor = (from d in grid.SortDescriptors.OfType<ColumnSortDescriptor>()
                                                   where object.Equals(d.Column, grid.Columns["CompanyName"])
                                                   select d).FirstOrDefault();

                if (descriptor == null)
                {
                    grid.SortDescriptors.Add(new ColumnSortDescriptor()
                    {
                        Column = grid.Columns["CompanyName"],
                        SortDirection = ListSortDirection.Ascending
                    });

                    e.Column.SortingState = SortingState.Ascending;
                }
                else
                {
                    descriptor.SortDirection = descriptor.SortDirection == ListSortDirection.Ascending ?
                        ListSortDirection.Descending : ListSortDirection.Ascending;

                    e.Column.SortingState = descriptor.SortDirection == ListSortDirection.Ascending ?
                        SortingState.Ascending : SortingState.Descending;
                }
            }
        }
    }
}
