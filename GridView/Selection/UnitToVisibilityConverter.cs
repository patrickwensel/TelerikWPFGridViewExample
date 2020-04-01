using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Telerik.Windows.Controls.GridView;

namespace Telerik.Windows.Examples.GridView.Selection
{
	public class UnitToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is GridViewSelectionUnit && (GridViewSelectionUnit)value != GridViewSelectionUnit.Cell)
			{
				return Visibility.Visible;
			}
			 
			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}