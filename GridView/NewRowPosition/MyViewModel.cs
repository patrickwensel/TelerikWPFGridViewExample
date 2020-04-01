using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.GridView.NewRowPosition
{
    public class MyViewModel : ViewModelBase
    {
        IList<MyBusinessObject> randomProducts;
        public IList<MyBusinessObject> RandomProducts
        {
            get
            {
                if (randomProducts == null)
                {
                    randomProducts = new MyBusinessObjects().GetData(7).ToList();
                }

                return randomProducts;
            }
        }

		private IEnumerable<EnumMemberViewModel> newRowPositions;		
		public IEnumerable<EnumMemberViewModel> NewRowPositions
		{
			get
			{
				if (this.newRowPositions == null)
				{
					this.newRowPositions = Telerik.Windows.Data.EnumDataSource.FromType<Telerik.Windows.Controls.GridView.GridViewNewRowPosition>();
				}

				return this.newRowPositions;
			}
		}
    }
}
