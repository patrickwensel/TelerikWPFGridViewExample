using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.Spreadsheet;
using Telerik.Windows.Controls.Spreadsheet.Controls;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace Telerik.Windows.Examples.GridView.PrintAndPrintPreview
{
    public class PrintSettings
	{
		public Color GroupHeaderBackground
		{
			get;
			set;
		}

		public Color HeaderBackground
		{
			get;
			set;
		}

		public Color RowBackground
		{
			get;
			set;
		}
	}

	public static class PrintAndPrintPreviewExtensions
	{
		private static RadSpreadsheet spreadsheet;
		private static RadWindow window;

		internal static void LoadSpreadsheet()
		{
			spreadsheet = new RadSpreadsheet();
			window = new RadWindow() { Width = 0, Height = 0, Opacity = 0, Content = spreadsheet };
			window.Show();
		}

		internal static void CloseRadWindow(this RadGridView grid)
		{
			window.Close();
		}

		public static void Print(this RadGridView grid, PrintSettings settings)
		{
			spreadsheet.Workbook = CreateWorkbook(grid, settings);
			PrintWhatSettings printWhatSettings = new PrintWhatSettings(ExportWhat.ActiveSheet, false);

			spreadsheet.Print(printWhatSettings);
		}

		public static void PrintPreview(this RadGridView grid, PrintSettings settings)
		{
			spreadsheet.Workbook = CreateWorkbook(grid, settings);
			var printPreviewControl = CreatePrintPreviewControl(spreadsheet);
			var window = CreatePreviewWindow(printPreviewControl);

			window.ShowDialog();
		}

		private static RadWindow CreatePreviewWindow(FrameworkElement previewControl)
		{
			Grid grid = new Grid();
			grid.RowDefinitions.Add(new RowDefinition());
			grid.Children.Add(previewControl);

			Grid.SetRow(previewControl, 0);

			return new RadWindow()
			{
				Content = grid,
				Width = 900,
				Height = 670,
				Header = "Print Preview",
                WindowStartupLocation = WindowStartupLocation.CenterScreen
			};
		}

		private static PrintPreviewControl CreatePrintPreviewControl(RadSpreadsheet spreadsheet)
		{
			return new PrintPreviewControl()
			{
				RadSpreadsheet = spreadsheet
			};
		}

		private static Workbook CreateWorkbook(RadGridView grid, PrintSettings settings)
		{
			EventHandler<GridViewElementExportingToDocumentEventArgs> elementExporting = (s, e) =>
				{
					var documentVisualExportParameters = e.VisualParameters as GridViewDocumentVisualExportParameters;

					if (documentVisualExportParameters != null)
					{
						if (e.Element == ExportElement.HeaderRow)
						{
							if (settings.HeaderBackground != null)
							{
								documentVisualExportParameters.Style = new CellSelectionStyle() { Fill = new PatternFill(PatternType.Solid, settings.HeaderBackground, settings.HeaderBackground) };
							}
						}
						else if (e.Element == ExportElement.GroupHeaderRow)
						{
							if (settings.GroupHeaderBackground != null)
							{
								documentVisualExportParameters.Style = new CellSelectionStyle() { Fill = new PatternFill(PatternType.Solid, settings.GroupHeaderBackground, settings.GroupHeaderBackground) };
							}
						}
						else if (e.Element == ExportElement.Row)
						{
							if (settings.RowBackground != null)
							{
								documentVisualExportParameters.Style = new CellSelectionStyle() { Fill = new PatternFill(PatternType.Solid, settings.RowBackground, settings.RowBackground) };
							}
						}
					}
				};

			grid.ElementExportingToDocument += elementExporting;

			Workbook currentWorkbook = grid.ExportToWorkbook();

			return currentWorkbook;
		}
	}
}
