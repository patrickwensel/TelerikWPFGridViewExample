using System;
using System.Linq;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.GridView.ExpressionColumn
{
    public class MyTotalFunction : AggregateFunction<Products, double>
    {
        public MyTotalFunction()
        {
            this.AggregationExpression = products => products.Sum(p => p.UnitPrice * p.UnitsInStock);
            this.ResultFormatString = "Total: {0:C}";
        }
    }
}