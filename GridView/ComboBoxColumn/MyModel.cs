using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Windows.Data;
using System.Windows;
using Telerik.Windows.Data;
using System.ComponentModel;
using Telerik.Windows.Controls.GridView;

namespace Telerik.Windows.Examples.GridView.ComboBoxColumn
{
    public class MyModel : ViewModelBase
    {
        private readonly string[] countryNames;
        private readonly string[] capitalNames;
        private readonly string[] continentNames;

        public MyModel()
        {
            countryNames = new string[11] { "USA", "Canada", "Mexico", "Italy", "Germany", "France", "Belgium", "Russia", "Spain", "Portugal", "Greece" } ;
            capitalNames = new string[11] { "Washington", "Ottawa", "Mexico City", "Rome", "Berlin", "Paris", "Brussels", "Moscow", "Madrid", "Lisbon", "Athens" };
            continentNames = new string[11] { "North America", "North America", "North America", "Europe", "Europe", "Europe", "Europe", "Europe", "Europe", "Europe", "Europe" };
        }

        IEnumerable _data;
        public IEnumerable Data
        {
            get
            {
                if (_data == null)
                {
                    _data = GetData();
                }

                return _data;
            }
        }

        ObservableCollection<GridViewColumn> _columns;
        public ObservableCollection<GridViewColumn> Columns
        {
            get
            {
                if (_columns == null)
                {
                    _columns = new ObservableCollection<GridViewColumn>();
                }
                return _columns;
            }
        }

