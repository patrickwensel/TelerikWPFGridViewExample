using System;

namespace Telerik.Windows.Examples.GridView.ComboBoxColumn
{
    public class Employee
    {
        public string Name { get; set; }
    }

    public class Position
    {
        public string Description { get; set; }

        public Employee Employee { get; set; }
    }
}
