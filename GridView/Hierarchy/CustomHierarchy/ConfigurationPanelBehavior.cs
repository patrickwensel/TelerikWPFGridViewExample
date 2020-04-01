using System;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.GridView.Hierarchy.CustomHierarchy
{
    public class ConfigurationPanelBehavior : ViewModelBase
    {
        private readonly RadGridView gridView = null;
        private readonly FrameworkElement controlPanel = null;
        private RemoveChildTableDefinitonsCommand _removeChildTableDefinitionsCommand;
        private RestoreChildTableDefinitonsCommand _restoreChildTableDefinitionsCommand;

        public static readonly DependencyProperty ConrolPanelProperty =
        DependencyProperty.RegisterAttached("ControlPanel", typeof(FrameworkElement), typeof(ConfigurationPanelBehavior),
            new PropertyMetadata(new PropertyChangedCallback(OnControlPanelPropertyChanged)));

        public RemoveChildTableDefinitonsCommand RemoveChildTableDefinitionsCommand
        {
            get
            {
                return this._removeChildTableDefinitionsCommand;
            }
            set
            {
                this._removeChildTableDefinitionsCommand = value;
            }
        }

        public RestoreChildTableDefinitonsCommand RestoreChildTableDefinitionsCommand
        {
            get
            {
                return this._restoreChildTableDefinitionsCommand;
            }
            set
            {
                this._restoreChildTableDefinitionsCommand = value;
            }
        }

        public static void SetControlPanel(DependencyObject dependencyObject, FrameworkElement panel)
        {
            dependencyObject.SetValue(ConrolPanelProperty, panel);
        }

        public static FrameworkElement GetControlPanel(DependencyObject dependencyObject)
        {
            return (FrameworkElement)dependencyObject.GetValue(ConrolPanelProperty);
        }

        public static void OnControlPanelPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            RadGridView grid = dependencyObject as RadGridView;
            FrameworkElement panel = e.NewValue as FrameworkElement;

            if (grid != null && panel != null)
            {
                ConfigurationPanelBehavior behavior = new ConfigurationPanelBehavior(grid, panel);
            }
        }

        public ConfigurationPanelBehavior(RadGridView gridView, FrameworkElement panel)
        {
            this.RemoveChildTableDefinitionsCommand = new RemoveChildTableDefinitonsCommand(this);
            this.RestoreChildTableDefinitionsCommand = new RestoreChildTableDefinitonsCommand(this);
            this.gridView = gridView;
            this.controlPanel = panel;

            this.gridView.DataLoading += this.gridView_DataLoading;

            panel.LayoutUpdated += this.panel_LayoutUpdated;
        }

        void panel_LayoutUpdated(object sender, EventArgs e)
        {
            if (this.controlPanel != null)
            {
                this.controlPanel.DataContext = this;
            }
        }

        public void RemoveChildTableDefinitions()
        {
            gridView.ChildTableDefinitions.Clear();
        }

        public void RestoreChildTableDefinitions()
        {
            gridView.ChildTableDefinitions.Clear();

            GridViewTableDefinition definition = new GridViewTableDefinition();
            definition.Relation = new PropertyRelation("Details");
            gridView.ChildTableDefinitions.Add(definition);
        }

        private void gridView_DataLoading(object sender, GridViewDataLoadingEventArgs e)
        {
            GridViewDataControl dataControl = (GridViewDataControl)sender;
            if (dataControl.ParentRow != null)
            {
                dataControl.GridLinesVisibility = GridLinesVisibility.None;
                dataControl.CanUserFreezeColumns = false;
                dataControl.ShowGroupPanel = false;
                dataControl.AutoGenerateColumns = false;

                GridViewDataColumn column = new GridViewDataColumn();
                column.Header = "Order ID";
                column.DataMemberBinding = new System.Windows.Data.Binding("OrderID");
                dataControl.Columns.Add(column);

                column = new GridViewDataColumn();
                column.Header = "Product ID";
                column.DataMemberBinding = new System.Windows.Data.Binding("ProductID");
                dataControl.Columns.Add(column);

                column = new GridViewDataColumn();
                column.Header = "Unit Price";
                column.DataFormatString = "{0:c}";
                column.DataMemberBinding = new System.Windows.Data.Binding("UnitPrice");
                dataControl.Columns.Add(column);

                column = new GridViewDataColumn();
                column.Header = "Quantity";
                column.DataMemberBinding = new System.Windows.Data.Binding("Quantity");
                dataControl.Columns.Add(column);
            }
        }
    }
}
