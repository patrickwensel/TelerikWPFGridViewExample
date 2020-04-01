using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView.SpreadsheetStreamingExport;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace Telerik.Windows.Examples.GridView.SpreadsheetStreamingExport
{
	public class ExampleViewModel : ViewModelBase
	{
		private ICommand exportCommand = null;
		private ICommand asyncExportCommand = null;
		private ICommand asyncExportDefaultStylesCommand = null;
		private ICommand resetItemsSourceCommand = null;

		private string selectedExportFormat;
		private string busyContent;
		private bool showLoadingIndicatorWhileAsyncExport = true;
		private int rowsCount;

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

		public ICommand AsyncExportCommand
		{
			get
			{
				return this.asyncExportCommand;
			}
			set
			{
				if (this.asyncExportCommand != value)
				{
					this.asyncExportCommand = value;
					OnPropertyChanged("AsyncExportCommand");
				}
			}
		}

		public ICommand AsyncExportDefaultStylesCommand
		{
			get
			{
				return this.asyncExportDefaultStylesCommand;
			}
			set
			{
				if (this.asyncExportDefaultStylesCommand != value)
				{
					this.asyncExportDefaultStylesCommand = value;
					OnPropertyChanged("AsyncExportDefaultStylesCommand");
				}
			}
		}

		public ICommand ResetItemsSourceCommand
		{
			get
			{
				return this.resetItemsSourceCommand;
			}
			set
			{
				if (this.resetItemsSourceCommand != value)
				{
					this.resetItemsSourceCommand = value;
					OnPropertyChanged("RebindCommand");
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
					exportFormats = new string[] { "xlsx", "csv" };
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

		public string BusyContent
		{
			get
			{
				return this.busyContent;
			}
			set
			{
				if (this.busyContent != value)
				{
					this.busyContent = value;

					OnPropertyChanged("BusyContent");
				}
			}
		}

		public bool ShowLoadingIndicatorWhileAsyncExport
		{
			get
			{
				return this.showLoadingIndicatorWhileAsyncExport;
			}
			set
			{
				if (this.showLoadingIndicatorWhileAsyncExport != value)
				{
					this.showLoadingIndicatorWhileAsyncExport = value;

					OnPropertyChanged("ShowLoadingIndicatorWhileAsyncExport");
				}
			}
		}

		public int RowsCount
		{
			get
			{
				return this.rowsCount;
			}
			set
			{
				if (this.rowsCount != value)
				{
					this.rowsCount = value;
					this.OnPropertyChanged("RowsCount");
				}
			}
		}

		public IList<MyBusinessObject> BusinessObjects
		{
			get
			{
				return new MyBusinessObjects().GetData(this.RowsCount).ToList();
			}
		}

		public ExampleViewModel()
		{
			this.RowsCount = 100;
			this.BusyContent = "Exporting Please Wait";
			this.SelectedExportFormat = this.ExportFormats.FirstOrDefault();
			this.ResetItemsSourceCommand = new DelegateCommand(this.ResetItemsSource);
			this.ExportCommand = new DelegateCommand(this.Export);
			this.AsyncExportCommand = new DelegateCommand(this.AsyncExport);
			this.AsyncExportDefaultStylesCommand = new DelegateCommand(this.AsyncExportDefaultStyles);
		}

		private void ResetItemsSource(object param)
		{
			var grid = param as RadGridView;
			if (grid != null)
			{
				grid.ItemsSource = null;
				grid.ItemsSource = this.BusinessObjects;
			}
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
				switch (this.SelectedExportFormat)
				{
					case "xlsx":
						GridViewSpreadStreamExport spreadStreamXlsxExport = new GridViewSpreadStreamExport(grid);
						spreadStreamXlsxExport.RunExport(dialog.FileName.ToString(), new SpreadStreamExportRenderer());
						break;
					case "csv":
						GridViewSpreadStreamExport spreadStreamCsvExport = new GridViewSpreadStreamExport(grid);
						spreadStreamCsvExport.ExportFormat = SpreadStreamExportFormat.Csv;
						spreadStreamCsvExport.RunExport(dialog.FileName.ToString(), new SpreadStreamExportRenderer());
						break;
				}
			}
		}

		private void AsyncExport(object param)
		{
			var grid = param as RadGridView;
			var dialog = new SaveFileDialog()
			{
				DefaultExt = this.SelectedExportFormat,
				Filter = String.Format("(*.{0})|*.{1}", this.SelectedExportFormat, this.SelectedExportFormat)
			};

			if (dialog.ShowDialog() == true)
			{
				switch (this.SelectedExportFormat)
				{
					case "xlsx":
						GridViewSpreadStreamExport spreadStreamXlsxExport = new GridViewSpreadStreamExport(grid);
						spreadStreamXlsxExport.ShowLoadingIndicatorWhileAsyncExport = this.ShowLoadingIndicatorWhileAsyncExport;
						spreadStreamXlsxExport.RunExportAsync(dialog.FileName.ToString(), new SpreadStreamExportRenderer());
						break;
					case "csv":
						GridViewSpreadStreamExport spreadStreamCsvExport = new GridViewSpreadStreamExport(grid);
						spreadStreamCsvExport.ExportFormat = SpreadStreamExportFormat.Csv;
						spreadStreamCsvExport.RunExportAsync(dialog.FileName.ToString(), new SpreadStreamExportRenderer());
						break;
				}
			}
		}

		private void AsyncExportDefaultStyles(object param)
		{
			var grid = param as RadGridView;
			var exportOptions = new GridViewSpreadStreamExportOptions()
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
				switch (this.SelectedExportFormat)
				{
					case "xlsx":
						GridViewSpreadStreamExport spreadStreamXlsxExport = new GridViewSpreadStreamExport(grid);
						spreadStreamXlsxExport.ShowLoadingIndicatorWhileAsyncExport = this.ShowLoadingIndicatorWhileAsyncExport;
						spreadStreamXlsxExport.ElementExportingToDocument += (s, e) =>
						{
							if (e.Element != SpreadStreamExportElement.Cell)
							{
								e.Style = new SpreadStreamCellStyle() { IsBold = true, FontSize = 12, Background = (Color)ColorConverter.ConvertFromString("#FFF2F2F2") };
							}
						};
						spreadStreamXlsxExport.RunExportAsync(dialog.FileName.ToString(), new SpreadStreamExportRenderer(), exportOptions);
						break;
					case "csv":
						GridViewSpreadStreamExport spreadStreamCsvExport = new GridViewSpreadStreamExport(grid);
						spreadStreamCsvExport.ExportFormat = SpreadStreamExportFormat.Csv;
						spreadStreamCsvExport.RunExportAsync(dialog.FileName.ToString(), new SpreadStreamExportRenderer());
						break;
				}
			}
		}
	}
}