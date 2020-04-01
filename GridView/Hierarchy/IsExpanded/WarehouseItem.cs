using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.Hierarchy.IsExpanded
{
    public class WarehouseItem : ViewModelBase
    {
        private bool isExpanded;
        private bool isExpandable;
        private string name;
        private int count;

        public WarehouseItem(string name, int count, bool isExpanded = true, bool isExpandable = true)
        {
            this.Name = name;
            this.Count = count;
            this.IsExpanded = isExpanded;
            this.IsExpandable = isExpandable;
            this.Items = new ObservableCollection<WarehouseItem>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    this.OnPropertyChanged(() => this.Name);
                }
            }
        }

        [Display(AutoGenerateField = false)]
        public bool IsExpanded
        {
            get
            {
                return this.isExpanded;
            }
            set
            {
                if (value != this.isExpanded)
                {
                    this.isExpanded = value;
                    this.OnPropertyChanged(() => this.IsExpanded);
                }
            }
        }

        [Display(AutoGenerateField = false)]
        public bool IsExpandable
        {
            get
            {
                return this.isExpandable;
            }

            set
            {
                if (this.isExpandable != value)
                {
                    this.isExpandable = value;
                    this.OnPropertyChanged(() => this.IsExpandable);
                }
            }
        }

        [Display(AutoGenerateField = false)]
        public ObservableCollection<WarehouseItem> Items { get; set; }

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                if (value != this.count)
                {
                    this.count = value;
                    this.OnPropertyChanged(() => this.Count);
                }
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}