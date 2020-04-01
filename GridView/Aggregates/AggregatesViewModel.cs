using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Telerik.Windows.Examples.GridView.Aggregates
{
    public class AggregatesViewModel : ViewModelBase
    {
        bool showGroupHeaderColumnAggregates;
        public bool ShowGroupHeaderColumnAggregates 
        {
            get
            {
                return showGroupHeaderColumnAggregates;
            }
            set
            {
                if (showGroupHeaderColumnAggregates != value)
                {
                    showGroupHeaderColumnAggregates = value;

                    OnPropertyChanged("ShowGroupHeaderColumnAggregates");
                }
            }
        }

        bool showHeaderAggregates;
        public bool ShowHeaderAggregates
        {
            get
            {
                return showHeaderAggregates;
            }
            set
            {
                if (showHeaderAggregates != value)
                {
                    showHeaderAggregates = value;

                    OnPropertyChanged("ShowHeaderAggregates");
                }
            }
        }

        private ColumnAggregatesAlignment selectedAlignment = ColumnAggregatesAlignment.NoAlignment;

        public ColumnAggregatesAlignment SelectedAlignment 
        {
            get
            { 
                return this.selectedAlignment; 
            }
            set 
            {
                if (this.selectedAlignment != value)
                {
                    this.selectedAlignment = value;
                    this.OnPropertyChanged("SelectedAlignment");
                }
            }
        }

        private IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> alignmentOptions;
        public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> AlignmentOptions 
        {
            get 
            {
                if (alignmentOptions == null)
                {
                    alignmentOptions = 
                        Telerik.Windows.Data.EnumDataSource.FromType<ColumnAggregatesAlignment>();
                }

                return alignmentOptions;
            }
        }
    }
}
