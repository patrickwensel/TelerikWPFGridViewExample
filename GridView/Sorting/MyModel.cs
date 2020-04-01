using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.Sorting
{
    public class MyModel : ViewModelBase
    {

        IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _directions;
        public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> Directions
        {
            get
            {
                if (_directions == null)
                {
                    _directions = Telerik.Windows.Data.EnumDataSource.FromType<System.ComponentModel.ListSortDirection>();
                }

                return _directions;
            }
        }
    }
}
