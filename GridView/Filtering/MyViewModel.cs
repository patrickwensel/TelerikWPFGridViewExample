using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.GridView.Filtering
{
	public class MyViewModel : ViewModelBase
	{
		private IEnumerable<EnumMemberViewModel> filteringModes;
		
		public IEnumerable<EnumMemberViewModel> FilteringModes
		{
			get
			{
				if (this.filteringModes == null)
				{
					this.filteringModes = Telerik.Windows.Data.EnumDataSource.FromType<Telerik.Windows.Controls.GridView.FilteringMode>();
				}

				return this.filteringModes;
			}
		}
	}
}
