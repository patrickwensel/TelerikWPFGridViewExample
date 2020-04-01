using System;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.PagingBeforeGrouping
{
	public class MyViewModel : ViewModelBase
	{
		private PagingBeforeGroupingQueryableCollectionView view;

		public PagingBeforeGroupingQueryableCollectionView View
		{
			get
			{
				if (this.view == null)
				{
					this.view = new PagingBeforeGroupingQueryableCollectionView(new Northwind().CustomersCollection);
				}

				return this.view;
			}
		}
	}
}
