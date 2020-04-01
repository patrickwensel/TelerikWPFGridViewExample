using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples
{
    public class AverageUnitPriceConveter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
			var aggregates = ((CollectionViewSource)value).Source as List<AggregateResult>;

            if (aggregates != null)
            {
                AggregateResult result = aggregates.FirstOrDefault(a => a.FunctionName == "UnitPrice");

                if (result != null && result.Value != null && object.Equals(result.Value.GetType(), typeof(double)) && (double)result.Value > 10)
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