        EnumMemberViewModel _type;
        public EnumMemberViewModel Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (_type != value)
                {
                    _type = value;

                    _data = null;

                    OnPropertyChanged("Type");
                    OnPropertyChanged("Data");
                }
            }
        }

        string _descriptionHeader;
        public string DescriptionHeader
        {
            get
            {
                return _descriptionHeader;
            }
            set
            {
                if (_descriptionHeader != value)
                {
                    _descriptionHeader = value;

                    OnPropertyChanged("DescriptionHeader");
                }
            }
        }

        string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;

                    OnPropertyChanged("Description");
                }
            }
        }

        private IEnumerable GetData()
        {
            if (Type == null)
                return null;

            switch ((ColumnType)Type.Value)
            {
                case ColumnType.GridViewMultiColumnComboBoxColumn:
                    {
                        Description = "This is a demonstration of the GridViewMultiColumnComboBoxColumn.";
                        DescriptionHeader = "GridViewMultiColumnComboBoxColumn";
                        Columns.Clear();

                        List<Location> locations = new List<Location>();
                        for (int i = 0; i < 10; i++)
                        {
                            Location location = new Location();
                            location.ID = i;
                            location.CountryID = i;
                            location.Description = "Description" + i;
                            locations.Add(location);
                        }

                        List<Country> countries = new List<Country>();
                        for (int i = 0; i < 10; i++)
                        {
                            Country country = new Country();
                            country.ID = i;
                            country.Name = countryNames[i];
                            country.Capital = capitalNames[i];
                            country.Continent = continentNames[i];
                            countries.Add(country);
                        }

                        GridViewMultiColumnComboBoxColumn comboColumn = new GridViewMultiColumnComboBoxColumn();
                        comboColumn.Header = "Country ID & Name";
                        comboColumn.DataMemberBinding = new Binding("CountryID");
                        comboColumn.SelectedValuePath = "ID";
                        comboColumn.DisplayMemberPath = "Name";
                        comboColumn.ItemsSource = countries;
                        comboColumn.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        comboColumn.DropDownWidth = 330;
                        comboColumn.DropDownHeight = 250;

                        Columns.Add(comboColumn);

                        GridViewDataColumn column = new GridViewDataColumn();
                        column.DataMemberBinding = new Binding("Description");
                        column.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(column);

                        return locations;
                    }

                case ColumnType.ComboBoxColumnBoundToString:
                    {
                        Description = "This is a demonstration of GridViewComboBoxColumn bound to a list of strings.";
                        DescriptionHeader = "ComboBoxColumn bound to string";
                        Columns.Clear();

                        List<Product> products = new List<Product>();
                        for (int i = 0; i < 10; i++)
                        {
                            Product product = new Product();
                            product.ID = i;
                            product.ProductName = String.Format("Product{0}", i);
                            products.Add(product);
                        }

                        GridViewComboBoxColumn column = new GridViewComboBoxColumn();
                        column.DataMemberBinding = new Binding("ProductName");
                        column.ItemsSource = from p in products
                                             select p.ProductName;
						column.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(column);

                        return products;
                    }
                case ColumnType.ComboBoxColumnBoundToObjectWithoutSelectedValueMemberPath:
                    {
                        Description = "This is a demonstration of GridViewComboBoxColumn bound to a list of objects without SelectedValueMemberPath set.";
                        DescriptionHeader = "ComboBoxColumn bound to Objects";
                        Columns.Clear();

                        List<Employee> employees = new List<Employee>();
                        for (int i = 0; i < 10; i++)
                        {
                            Employee employee = new Employee();
                            employee.Name = String.Format("Name{0}", i);
                            employees.Add(employee);
                        }

                        List<Position> positions = new List<Position>();
                        for (int i = 0; i < 10; i++)
                        {
                            Position position = new Position();
                            position.Description = String.Format("Description{0}", i);
                            position.Employee = employees[i];
                            positions.Add(position);
                        }

                        GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn();
                        comboColumn.DataMemberBinding = new Binding("Employee");
                        comboColumn.DisplayMemberPath = "Name";
                        comboColumn.ItemsSource = employees;
                        comboColumn.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(comboColumn);

                        GridViewDataColumn column = new GridViewDataColumn();
                        column.DataMemberBinding = new Binding("Description");
                        column.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(column);

                        return positions;
                    }
                case ColumnType.ComboBoxColumnBoundToEnum:
                    {
                        Description = "This is a demonstration of GridViewComboBoxColumn bound to a list of enum.";
                        DescriptionHeader = "ComboBoxColumn bound to Enum";
                        Columns.Clear();

                        List<Person> persons = new List<Person>();

                        Person person = new Person();
                        person.ID = 1;
                        person.Gender = Gender.Male;

                        persons.Add(person);

                        person = new Person();
                        person.ID = 2;
                        person.Gender = Gender.Female;
                        persons.Add(person);

                        List<Gender> AvailableGenders = new List<Gender>();
                        AvailableGenders.Add(Gender.Male);
                        AvailableGenders.Add(Gender.Female);

                        GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn();
                        comboColumn.DataMemberBinding = new Binding("Gender");
                        comboColumn.ItemsSource = AvailableGenders;
						comboColumn.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(comboColumn);

                        return persons;
                    }
                case ColumnType.ComboBoxColumnBoundToObjectWithSelectedValueMemberPath:
                    {
                        Description = "This is a demonstration of GridViewComboBoxColumn bound to a list of objects with SelectedValueMemberPath set.";
                        DescriptionHeader = "ComboBoxColumn bound to Objects";
                        Columns.Clear();

                        List<Location> locations = new List<Location>();
                        for (int i = 0; i < 10; i++)
                        {
                            Location location = new Location();
                            location.ID = i;
                            location.CountryID = i;
                            locations.Add(location);
                        }

                        List<Country> countries = new List<Country>();
                        for (int i = 0; i < 10; i++)
                        {
                            Country country = new Country();
                            country.ID = i;
                            country.Name = countryNames[i];
                            countries.Add(country);
                        }

                        GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn();
                        comboColumn.DataMemberBinding = new Binding("CountryID");
                        comboColumn.SelectedValueMemberPath = "ID";
                        comboColumn.DisplayMemberPath = "Name";
                        comboColumn.ItemsSource = countries;
						comboColumn.Width = new GridViewLength(1, GridViewLengthUnitType.Star);
                        Columns.Add(comboColumn);

                        return locations;
                    }
                
            }

            return null;
        }

        IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _columnTypes;
        public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> ColumnTypes
        {
            get
            {
                if (_columnTypes == null)
                {
                    _columnTypes = Telerik.Windows.Data.EnumDataSource.FromType<ColumnType>();

                    Type = _columnTypes.FirstOrDefault();
                }

                return _columnTypes;
            }
        }
    }

    public enum ColumnType
    {
        [Description("MultiColumnComboBoxColumn")]
        GridViewMultiColumnComboBoxColumn,

        [Description("ComboBoxColumn bound to string")]
        ComboBoxColumnBoundToString,

        [Description("ComboBoxColumn bound to enum")]
        ComboBoxColumnBoundToEnum,

        [Description("ComboBoxColumn bound to object without SelectedValueMemberPath")]
        ComboBoxColumnBoundToObjectWithoutSelectedValueMemberPath,

        [Description("ComboBoxColumn bound to object with SelectedValueMemberPath")]
        ComboBoxColumnBoundToObjectWithSelectedValueMemberPath,

    }
}
