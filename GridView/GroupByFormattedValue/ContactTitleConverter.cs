using System;
using System.Linq;
using System.Windows.Data;

namespace Telerik.Windows.Examples.GridView.GroupByFormattedValue
{
	public class ContactTitleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string contactTitle = value as string;

			if (contactTitle != null)
			{
				if (contactTitle.Contains("Sales"))
				{
					return "Sales";
				}
				if (contactTitle.Contains("Marketing"))
				{
					return "Marketing";
				}
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
