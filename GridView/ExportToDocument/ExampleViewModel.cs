using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace Telerik.Windows.Examples.GridView.ExportToDocument
{
    public class ExampleViewModel : ViewModelBase
    {
        private static readonly Color DefaultHeaderRowColor = Color.FromArgb(255, 127, 127, 127);
        private static readonly Color DefaultGroupHeaderRowColor = Color.FromArgb(255, 216, 216, 216);
        private static readonly Color DefaultDataRowColor = Color.FromArgb(255, 251, 247, 255);

        private ICommand exportCommand = null;
        private ICommand exportDefaultStylesCommand = null;
        private Color headerBackground;
        private Color rowBackground;
        private Color groupHeaderBackground;
        private string selectedExportFormat;

        public ICommand ExportCommand
        {
            get
            {
                return this.exportCommand;
            }
            set
            {
                if (this.exportCommand != value)
                {
                    this.exportCommand = value;
                    OnPropertyChanged("ExportCommand");
                }
            }
        }

        public ICommand ExportDefaultStylesCommand
        {
            get
            {
                return this.exportDefaultStylesCommand;
            }
            set
            {
                if (this.exportDefaultStylesCommand != value)
                {
                    this.exportDefaultStylesCommand = value;
                    OnPropertyChanged("ExportDefaultStylesCommand");
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

        IEnumerable<string> exportFormats;
        public IEnumerable<string> ExportFormats
        {
            get
            {
                if (exportFormats == null)
                {
                    exportFormats = new string[] { "xlsx", "pdf" };
                }

                return exportFormats;
            }
        }

        public string SelectedExportFormat
        {
            get
            {
                return selectedExportFormat;
            }
            set
            {
                if (!object.Equals(selectedExportFormat, value))
                {
                    selectedExportFormat = value;

                    OnPropertyChanged("SelectedExportFormat");
                }
            }
        }

        public ExampleViewModel()
        {        
            this.SelectedExportFormat = this.ExportFormats.FirstOrDefault();
            this.ExportCommand = new DelegateCommand(this.Export);
            this.ExportDefaultStylesCommand = new DelegateCommand(this.ExportDefaultStyles);

            this.HeaderBackground = DefaultHeaderRowColor;
            this.RowBackground = DefaultDataRowColor;
            this.GroupHeaderBackground = DefaultGroupHeaderRowColor;
        }

        private void Export(object param)
        {
            var grid = param as RadGridView;
            var dialog = new SaveFileDialog()
            {
                DefaultExt = this.SelectedExportFormat,
                Filter = String.Format("(*.{0})|*.{1}", this.SelectedExportFormat, this.SelectedExportFormat)
            };
            
            if (dialog.ShowDialog() == true)
            {
                using (var stream = dialog.OpenFile())
                {
                    switch (this.SelectedExportFormat)
                    {
                        case "xlsx":
                            grid.ExportToXlsx(stream);
                            break;
                        case "pdf":
                            grid.ExportToPdf(stream);
                            break;
                    }
                }
            }
        }

        private void ExportDefaultStyles(object param)
        {
            var grid = param as RadGridView;
            var exportOptions = new GridViewDocumentExportOptions()
            {
                ExportDefaultStyles = true,
                ShowColumnFooters = grid.ShowColumnFooters,
                ShowColumnHeaders = grid.ShowColumnHeaders,
                ShowGroupFooters = grid.ShowGroupFooters
            };

            var dialog = new SaveFileDialog()
            {
                DefaultExt = this.SelectedExportFormat,
                Filter = String.Format("(*.{0})|*.{1}", this.SelectedExportFormat, this.SelectedExportFormat)
            };
            
            if (dialog.ShowDialog() == true)
            {
                using (var stream = dialog.OpenFile())
                {
                    switch (this.SelectedExportFormat)
                    {
                        case "xlsx":
                            grid.ExportToXlsx(stream, exportOptions);
                            break;
                        case "pdf":
                            grid.ExportToPdf(stream, exportOptions);
                            break;
                    }
                }
            }
        }
    }
}