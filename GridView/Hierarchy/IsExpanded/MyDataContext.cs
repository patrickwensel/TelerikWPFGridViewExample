using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.Hierarchy.IsExpanded
{
    public class MyDataContext: ViewModelBase
    {
        private ObservableCollection<WarehouseItem> warehouseData;

        public MyDataContext()
        {
            this.ToggleIsExpandedCommand = new DelegateCommand(this.OnToggleIsExpandedCommandExcuted);
            this.ToggleIsExpandableCommand = new DelegateCommand(this.OnToggleIsExpandableCommandExecuted);
        }

        public ICommand ToggleIsExpandedCommand { get; set; }
        public ICommand ToggleIsExpandableCommand { get; set; }

        public ObservableCollection<WarehouseItem> WarehouseData
        {
            get
            {
                if (warehouseData == null)
                {
                    warehouseData = new ObservableCollection<WarehouseItem>();

                    var vegetables = new WarehouseItem("Vegetables", 75);
                    vegetables.Items.Add(new WarehouseItem("Tomato", 40));
                    vegetables.Items.Add(new WarehouseItem("Carrot", 25));
                    vegetables.Items.Add(new WarehouseItem("Onion", 10));
                    warehouseData.Add(vegetables);

                    var fruits = new WarehouseItem("Fruits", 55);
                    fruits.Items.Add(new WarehouseItem("Cherry", 30));
                    fruits.Items.Add(new WarehouseItem("Apple", 20));
                    fruits.Items.Add(new WarehouseItem("Melon", 5));
                    warehouseData.Add(fruits);

                    warehouseData.Add(new WarehouseItem("Other", 0, false, false));
                }

                return warehouseData;
            }
        }

        private void OnToggleIsExpandedCommandExcuted(object param)
        {
            foreach (var item in this.WarehouseData)
            {
                item.IsExpanded = (bool)param;
            }
        }

        private void OnToggleIsExpandableCommandExecuted(object param)
        {
            foreach (var item in this.WarehouseData)
            {
                item.IsExpandable = (bool)param;
            }
        }
    }
}
