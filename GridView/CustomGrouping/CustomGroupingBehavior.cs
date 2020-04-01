using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using Telerik.Windows.Data;
using Telerik.Windows.Examples;

namespace Telerik.Windows.Controls.GridView.CustomGrouping
{
    public class CustomGroupingBehavior
    {
        private readonly RadGridView grid = null;

        public CustomGroupingBehavior(RadGridView grid)
        {
            this.grid = grid;
        }

        public static readonly DependencyProperty IsEnabledProperty
            = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(CustomGroupingBehavior),
                new PropertyMetadata(new PropertyChangedCallback(OnIsEnabledPropertyChanged)));

        public static void SetIsEnabled(DependencyObject dependencyObject, bool enabled)
        {
            dependencyObject.SetValue(IsEnabledProperty, enabled);
        }

        public static bool GetIsEnabled(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(IsEnabledProperty);
        }

        private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var grid = dependencyObject as RadGridView;
            if (grid != null)
            {
                if ((bool)e.NewValue)
                {
                    var behavior = new CustomGroupingBehavior(grid);
                    behavior.Attach();
                }
            }
        }

        private void Attach()
        {
            if (grid != null)
            {
                grid.Grouping += Grouping;

                AddCustomGroupDescriptors();
            }
        }

        private void AddCustomGroupDescriptors()
        {
            grid.GroupDescriptors.Add(new GroupDescriptor<MyBusinessObject, int, int>()
            {
                GroupingExpression = i => i.Date.Year,
                DisplayContent = "Year",
                SortDirection = ListSortDirection.Ascending
            });

            grid.GroupDescriptors.Add(new GroupDescriptor<MyBusinessObject, string, int>()
            {
                GroupingExpression = i => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i.Date.Month),
                GroupSortingExpression = grouping => DateTime.ParseExact(grouping.Key, "MMMM", CultureInfo.CurrentCulture).Month,
                DisplayContent = "Month",
                SortDirection = ListSortDirection.Ascending,
            });
        }

        private void Grouping(object sender, GridViewGroupingEventArgs e)
        {
            if (e.Action == GroupingEventAction.Place)
            {
                var cgd = e.GroupDescriptor as ColumnGroupDescriptor;

                if (cgd != null && cgd.Column.UniqueName == "Date")
                {
                    e.Cancel = true;

                    if (grid.GroupDescriptors.OfType<GroupDescriptorBase>().Where(d => d.DisplayContent == "Year" || d.DisplayContent == "Month").Any())
                    {
                        return;
                    }

                    AddCustomGroupDescriptors();
                }
            }
            else if (e.Action == GroupingEventAction.Remove)
            {
                var gd = e.GroupDescriptor as GroupDescriptorBase;
                GroupDescriptorBase gdToRemove = null;

                if (gd != null)
                {
                    if (gd.DisplayContent == "Year")
                    {
                        gdToRemove = grid.GroupDescriptors.OfType<GroupDescriptorBase>().Where(d => d.DisplayContent == "Month").FirstOrDefault();
                    }
                    else if (gd.DisplayContent == "Month")
                    {
                        gdToRemove = grid.GroupDescriptors.OfType<GroupDescriptorBase>().Where(d => d.DisplayContent == "Year").FirstOrDefault();
                    }
                }

                if (gdToRemove != null)
                {
                    grid.GroupDescriptors.Remove(gdToRemove);
                }
            }
        }
    }
}
