using System;
using System.Linq;
using System.Windows.Data;
using Telerik.Windows.Data;
using Telerik.Windows.Controls.GridView;

namespace Telerik.Windows.Examples
{
    public class GroupItemCountConveter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IGroup group = value as IGroup;

            if (group != null)
            {
                return group.ItemCount < 3 ? true : false;
            }

            GroupViewModel groupViewModel = value as GroupViewModel;

            if (groupViewModel != null)
            {
                return groupViewModel.Group.ItemCount < 3 ? true : false;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
