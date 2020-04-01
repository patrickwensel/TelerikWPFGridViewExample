using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Data;
using Telerik.Windows.Controls.GridView;
using System.IO;
using System.Windows;
using System;
using System.Windows.Input;
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;

namespace Telerik.Windows.Examples.GridView.ExportingExcelML
{
	public class ExportCommand : ICommand
	{
		private readonly ExportingModel model;

		public ExportCommand(ExportingModel model)
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
			this.model.Export(parameter);
		}
	}

	public class ExportingModel : ViewModelBase
	{
		public ExportingModel()
		{
			this.ExportCommand = new ExportCommand(this);
			this.RowHeight = 20;
		}

		public double? RowHeight { get; set; }

		private List<ColumnModel> columns;

		public List<ColumnModel> Columns
		{
			get
			{
				if (this.columns == null)
				{
					this.columns = new List<ColumnModel>()
					{				
						new ColumnModel("Name"),
						new ColumnModel("UnitPrice")				
					};
				}
				return this.columns;
			}
		}
		private ExportCommand exportCommand = null;

		public ExportCommand ExportCommand
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

		private ICommand showOptionsCommand;

		public ICommand ShowOptionsCommand
		{
			get
			{
				if (this.showOptionsCommand == null)
				{
					this.showOptionsCommand = new DelegateCommand(new Action<object>((o) => { this.ShowOptions(o as ColumnModel); }));
				}
				return this.showOptionsCommand;
			}
		}

		private void ShowOptions(ColumnModel model)
		{
			RadWindow rw = new RadWindow();		
			RadPropertyGrid rpg = new RadPropertyGrid();
			rpg.HorizontalAlignment = HorizontalAlignment.Stretch;
			rpg.FieldIndicatorVisibility = Visibility.Collapsed;
			rpg.LabelColumnWidth = new GridLength(110);
			rpg.DescriptionPanelVisibility = Visibility.Collapsed;
			rpg.SortAndGroupButtonsVisibility = Visibility.Collapsed;
			rpg.SearchBoxVisibility = Visibility.Collapsed;		
			rpg.Item = model;
			rw.Content = rpg;
			rw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			rw.Header = "Export options";
			rw.Width = 500;
			rw.Height = 450;
			rw.Padding = new Thickness(3);
			rw.ShowDialog();
		}

		public void Export(object parameter)
		{
			var grid = parameter as RadGridView;
			if (grid != null)
			{
				grid.InitializingExcelMLStyles -= InitializingExcelMLStyles;
				grid.InitializingExcelMLStyles += InitializingExcelMLStyles;
				grid.ElementExporting -= this.ElementExporting;
				grid.ElementExporting += this.ElementExporting;

				string extension = "xls";
				var format = ExportFormat.ExcelML;

				var dialog = new SaveFileDialog();
				dialog.DefaultExt = extension;
				dialog.Filter = String.Format("Excel files (*.{0})|*.{0}|All files (*.*)|*.*", extension);
				dialog.FilterIndex = 1;

				if (dialog.ShowDialog() == true)
				{
					using (var stream = dialog.OpenFile())
					{
						var exportOptions = new GridViewExportOptions();
						exportOptions.Format = format;
						exportOptions.ShowColumnFooters = true;
						exportOptions.ShowColumnHeaders = true;
						exportOptions.ShowGroupFooters = true;

						grid.Export(stream, exportOptions);
					}
				}
			}
		}

		void InitializingExcelMLStyles(object sender, ExcelMLStylesEventArgs e)
		{
			foreach (var column in Columns)
			{
				ExcelMLStyle style = new ExcelMLStyle(column.ColumnName);
				if (column.Bold != null)
				{
					style.Font.Bold = column.Bold.Value;
				}
				if (column.DataFormat != null)
				{
					style.NumberFormat.Format = column.DataFormat;
				}
				if (column.Font != null)
				{
					style.Font.FontName = column.Font.Value.ToString();
				}
				if (column.FontColor != null)
				{
					style.Font.Color = string.Format("#{0}", column.FontColor.ToString().Substring(3, 6));
				}
				if (column.HorizontalAlignment != null)
				{
					style.Alignment.Horizontal = column.HorizontalAlignment.Value;
				}
				if (column.Indent != null)
				{
					style.Alignment.Indent = column.Indent.Value;
				}
				if (column.InteriorColor != null)
				{
					style.Interior.Color = string.Format("#{0}", column.InteriorColor.ToString().Substring(3, 6));
				}
				if (column.InteriorPattern != null)
				{
					style.Interior.Pattern = column.InteriorPattern.Value;
				}
				if (column.Italic != null)
				{
					style.Font.Italic = column.Italic.Value;
				}
				if (column.PatternColor != null)
				{
					style.Interior.PatternColor = string.Format("#{0}", column.PatternColor.ToString().Substring(3, 6));
				}
				if (column.Rotate != null)
				{
					style.Alignment.Rotate = column.Rotate.Value;
				}
				if (column.ShrinkToFit != null)
				{
					style.Alignment.ShrinkToFit = column.ShrinkToFit.Value;
				}
				if (column.FontSize != null)
				{
					style.Font.Size = column.FontSize.Value;
				}
				if (column.VerticalAlginment != null)
				{
					style.Alignment.Vertical = column.VerticalAlginment.Value;
				}
				e.Styles.Add(style);
			}
		}

		private void ElementExporting(object sender, GridViewElementExportingEventArgs e)
		{
			var visParameters = e.VisualParameters as GridViewExcelMLVisualExportParameters;
			if (e.Element == ExportElement.Row)
			{
				visParameters.RowHeight = this.RowHeight;
			}
			if (e.Element == ExportElement.Cell && (e.Context as GridViewBoundColumnBase).UniqueName == "Name")
			{
				visParameters.StyleId = "Name";
			}
			if (e.Element == ExportElement.Cell && (e.Context as GridViewBoundColumnBase).UniqueName == "UnitPrice")
			{
				visParameters.StyleId = "UnitPrice";
			}
		}
	}

	public class ColumnModel
	{
		public ColumnModel(string columnName)
		{
			this.ColumnName = columnName;
			this.FontSize = 11;
			this.Font = ExportFont.Calibri;
			this.FontColor = Colors.Black;
			this.InteriorColor = Colors.White;
			this.InteriorPattern = ExcelMLPattern.Solid;
		}

		[Display(Name = "Column name")]
		public string ColumnName { get; private set; }

		[Display(Name = "Horizontal align.")]
		public ExcelMLHorizontalAlignment? HorizontalAlignment { get; set; }

		[Display(Name = "Vertical align.")]
		public ExcelMLVerticalAlignment? VerticalAlginment { get; set; }

		[Display(Name = "Shrink to fit")]
		public bool? ShrinkToFit { get; set; }

		public int? Indent { get; set; }

		public int? Rotate { get; set; }

		public bool? Bold { get; set; }

		[Display(Name = "Display color")]
		public Color FontColor { get; set; }

		public bool? Italic { get; set; }

		[Display(Name = "Font size")]
		public int? FontSize { get; set; }

		public ExportFont? Font { get; set; }

		[Display(Name = "Interior color")]
		public Color InteriorColor { get; set; }

		[Display(Name = "Interior pattern")]
		public ExcelMLPattern? InteriorPattern { get; set; }

		[Display(Name = "Pattern color")]
		public Color PatternColor { get; set; }

		[Display(Name = "Data format")]
		public string DataFormat { get; set; }

		public override string ToString()
		{
			return this.ColumnName;
		}

		private static IEnumerable<EnumMemberViewModel> fonts;

		public static IEnumerable<EnumMemberViewModel> Fonts
		{
			get
			{
				if (fonts == null)
				{
					fonts = Telerik.Windows.Data.EnumDataSource.FromType(typeof(ExportFont));
				}
				return fonts;
			}
		}
	}

	public enum ExportFont
	{
		Tahoma,
		Arial,
		Calibri,
		Verdana
	}
}
