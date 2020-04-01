using System;
using System.Linq;
using System.ComponentModel;

namespace Telerik.Windows.Examples.GridView.EnumDataSource
{
	/// <summary>
	/// A football player position.
	/// </summary>
	public enum Position
	{
		/// <summary>
		/// In Silverlight, you can use the DisplayAttribute.ShortName data annotation as well.
		/// </summary>
		[Description("Goalkeeper")]
		GK,
		
		[Description("Defender")]
		DF,
		
		[Description("Midfield")]
		MF,
		
		[Description("Forward")]
		FW
	}
}
