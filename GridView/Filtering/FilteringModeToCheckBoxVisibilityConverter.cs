using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using Telerik.Windows.Controls.GridView;

namespace Telerik.Windows.Examples.GridView.Filtering
{
	public class FilteringModeToCheckBoxVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (((Telerik.Windows.Controls.GridView.FilteringMode)value) == Telerik.Windows.Controls.GridView.FilteringMode.Popup)
			{
				return Visibility.Visible;
			}
			
			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}
	}
}
