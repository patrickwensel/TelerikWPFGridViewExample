using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples
{
    ///<summary>
    /// Servers as a base type for all <see cref="RadGridView"/> examples.
    ///</summary>
    public class GridViewExample : UserControl
	{
		private ResourceDictionary filterStyleDictionary;
		public GridViewExample()
		{
			this.DataContext = new ExamplesDataContext();

			this.Loaded += this.OnLoaded;
			this.Unloaded += this.OnUnloaded;

			string source = "/GridView;component/GridViewStyles.xaml";
			this.filterStyleDictionary = new ResourceDictionary() { Source = new Uri(source, UriKind.Relative) };
		}

		private void GridViewExample_ThemeChanged(object sender, EventArgs e)
		{
			this.UpdateResources();
		}

		private void UpdateResources()
		{
			this.Resources.MergedDictionaries.Clear();
			if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
			{
				this.Resources.MergedDictionaries.Add(this.filterStyleDictionary);
			}
			else if (this.Resources.MergedDictionaries.Contains(this.filterStyleDictionary))
			{
				this.Resources.MergedDictionaries.Remove(this.filterStyleDictionary);
			}
		}

		protected virtual void OnLoaded(object sender, RoutedEventArgs e)
		{
			ApplicationThemeManager.GetInstance().ThemeChanged += GridViewExample_ThemeChanged;

			if (ConfigurationPanel != null)
			{
				ConfigurationPanel.DataContext = this.ChildrenOfType<RadGridView>().FirstOrDefault();
			}

			this.UpdateResources();
		}

		/// <summary>
		/// Used to clear any set data context and avoid memory leaks.
		/// </summary>
		protected virtual void OnUnloaded(object sender, RoutedEventArgs e)
		{
			ApplicationThemeManager.GetInstance().ThemeChanged -= GridViewExample_ThemeChanged;
			this.Resources.MergedDictionaries.Clear();
		}

		protected Panel ConfigurationPanel
		{
			get
			{
				return Telerik.Windows.Controls.QuickStart.QuickStart.GetConfigurationPanel(this);
			}
		}
	}
}