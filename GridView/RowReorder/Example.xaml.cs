using Telerik.Windows.Data;
using System.ComponentModel;
using Samples.GridView.RowReorder;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using System.Windows;
using System;

namespace Telerik.Windows.Examples.GridView.RowReorder
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example
	{
		public Example()
		{
			InitializeComponent();
			this.Loaded += Example_Loaded;
			this.Unloaded += Example_Unloaded;
		}

		void Example_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
		}

        private void Example_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
        }

		private void Example_ThemeChanged(object sender, System.EventArgs e)
		{
			this.root.Resources.MergedDictionaries.Clear();
			this.root.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/GridView;component/RowReorder/RowStyles.xaml", UriKind.RelativeOrAbsolute)});
		}
	}
}
