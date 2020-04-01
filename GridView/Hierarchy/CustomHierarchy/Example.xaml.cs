using System.Linq;
using System.Windows;
using Telerik.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using System;

namespace Telerik.Windows.Examples.GridView.Hierarchy.CustomHierarchy
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

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
        }
        
        private void Example_Unloaded(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
        }

        private void Example_ThemeChanged(object sender, EventArgs e)
        {
            this.grid.Resources.MergedDictionaries.Clear();
            this.grid.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("/GridView;component/Hierarchy/CustomHierarchy/CustomHierarchyStyles.xaml", UriKind.RelativeOrAbsolute)
            });
        }
    }
}
