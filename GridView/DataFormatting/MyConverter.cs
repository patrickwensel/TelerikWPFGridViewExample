using System;
using System.Linq;
using System.Windows.Data;
using System.Globalization;

namespace Telerik.Windows.Examples.GridView.DataFormatting
{
    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool) value) ? "yes" : "no";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
