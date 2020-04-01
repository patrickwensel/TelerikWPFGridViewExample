using System;
using System.Windows.Input;

namespace Telerik.Windows.Examples.GridView.UnboundMode
{
    public class AddCommand: ICommand
    {
        private readonly ControlPanelBehavior model;

        public AddCommand(ControlPanelBehavior model)
        {
            this.model = model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            model.AddItem();
        }
    }

    public class RemoveCommand : ICommand
    {
        private readonly ControlPanelBehavior model;

        public RemoveCommand(ControlPanelBehavior model)
        {
            this.model = model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            model.RemoveItem();
        }
    }

    public class ClearCommand : ICommand
    {
        private readonly ControlPanelBehavior model;

        public ClearCommand(ControlPanelBehavior model)
        {
            this.model = model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            model.ClearItems();
        }
    }
}
