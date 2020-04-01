using System;
using Telerik.Windows.Data;
using System.Linq;
using System.Windows.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.GridView.RealTimeUpdate
{
    public class MyDataContext
    {
        readonly string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random rnd = new Random();

		ObservableCollection<StockData> source;
		ObservableCollection<StockData> Source
        {
            get
            {
				if (this.source == null)
                {
					this.source = new ObservableCollection<StockData>(from i in Enumerable.Range(0, 50) select this.CreateNewStockItem());

                    var timer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(1) };
                    timer.Tick += (s, e) => 
                    {
						int index = this.rnd.Next(0, this.Source.Count());
						StockData item = this.CreateNewStockItem();
						this.Source[index] = item;
                    };
                    timer.Start();
                }

				return this.source;
            }
        }

        private StockData CreateNewStockItem()
        {
            var item = new StockData();
            this.SetRandomPropertyValues(item);
            return item;
        }

        private void SetRandomPropertyValues(StockData item)
        {
			item.Name = String.Format("{0}{1}{2}{3}", this.letters[this.rnd.Next(0, this.letters.Count())], this.letters[this.rnd.Next(0, this.letters.Count())],
				this.letters[this.rnd.Next(0, this.letters.Count())], this.letters[this.rnd.Next(0, this.letters.Count())]);
            item.LastUpdate = DateTime.Now;
			item.Change = this.rnd.NextDouble();
        }

        QueryableCollectionView data;
        public QueryableCollectionView Data
        {
            get
            {
				if (this.data == null)
                {
					this.data = new QueryableCollectionView(Source);
					this.data.SortDescriptors.Add(new SortDescriptor()
                    {
                        Member = "Name",
                        SortDirection = System.ComponentModel.ListSortDirection.Descending
                    });
                }

				return this.data;
            }
        }
    }   
}
