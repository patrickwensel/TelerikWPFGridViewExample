using System;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.UIVirtualization
{
    public class MyObject : ViewModelBase
    {
        public MyObject(int id)
        {
            this.ID = id;
        }

        public int ID { get; set; }
    }
}
