using System;
using System.Collections;
using System.Linq;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.GridView.PagingBeforeGrouping
{
	public class PagingBeforeGroupingQueryableCollectionView : QueryableCollectionView
	{
		public PagingBeforeGroupingQueryableCollectionView(IEnumerable source)
			: base(source)
		{
		}

		protected override IQueryable CreateView()
		{
			if (this.TotalItemCount == 0)
			{
				return this.ApplySelectDescriptors(this.QueryableSourceCollection);
			}
			else
			{
				var queryable = this.QueryableSourceCollection;
				queryable = queryable.Where(this.FilterDescriptors);
				queryable = this.Sort(queryable);
				queryable = this.ApplySelectDescriptors(queryable);

				//The following two lines are swapped in the original base implementation.
				queryable = queryable.Page(this.PageIndex, this.PageSize);// Do the paging FIRST
				queryable = queryable.GroupBy(this.GroupDescriptors);// THEN group the current page of data

				return queryable;
			}
		}

		protected override int GetPagingDeterminativeItemCount()
		{
			// This will return the number of items, not the number of groups as in the base implementation.
			return
				this.QueryableSourceCollection.
				Where(this.FilterDescriptors).
				//GroupBy(this.GroupDescriptors). --> this line is present in the base implementation.
				Count();
		}
	}
}
