using System;

namespace Telerik.Windows.Examples.GridView.ComboBoxColumn
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Person
    {
        public int ID { get; set; }
        public Gender Gender { get; set; }
    }
}
