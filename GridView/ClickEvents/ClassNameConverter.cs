using System;
using System.Linq;
using System.Windows.Data;

namespace Telerik.Windows.Examples.GridView.ClickEvents
{
	public class ClassNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value != null ? value.GetType().Name : value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value;
		}
	}
}
