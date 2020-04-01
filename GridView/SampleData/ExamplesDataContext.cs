using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Telerik.Windows.Examples
{
    public class ExamplesDataContext
    {
        Northwind northwind;
        public Northwind Northwind
        {
            get
            {
                if (northwind == null)
                {
                    northwind = new Northwind();
                }

                return northwind;
            }
        }

        IEnumerable<Customers> customers;
        public IEnumerable<Customers> Customers
        {
            get
            {
                if (customers == null)
                {
                    customers = Northwind.CustomersCollection;
                }

                return customers;
            }
        }

        IEnumerable<Products> basicProducts;
        public IEnumerable<Products> BasicProducts
        {
            get
            {
                if (this.basicProducts == null)
                {
                    this.basicProducts = Northwind.ProductsCollection.Take(25);
                }

                return this.basicProducts;
            }
        }

        IEnumerable<Products> products;
        public IEnumerable<Products> Products
        {
            get
            {
                if (products == null)
                {
                    products = Northwind.ProductsCollection;
                }

                return products;
            }
        }

        IEnumerable<Order> orders;
        public IEnumerable<Order> Orders
        {
            get
            {
                if (orders == null)
                {
                    orders = Northwind.OrdersCollection;
                }

                return orders;
            }
        }

        IEnumerable<Employee> employees;
        public IEnumerable<Employee> Employees
        {
            get
            {
                if (employees == null)
                {
                    employees = Northwind.EmployeesCollection;
                }

                return employees;
            }
        }

        IEnumerable<Order_Detail> orderDetails;
        public IEnumerable<Order_Detail> OrderDetails
        {
            get
            {
                if (orderDetails == null)
                {
                    orderDetails = Northwind.Order_DetailsCollection;
                }

                return orderDetails;
            }
        }

        IList<MyBusinessObject> randomProducts;
        public IList<MyBusinessObject> RandomProducts
        {
            get
            {
                if (randomProducts == null)
                {
                    randomProducts = new MyBusinessObjects().GetData(100).ToList();
                }

                return randomProducts;
            }
        }

        IList<MyBusinessObject> largeRandomProducts;
        public IList<MyBusinessObject> LargeRandomProducts
        {
            get
            {
                if (largeRandomProducts == null)
                {
                    largeRandomProducts = new MyBusinessObjects().GetData(1000000).ToList();
                }

                return largeRandomProducts;
            }
        }

        IEnumerable<Club> clubs;
        public IEnumerable<Club> Clubs
        {
            get
            {
                if (clubs == null)
                {
                    clubs = Club.GetClubs();
                }

                return clubs;
            }
        }
    }
}
