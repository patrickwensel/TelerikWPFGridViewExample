using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples
{
    public class MyGroupFooterCellStyleSelector : StyleSelector
    {
        public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            GridViewGroupFooterCell cell = container as GridViewGroupFooterCell;
            GridViewGroupFooterRow groupFooterRow = cell.ParentRow as GridViewGroupFooterRow;
            QueryableCollectionViewGroup group = groupFooterRow.Group as QueryableCollectionViewGroup;

            if (group != null)
            { 
                AggregateFunction f = cell.Column.AggregateFunctions.FirstOrDefault();
                if (f != null)
                {
                    AggregateResult result = group.AggregateResults[f.FunctionName];

                    if (result != null && result.Value != null && object.Equals(result.Value.GetType(), typeof(double)) && (double)result.Value > 5)
                    {
                        return this.GroupFooterCellStyle;
                    }
                    else
                    {
                        return this.DefaultGroupFooterCellStyle;
                    }
                }
            }

			return new Style(typeof(GridViewGroupFooterCell));
        }

        public Style GroupFooterCellStyle { get; set; }
        public Style DefaultGroupFooterCellStyle { get; set; }
    }
}
