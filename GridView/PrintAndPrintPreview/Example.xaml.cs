namespace Telerik.Windows.Examples.GridView.PrintAndPrintPreview
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example
	{
		public Example()
		{
			InitializeComponent();
		}

		private void GridViewExample_Unloaded(object sender, System.Windows.RoutedEventArgs e)
		{
			RadGridView1.CloseRadWindow();
		}
	}
}