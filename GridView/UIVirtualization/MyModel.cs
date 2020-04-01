using System;
using Telerik.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace Telerik.Windows.Examples.GridView.UIVirtualization
{
    public class MyModel : ViewModelBase
    {
        private ObservableCollection<MyObject> _items;
        public ObservableCollection<MyObject> Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
                OnPropertyChanged("Items");
            }
        }

        private Telerik.Windows.Controls.GridViewColumnCollection _columns;
        public Telerik.Windows.Controls.GridViewColumnCollection Columns
        {
            get
            {
                if (this._columns == null || this._columns.OfType<Telerik.Windows.Controls.GridViewColumn>().Count() == 0)
                {
                    this._columns = CreateColumns();
                }
                return this._columns;
            }
            set
            {
                this._columns = value;
            }
        }


        private Telerik.Windows.Controls.GridViewColumnCollection CreateColumns()
        {
            int columnCount = 1000;
            int rowCount = 1000000;

            Items = new ObservableCollection<MyObject>(from i in Enumerable.Range(0, rowCount) select new MyObject(i));
            MyConverter converter = new MyConverter();
            Telerik.Windows.Controls.GridViewColumnCollection columns = new Telerik.Windows.Controls.GridViewColumnCollection();


            for (int i = 0; i < columnCount; i++)
            {
                GridViewDataColumn column = new GridViewDataColumn();
                column.Header = string.Format("Column {0}", i);
                column.IsReadOnly = true;
                column.ShowFieldFilters = false;
                column.Width = 150;

                Binding binding = new Binding("ID");
                binding.Converter = converter;
                binding.ConverterParameter = i;
                column.DataMemberBinding = binding;

                columns.Add(column);
            }

            return columns;
        }
    }
}
