using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.RealTimeUpdate
{
    public class MyCellStyleSelector : StyleSelector
    {
        public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            StockData stockData = item as StockData;

            if(stockData != null && stockData.Change > 0.5)
            {
                return ActiveStyle;
            }

            return DefaultStyle;
        }

        public Style ActiveStyle { get; set; }

		public Style DefaultStyle { get; set; }
    }
}
