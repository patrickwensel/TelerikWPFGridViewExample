using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Telerik.Windows.Examples.GridView.IComparable
{
    public class MyDataContext
    {
        ObservableCollection<MyObject> items;
        public ObservableCollection<MyObject> Items
        {
            get
            {
                if (items == null)
                {
                    var rnd = new Random();
                    items = new ObservableCollection<MyObject>();

                    for (var i = 0; i < 100; i++)
                    {
                        var obj = new MyObject(rnd) { ID = i };
                        var complexObject = new MyComplexObject(obj);
                        obj.ComplexObject = complexObject;

                        items.Add(obj);
                    }
                }

                return items;
            }
        }
    }

    public class MyObject : MyBusinessObject
    {
        public MyObject(Random random)
            : base(random)
        {
        }

        public MyComplexObject ComplexObject { get; set; }
    }

    public class MyComplexObject : IComparable<MyComplexObject>
    {
        MyObject source;

        public MyComplexObject(MyObject source)
        {
            this.source = source;
        }

        public override string ToString()
        {
            if (this.source != null)
            {
                return string.Format("ID: {0}, Name: {1}", this.source.ID, this.source.Name);
            }

            return base.ToString();
        }

        public int CompareTo(MyComplexObject other)
        {
            if (this.source != null && other != null)
            {
                return this.source.ID.CompareTo(other.source.ID);
            }

            return -1;
        }
    }
}
