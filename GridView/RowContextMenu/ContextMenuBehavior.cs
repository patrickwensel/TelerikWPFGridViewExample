using System;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.GridView.RowContextMenu
{
    public class ContextMenuBehavior
    {
        private readonly RadGridView gridView = null;
        private readonly FrameworkElement contextMenu = null;

        public static readonly DependencyProperty ContextmenuPropery =
        DependencyProperty.RegisterAttached("ContextMenu", typeof(FrameworkElement), typeof(ContextMenuBehavior),
            new PropertyMetadata(new PropertyChangedCallback(OnIsEnabledPropertyChanged)));

        public static void SetContextMenu(DependencyObject dependencyObject, FrameworkElement contextmenu)
        {
            dependencyObject.SetValue(ContextmenuPropery, contextmenu);
        }

        public static FrameworkElement GetContextMenu(DependencyObject dependencyObject)
        {
            return (FrameworkElement)dependencyObject.GetValue(ContextmenuPropery);
        }

        public static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            RadGridView grid = dependencyObject as RadGridView;
            FrameworkElement contextMenu = e.NewValue as FrameworkElement;

            if (grid != null && contextMenu != null)
            {
                ContextMenuBehavior behavior = new ContextMenuBehavior(grid, contextMenu);
            }
        }

        public ContextMenuBehavior(RadGridView grid, FrameworkElement contextMenu)
        {
            this.gridView = grid;
            this.contextMenu = contextMenu;

            (contextMenu as RadContextMenu).Opened += RadContextMenu_Opened;
            (contextMenu as RadContextMenu).ItemClick += RadContextMenu_ItemClick;
        }

        private void RadContextMenu_ItemClick(object sender, RadRoutedEventArgs e)
        {
            RadContextMenu menu = (RadContextMenu)sender;
            RadMenuItem clickedItem = e.OriginalSource as RadMenuItem;
            GridViewRow row = menu.GetClickedElement<GridViewRow>();
            GroupHeaderRow groupHeaderRow = menu.GetClickedElement<GroupHeaderRow>();

            if (clickedItem != null && row != null)
            {
                string header = Convert.ToString(clickedItem.Header);

                switch (header)
                {
                    case "Add":
                        gridView.BeginInsert();
                        break;
                    case "Edit":
                        gridView.BeginEdit();
                        break;
                    case "Delete":
                        gridView.Items.Remove(row.DataContext);
                        break;
                    default:
                        break;
                }
            }
            else if (clickedItem != null && groupHeaderRow != null)
            {
                string header = Convert.ToString(clickedItem.Header);

                switch (header)
                {
                    case "Delete":
                        var group = groupHeaderRow.DataContext as QueryableCollectionViewGroup;
                        var items = group.Items.ToList();
                        foreach (var item in items)
                        {
                            gridView.Items.Remove(item);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void RadContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            RadContextMenu menu = (RadContextMenu)sender;
            GridViewRow row = menu.GetClickedElement<GridViewRow>();
            GroupHeaderRow groupHeaderRow = menu.GetClickedElement<GroupHeaderRow>();
            

            if (row != null && !row.IsInEditMode)
            {
                menu.Items.Clear();

                RadMenuItem item = new RadMenuItem();
                item.Header = "Add";
                menu.Items.Add(item);

                item = new RadMenuItem();
                item.Header = "Edit";
                menu.Items.Add(item);

                item = new RadMenuItem();
                item.Header = "Delete";
                menu.Items.Add(item);

                row.IsSelected = row.IsCurrent = true;
                GridViewCell cell = menu.GetClickedElement<GridViewCell>();
                if (cell != null)
                {
                    cell.IsCurrent = true;
                }
            }
            else if (groupHeaderRow != null)
            {
                menu.Items.Clear();

                RadMenuItem item = new RadMenuItem();
                item.Header = "Delete";
                menu.Items.Add(item);
            }
            else
            {
                menu.IsOpen = false;
            }
        }
    }
}