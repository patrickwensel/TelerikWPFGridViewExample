using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Telerik.Windows.Data;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Windows.Data;
using System.Globalization;

namespace Telerik.Windows.Examples.GridView
{
    /// <summary>
    /// Endless paged collection view for testing purposes.
    /// </summary>
    public class EndlessPagedCollectionView : IEnumerable
        , IPagedCollectionView
        , INotifyPropertyChanged
        , INotifyCollectionChanged
    {
        public event EventHandler<EventArgs> PageChanged;
        public event EventHandler<PageChangingEventArgs> PageChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private int pageIndex = -1;
        private bool isPageChanging;
        private int pageSize;

        /// <summary>
        /// We always can. We are endless.
        /// </summary>
        bool IPagedCollectionView.CanChangePage
        {
            get { return true; }
        }

        bool IPagedCollectionView.IsPageChanging
        {
            get { return this.isPageChanging; }
        }

        /// <summary>
        /// Visual Basic is so lame!
        /// </summary>
        private void SetIsPageChanging(bool value)
        {
            if (this.isPageChanging != value)
            {
                this.isPageChanging = value;
                this.OnPropertyChanged("IsPageChanging");
            }
        }

        /// <summary>
        /// Since we are endless, the item count is 
        /// the amount of items currently known to exist.
        /// In other words the item count is whatever we 
        /// have reached.
        /// </summary>
        int IPagedCollectionView.ItemCount
        {
            get
            {
                return (((IPagedCollectionView)this).PageIndex + 1) * ((IPagedCollectionView)this).PageSize;
            }
        }

        bool IPagedCollectionView.MoveToFirstPage()
        {
            return ((IPagedCollectionView)this).MoveToPage(0);
        }

        bool IPagedCollectionView.MoveToLastPage()
        {
            //We cannot move to the last page since we are endless :)
            return false;
        }

        bool IPagedCollectionView.MoveToNextPage()
        {
            return ((IPagedCollectionView)this).MoveToPage(((IPagedCollectionView)this).PageIndex + 1);
        }

        bool IPagedCollectionView.MoveToPage(int pageIndex)
        {
            if (this.OnPageChanging(pageIndex) && pageIndex != -1)
            {
                return false;
            }

            this.SetIsPageChanging(true);
            this.pageIndex = pageIndex;
            this.SetIsPageChanging(false);

            this.OnPropertyChanged("PageIndex");
            this.OnPropertyChanged("ItemCount");
            this.OnPageChanged();

            // Call this to inform all listeners that data has changed.
            this.OnCollectionChanged();

            return true;
        }

        bool IPagedCollectionView.MoveToPreviousPage()
        {
            return ((IPagedCollectionView)this).MoveToPage(((IPagedCollectionView)this).PageIndex - 1);
        }

        int IPagedCollectionView.PageIndex
        {
            get { return this.pageIndex; }
        }

        int IPagedCollectionView.PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "The PageSize of an endless collection should be positive.");
                }

                if (this.pageSize != value)
                {
                    this.pageSize = value;
                    this.OnPropertyChanged("PageSize");
                    this.OnPropertyChanged("ItemCount");

                    // Behave like good collections do.
                    ((IPagedCollectionView)this).MoveToFirstPage();
                }
            }
        }

        /// <summary>
        /// We don't know this. Remember we are endless.
        /// </summary>
        int IPagedCollectionView.TotalItemCount
        {
            get { return -1; }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            // The best part -- true endlessness ;)
            // Now this might crash if we overflow Int32, but in a
            // real scenario new "items" will be returned forever.
            IEnumerable<Order> items = from id in Enumerable.Range(((IPagedCollectionView)this).PageIndex * ((IPagedCollectionView)this).PageSize, ((IPagedCollectionView)this).PageSize)
                                       select new Order(id);
            return items.GetEnumerator();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, e);
            }
        }

        private bool OnPageChanging(int newPageIndex)
        {
            PageChangingEventArgs e = new PageChangingEventArgs(newPageIndex);
            if (this.PageChanging != null)
            {
                this.PageChanging(this, e);
            }

            return e.Cancel;
        }

        private void OnPageChanged()
        {
            EventArgs e = EventArgs.Empty;
            if (this.PageChanged != null)
            {
                this.PageChanged(this, e);
            }
        }

        private void OnCollectionChanged()
        {
            NotifyCollectionChangedEventArgs e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, e);
            }
        }

        /// <summary>
        /// Sample Order
        /// </summary>
        public class Order
        {
            private int id;
            private DateTime date;
            private double amount;
            private bool confirmed;
            private string code;
            private string country;

            /// <summary>
            /// Gets the ID.
            /// </summary>
            /// <value>The ID.</value>
            public int ID
            {
                get { return this.id; }
            }

            /// <summary>
            /// Gets or sets the date.
            /// </summary>
            /// <value>The date.</value>
            public DateTime Date
            {
                get
                {
                    return this.date;
                }
                private set
                {
                    this.date = value;
                }
            }

            /// <summary>
            /// Gets or sets the amount.
            /// </summary>
            /// <value>The amount.</value>
            public double Amount
            {
                get
                {
                    return this.amount;
                }
                private set
                {
                    this.amount = value;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="Order"/> is confirmed.
            /// </summary>
            /// <value><c>true</c> if confirmed; otherwise, <c>false</c>.</value>
            public bool Confirmed
            {
                get
                {
                    return this.confirmed;
                }
                private set
                {
                    this.confirmed = value;
                }
            }

            /// <summary>
            /// Gets or sets the code.
            /// </summary>
            /// <value>The code.</value>
            public string Code
            {
                get
                {
                    return this.code;
                }
                private set
                {
                    this.code = value;
                }
            }

            /// <summary>
            /// Gets or sets the country.
            /// </summary>
            /// <value>The country.</value>
            public string Country
            {
                get
                {
                    return this.country;
                }
                private set
                {
                    this.country = value;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Order"/> class.
            /// </summary>
            /// <param name="id">The id.</param>
            public Order(int id)
            {
                this.id = id;
                int random = new Random(id).Next(-100, 100);
                this.Date = DateTime.Now.AddDays(random);
                this.Amount = Math.Abs(random);
                this.Confirmed = random % 2 == 0;

                int someRandom = Math.Abs(this.id.GetHashCode()) / 10
                    + Math.Abs(this.Date.GetHashCode()) / 10
                    + Math.Abs(this.Amount.GetHashCode()) / 10
                    + Math.Abs(this.Confirmed.GetHashCode()) / 10;
                this.Code = someRandom.ToString() + someRandom.ToString();

                switch (random % 5)
                {
                    case 0:
                        this.Country = "USA";
                        break;
                    case 1:
                        this.Country = "UK";
                        break;
                    case 2:
                        this.Country = "Germany";
                        break;
                    case 3:
                        this.Country = "Spain";
                        break;
                    case 4:
                        this.Country = "France";
                        break;
                    default:
                        this.Country = "Other";
                        break;
                }
            }
        }
    }
}
