using System;
using System.Linq;
using System.Windows.Data;

namespace Telerik.Windows.Examples
{
    public class UnitPriceConveter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Products product = value as Products;

            if (product != null)
            {
                return product.UnitPrice > 30 ? true : false;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
