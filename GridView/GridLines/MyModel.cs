using System.Linq;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.GridView.GridLines
{
    public class MyModel : ViewModelBase
    {
        public MyModel()
        {
            HorizontalGridLinesColor = Colors.Black;
            VerticalGridLinesColor = Colors.Black;
        }

        IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _gridLines;
        public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> GridLines
        {
            get
            {
                if (_gridLines == null)
                {
                    _gridLines = Telerik.Windows.Data.EnumDataSource.FromType<GridLinesVisibility>();
                    _selectedItem = _gridLines.FirstOrDefault();
                }

                return _gridLines;
            }
        }

        EnumMemberViewModel _selectedItem;
        public EnumMemberViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set 
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;

                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        Brush _horizontalGridLinesBrush;
        public Brush HorizontalGridLinesBrush
        {
            get
            {
                return _horizontalGridLinesBrush;
            }
            set 
            {
                if (_horizontalGridLinesBrush != value)
                {
                    _horizontalGridLinesBrush = value;

                    OnPropertyChanged("HorizontalGridLinesBrush");
                }
            }
        }

        Brush _verticalGridLinesBrush;
        public Brush VerticalGridLinesBrush
        {
            get
            {
                return _verticalGridLinesBrush;
            }
            set 
            {
                if (_verticalGridLinesBrush != value)
                {
                    _verticalGridLinesBrush = value;

                    OnPropertyChanged("VerticalGridLinesBrush");
                }
            }
        }

        Color _horizontalGridLinesColor;
        public Color HorizontalGridLinesColor
        {
            get
            {
                return _horizontalGridLinesColor;
            }
            set 
            {
                if (_horizontalGridLinesColor != value)
                {
                    _horizontalGridLinesColor = value;

                    OnPropertyChanged("HorizontalGridLinesColor");

                    HorizontalGridLinesBrush = new SolidColorBrush(_horizontalGridLinesColor);
                }
            }
        }

        Color _verticalGridLinesColor;
        public Color VerticalGridLinesColor
        {
            get
            {
                return _verticalGridLinesColor;
            }
            set 
            {
                if (_verticalGridLinesColor != value)
                {
                    _verticalGridLinesColor = value;

                    OnPropertyChanged("VerticalGridLinesColor");

                    VerticalGridLinesBrush = new SolidColorBrush(_verticalGridLinesColor);
                }
            }
        }
    }
}
