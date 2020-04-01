using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
namespace Telerik.Windows.Examples.GridView.ControlPanel
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
        public Example()
        {
            InitializeComponent();
        }
    }
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value as SolidColorBrush != null ? (value as SolidColorBrush).Color : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }
    }
  

}