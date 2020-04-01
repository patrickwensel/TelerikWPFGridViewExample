using System;
using System.Linq;
using System.Windows.Data;

namespace Telerik.Windows.Examples.GridView.UIVirtualization
{
    public class MyConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Format("Cell {0} {1}", value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
