using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.GridView.CustomAggregates
{
    public class StandardDeviationFunction : AggregateFunction<Order_Detail, double>
    {
        public StandardDeviationFunction()
        {
            this.AggregationExpression = items => StdDev(items);
        }

        private double StdDev(IEnumerable<Order_Detail> source)
        {
            var itemCount = source.Count();
            if (itemCount > 1)
            {
                var values = source.Select(i => i.UnitPrice);
                var average = values.Average();
                var sum = values.Sum(v => Math.Pow(v - average, 2));
                return Math.Sqrt(sum / (itemCount - 1));
            }

            return 0;
        }
    }
}