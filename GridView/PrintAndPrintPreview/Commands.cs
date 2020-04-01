using System;
using System.Windows.Input;

namespace Telerik.Windows.Examples.GridView.PrintAndPrintPreview
{
    public class PrintCommand : ICommand
    {
        private readonly PrintAndPrintPreviewModel model;

        public PrintCommand(PrintAndPrintPreviewModel model)
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
            this.model.Print(parameter);
        }
    }

    public class PrintPreviewCommand : ICommand
    {
        private readonly PrintAndPrintPreviewModel model;

        public PrintPreviewCommand(PrintAndPrintPreviewModel model)
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
            this.model.PrintPreview(parameter);
        }
    }
}
