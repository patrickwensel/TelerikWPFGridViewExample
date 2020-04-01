using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections;

namespace Telerik.Windows.Examples.GridView.DataSourceChangeNotifications
{
    public class MyDataContext
    {
        DeleteCurrentCommand _deleteCurrentCommand;
        public DeleteCurrentCommand DeleteCurrentCommand 
        {
            get
            {
                return _deleteCurrentCommand;
            }
            set 
            {
                _deleteCurrentCommand = value;
            }
        }
        
        ICollectionView _itemsSource;
        public ICollectionView ItemsSource
        {
            get
            {
                if (_itemsSource == null)
                {
                    CollectionViewSource collectionViewSource = new CollectionViewSource();
                    collectionViewSource.Source = new Northwind().CustomersCollection;
                    _itemsSource = collectionViewSource.View;
                    _itemsSource.MoveCurrentToFirst();

                    DeleteCurrentCommand = new DeleteCurrentCommand(this);
                }

                return _itemsSource;
            }
        }

        public void DeleteCurrent()
		{
            if (ItemsSource.CurrentItem != null)
            {
                Customers customer = ItemsSource.CurrentItem as Customers;
                IEditableCollectionView view = ItemsSource as IEditableCollectionView;
                if (customer != null)
                {
                    if (view != null)
                    {
                        if (!view.IsEditingItem && !view.IsAddingNew)
                        {
                            view.Remove(customer);
                        }
                    }
                    else if(ItemsSource.SourceCollection is IList)
                    {
                        ((IList) ItemsSource.SourceCollection).Remove(customer);
                    }
                }
            }
		}
    }

    public class DeleteCurrentCommand : ICommand
    {
        private readonly MyDataContext context;

        public DeleteCurrentCommand(MyDataContext context)
        {
            this.context = context;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            context.DeleteCurrent();
        }
    }
}
