﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Telerik.Windows.Examples
{
    using System;
    using System.Linq;
    using System.Collections.Generic; 

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class Northwind { }
#else

    public partial class Northwind : System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

		private CustomersCollection _CustomersCollection;
		public CustomersCollection CustomersCollection
		{
			get
			{
                if (this._CustomersCollection == null)
                {
                    this._CustomersCollection = new CustomersCollection();

                    System.Uri resourceUri = new System.Uri("/GridView;component/SampleData/CustomersSampleDataSource/CustomersSampleDataSource.xaml", System.UriKind.Relative);
                    if (System.Windows.Application.GetResourceStream(resourceUri) != null)
                    {
                        System.Windows.Application.LoadComponent(this, resourceUri);
                    }

                }
				return this._CustomersCollection;
			}
		}
	}

	public class Customers : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

        static Northwind _Northwind;
        public static Northwind Northwind
        {
            get
            {
                if (_Northwind == null)
                {
                    _Northwind = new Northwind();
                }

                return _Northwind;
            }
        }

		IEnumerable<Order> orders;

        [System.ComponentModel.Browsable(false)]
		[System.ComponentModel.DataAnnotations.Display(AutoGenerateField = false)]
		public IEnumerable<Order> Orders
		{
			get
			{
				if (orders == null)
				{
					orders = from o in Northwind.OrdersCollection
							 where o.CustomerID == CustomerID
							 select o;
				}

				return orders;
			}
		}

		private string _CustomerID = string.Empty;

		public string CustomerID
		{
			get
			{
				return this._CustomerID;
			}

			set
			{
				if (this._CustomerID != value)
				{
					this._CustomerID = value;
					this.OnPropertyChanged("CustomerID");
				}
			}
		}

		private string _CompanyName = string.Empty;

		public string CompanyName
		{
			get
			{
				return this._CompanyName;
			}

			set
			{
				if (this._CompanyName != value)
				{
					this._CompanyName = value;
					this.OnPropertyChanged("CompanyName");
				}
			}
		}

		private string _ContactName = string.Empty;

		public string ContactName
		{
			get
			{
				return this._ContactName;
			}

			set
			{
				if (this._ContactName != value)
				{
					this._ContactName = value;
					this.OnPropertyChanged("ContactName");
				}
			}
		}

		private string _ContactTitle = string.Empty;

		public string ContactTitle
		{
			get
			{
				return this._ContactTitle;
			}

			set
			{
				if (this._ContactTitle != value)
				{
					this._ContactTitle = value;
					this.OnPropertyChanged("ContactTitle");
				}
			}
		}

		private string _Address = string.Empty;

		public string Address
		{
			get
			{
				return this._Address;
			}

			set
			{
				if (this._Address != value)
				{
					this._Address = value;
					this.OnPropertyChanged("Address");
				}
			}
		}

		private string _City = string.Empty;

		public string City
		{
			get
			{
				return this._City;
			}

			set
			{
				if (this._City != value)
				{
					this._City = value;
					this.OnPropertyChanged("City");
				}
			}
		}

		private string _PostalCode = string.Empty;

		public string PostalCode
		{
			get
			{
				return this._PostalCode;
			}

			set
			{
				if (this._PostalCode != value)
				{
					this._PostalCode = value;
					this.OnPropertyChanged("PostalCode");
				}
			}
		}

		private string _Country = string.Empty;

		public string Country
		{
			get
			{
				return this._Country;
			}

			set
			{
				if (this._Country != value)
				{
					this._Country = value;
					this.OnPropertyChanged("Country");
				}
			}
		}

		private string _Phone = string.Empty;

		public string Phone
		{
			get
			{
				return this._Phone;
			}

			set
			{
				if (this._Phone != value)
				{
					this._Phone = value;
					this.OnPropertyChanged("Phone");
				}
			}
		}

		private string _Fax = string.Empty;

		public string Fax
		{
			get
			{
				return this._Fax;
			}

			set
			{
				if (this._Fax != value)
				{
					this._Fax = value;
					this.OnPropertyChanged("Fax");
				}
			}
		}

		private string _Region = string.Empty;

		public string Region
		{
			get
			{
				return this._Region;
			}

			set
			{
				if (this._Region != value)
				{
					this._Region = value;
					this.OnPropertyChanged("Region");
				}
			}
		}

		public override string ToString()
		{
			return string.Format("Customer: " + this.CustomerID);
		}
	}

	public class CustomersCollection : System.Collections.ObjectModel.ObservableCollection<Customers>
	{ 
	}
#endif
}
