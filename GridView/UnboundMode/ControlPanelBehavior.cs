using System;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.UnboundMode
{
    public class ControlPanelBehavior
    {
        private readonly Random random = new Random();
        private readonly MyBusinessObjects businessObjectGenerator = new MyBusinessObjects();

        private readonly RadGridView gridView = null;
        private readonly FrameworkElement panel = null;

        private AddCommand _addCommand;
        private RemoveCommand _removeCommand;
        private ClearCommand _clearCommand;

        public static readonly DependencyProperty PanelProperty
        = DependencyProperty.RegisterAttached("Panel", typeof(FrameworkElement), typeof(ControlPanelBehavior),
            new PropertyMetadata(new PropertyChangedCallback(OnPanelPropertyChanged)));

        public AddCommand AddCommand
        {
            get
            {
                return this._addCommand;
            }
            set
            {
                this._addCommand = value;
            }
        }

        public RemoveCommand RemoveCommand
        {
            get
            {
                return this._removeCommand;
            }
            set
            {
                this._removeCommand = value;
            }
        }

        public ClearCommand ClearCommand
        {
            get
            {
                return this._clearCommand;
            }
            set
            {
                this._clearCommand = value;
            }
        }

        public static void SetPanel(DependencyObject dependencyObject, FrameworkElement panel)
        {
            dependencyObject.SetValue(PanelProperty, panel);
        }

        public static FrameworkElement GetPanel(DependencyObject dependencyObject)
        {
            return (FrameworkElement)dependencyObject.GetValue(PanelProperty);
        }

        private static void OnPanelPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            RadGridView grid = dependencyObject as RadGridView;
            FrameworkElement panel = e.NewValue as FrameworkElement;

            if (!object.Equals(grid, null) && !object.Equals(panel, null))
            {
                ControlPanelBehavior behavior = new ControlPanelBehavior(grid, panel);
            }
        }

        public ControlPanelBehavior(RadGridView gridView, FrameworkElement panel)
        {         
            this.AddCommand = new UnboundMode.AddCommand(this);
            this.RemoveCommand = new UnboundMode.RemoveCommand(this);
            this.ClearCommand = new UnboundMode.ClearCommand(this);
            this.gridView = gridView;
            this.panel = panel;

            this.panel.LayoutUpdated += new EventHandler(panel_LayoutUpdated);     

            FillGrid();
        }

        void panel_LayoutUpdated(object sender, EventArgs e)
        {
            if (!object.Equals(this.panel, null) && !object.Equals(this.panel.DataContext, this))
            {
                this.panel.DataContext = this;
            }
        }

        private void FillGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                MyBusinessObject randomDataItem = MyBusinessObjects.GenerateRandomBusinessObject(this.random);
                this.gridView.Items.Add(randomDataItem);
            }
        }

        public void AddItem()
        {
            MyBusinessObject randomDataItem = MyBusinessObjects.GenerateRandomBusinessObject(this.random);
            this.gridView.Items.Add(randomDataItem);
        }

        public void RemoveItem()
        {
            if (this.gridView.Items.Count > 0)
            {
                this.gridView.Items.RemoveAt(this.gridView.Items.Count - 1);
            }
        }

        public void ClearItems()
        {
            this.gridView.Items.Clear();

            this.gridView.FilterDescriptors.Clear();
            this.gridView.GroupDescriptors.Clear();
            this.gridView.SortDescriptors.Clear();
        }
    }
}