using System;
using System.Linq;
using System.Windows.Data;

namespace Telerik.Windows.Examples
{
    public class CountryConveter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Customers customer = value as Customers;

            if (customer != null)
            {
                if (customer.Country == "Mexico")
                {
                    return true;
                }

                return false;
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
