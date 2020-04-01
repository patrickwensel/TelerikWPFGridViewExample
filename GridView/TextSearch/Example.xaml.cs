using System.Windows.Media;

namespace Telerik.Windows.Examples.GridView.TextSearch
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example
	{
		public Example()
		{
			InitializeComponent();
            this.searchPanelBackgroundColorPicker.SelectedColor = Colors.DarkGray;
            this.searchPanelForegroundColorPicker.SelectedColor = Colors.White;
        }
	}
}
