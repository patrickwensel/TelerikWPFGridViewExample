using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Telerik.Windows.Examples.GridView.Selection
{
    public class MyViewModel : ViewModelBase
    {
        IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _modes;
        public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> Modes
        {
            get
            {
                if (_modes == null)
                {
                    _modes = Telerik.Windows.Data.EnumDataSource.FromType<System.Windows.Controls.SelectionMode>();
                }

                return _modes;
            }
        }

        IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _units;
        public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> Units
        {
            get
            {
                if (_units == null)
                {
                    _units = Telerik.Windows.Data.EnumDataSource.FromType<GridViewSelectionUnit>();
                }

                return _units;
            }
        }

        private GridViewSelectionUnit selectionUnit = GridViewSelectionUnit.FullRow;

        public GridViewSelectionUnit SelectionUnit
        {
            get { return this.selectionUnit; }
            set
            {
                if (value != this.selectionUnit)
                {
                    this.selectionUnit = value;
                    if (value == GridViewSelectionUnit.FullRow)
                    {
                        this.CanUserSelectColumns = false;
                    }
                    this.OnPropertyChanged("SelectionUnit");
                    this.OnPropertyChanged("IsCanUserSelectColumnsVisible");
                }
            }
        }

        private System.Windows.Controls.SelectionMode selectionMode = System.Windows.Controls.SelectionMode.Single;
        public System.Windows.Controls.SelectionMode SelectionMode
        {
            get { return this.selectionMode; }
            set
            {
                if (value != this.selectionMode)
                {
                    this.selectionMode = value;
                    if (value == System.Windows.Controls.SelectionMode.Single)
                    {
                        this.CanUserSelectColumns = false;
                    }
                    this.OnPropertyChanged("SelectionMode");
                    this.OnPropertyChanged("IsCanUserSelectColumnsVisible");
                }
            }
        }

        private bool canUserSelectColumns;
        public bool CanUserSelectColumns
        {
            get
            {
                return this.canUserSelectColumns;
            }
            set
            {
                if (value != this.canUserSelectColumns)
                {
                    this.canUserSelectColumns = value;
                    this.OnPropertyChanged("CanUserSelectColumns");
                }
            }
        }

        public bool IsCanUserSelectColumnsVisible
        {
            get
            {
                return this.selectionMode != System.Windows.Controls.SelectionMode.Single && this.selectionUnit != GridViewSelectionUnit.FullRow;
            }
        }
    }
}
