using System;
using System.Linq;
using System.ComponentModel;

namespace Telerik.Windows.Examples.GridView.EnumDataSource
{
	/// <summary>
	/// A country.
	/// </summary>
	public enum Country
	{
		[Description("United Kingdom")]
		GBR,
		
		[Description("Spain")]
		ESP,
		
		[Description("Netherlands")]
		NLD,
		
		[Description("Czech Republic")]
		CZE,
		
		[Description("France")]
		FRA
	}
}
