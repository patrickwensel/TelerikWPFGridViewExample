using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.Selection
{
	public class CellToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var cellInfo = value as GridViewCellInfo;
			if (cellInfo != null)
			{
				var grid = cellInfo.Column.DataControl as RadGridView;

				if (grid != null)
				{
					return string.Format("Row: {0}. Column: {1}", grid.Items.IndexOf(cellInfo.Item), cellInfo.Column.DisplayIndex);
				}
			}

			return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
