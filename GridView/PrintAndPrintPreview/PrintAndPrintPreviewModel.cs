using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.PrintAndPrintPreview
{
    public class PrintAndPrintPreviewModel : DependencyObject, INotifyPropertyChanged
    {
        public PrintAndPrintPreviewModel()
        {
            this.PrintCommand = new PrintCommand(this);
            this.PrintPreviewCommand = new PrintPreviewCommand(this);
            this.HeaderBackground = Color.FromArgb(255, 127, 127, 127);
            this.RowBackground = Color.FromArgb(255, 251, 247, 255);
            this.GroupHeaderBackground = Color.FromArgb(255, 216, 216, 216);

            PrintAndPrintPreviewExtensions.LoadSpreadsheet();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Color headerBackground;
        private Color rowBackground;
        private Color groupHeaderBackground;
        private PrintCommand printCommand = null;
        PrintPreviewCommand printPreviewCommand = null;


        public PrintCommand PrintCommand
        {
            get
            {
                return this.printCommand;
            }
            set
            {
                if (this.printCommand != value)
                {
                    this.printCommand = value;
                    OnPropertyChanged("PrintCommand");
                }
            }
        }

        public PrintPreviewCommand PrintPreviewCommand
        {
            get
            {
                return this.printPreviewCommand;
            }
            set
            {
                if (this.printPreviewCommand != value)
                {
                    this.printPreviewCommand = value;
                    OnPropertyChanged("PrintPreviewCommand");
                }
            }
        }

        public Color GroupHeaderBackground
        {
            get
            {
                return this.groupHeaderBackground;
            }
            set
            {
                if (this.groupHeaderBackground != value)
                {
                    this.groupHeaderBackground = value;
                    OnPropertyChanged("GroupHeaderBackground");
                }
            }
        }

        public Color HeaderBackground
        {
            get
            {
                return this.headerBackground;
            }
            set
            {
                if (this.headerBackground != value)
                {
                    this.headerBackground = value;
                    OnPropertyChanged("HeaderBackground");
                }
            }
        }

        public Color RowBackground
        {
            get
            {
                return this.rowBackground;
            }
            set
            {
                if (this.rowBackground != value)
                {
                    this.rowBackground = value;
                    OnPropertyChanged("RowBackground");
                }
            }
        }

        public void Print(object parameter)
        {
            var grid = parameter as RadGridView;
            if (grid != null)
            {
                grid.Print(new PrintSettings()
                {
                    GroupHeaderBackground = this.GroupHeaderBackground,
                    HeaderBackground = this.HeaderBackground,
                    RowBackground = this.RowBackground
                });
            }
        }

        public void PrintPreview(object parameter)
        {
            var grid = parameter as RadGridView;
            if (grid != null)
            {
                grid.PrintPreview(new PrintSettings()
                {
                    GroupHeaderBackground = this.GroupHeaderBackground,
                    HeaderBackground = this.HeaderBackground,
                    RowBackground = this.RowBackground
                });
            }
        }
    }
}
