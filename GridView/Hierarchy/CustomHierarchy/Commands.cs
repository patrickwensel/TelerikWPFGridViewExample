using System;
using System.Windows.Input;

namespace Telerik.Windows.Examples.GridView.Hierarchy.CustomHierarchy
{
    public class RemoveChildTableDefinitonsCommand : ICommand
    {
        private readonly ConfigurationPanelBehavior behavior;

        public RemoveChildTableDefinitonsCommand(ConfigurationPanelBehavior behavior)
        {
            this.behavior = behavior;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            behavior.RemoveChildTableDefinitions();
        }
    }

    public class RestoreChildTableDefinitonsCommand : ICommand
    {
        private readonly ConfigurationPanelBehavior behavior;

        public RestoreChildTableDefinitonsCommand(ConfigurationPanelBehavior behavior)
        {
            this.behavior = behavior;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            behavior.RestoreChildTableDefinitions();
        }
    }
}
