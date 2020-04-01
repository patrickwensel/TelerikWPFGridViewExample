using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.Selection
{
	public class SelectedCellsBindingBehavior
	{
		private readonly RadGridView gridView = null;
        private readonly System.Windows.Controls.ListBox listBox = null;
		ObservableCollection<GridViewCellInfo> selectedCells = new ObservableCollection<GridViewCellInfo>();        

        public static readonly DependencyProperty ListBoxProperty =
		DependencyProperty.RegisterAttached("ListBox", typeof(FrameworkElement), typeof(SelectedCellsBindingBehavior),
            new PropertyMetadata(new PropertyChangedCallback(OnListBoxPropertyChanged)));

		public static void SetListBox(DependencyObject dependencyObject, System.Windows.Controls.ListBox lb)
        {
			dependencyObject.SetValue(ListBoxProperty, lb);
        }

		public static System.Windows.Controls.ListBox GetListBox(DependencyObject dependencyObject)
        {
			return (System.Windows.Controls.ListBox)dependencyObject.GetValue(ListBoxProperty);
        }

        public static void OnListBoxPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            RadGridView grid = dependencyObject as RadGridView;
			System.Windows.Controls.ListBox listBox = e.NewValue as System.Windows.Controls.ListBox;

            if (grid != null && listBox != null)
            {
                SelectedCellsBindingBehavior behavior = new SelectedCellsBindingBehavior(grid, listBox);
            }
        }

		public SelectedCellsBindingBehavior(RadGridView gridView, System.Windows.Controls.ListBox listBox)
        {
            this.gridView = gridView;
            this.listBox = listBox;

			this.listBox.ItemsSource = this.selectedCells;
			this.gridView.SelectedCellsChanged += gridView_SelectedCellsChanged;
        }

		void gridView_SelectedCellsChanged(object sender, Controls.GridView.GridViewSelectedCellsChangedEventArgs e)
		{
			this.selectedCells.Clear();

			foreach (var cell in this.gridView.SelectedCells)
			{
				this.selectedCells.Add(cell);
			}
		}
	}
}
