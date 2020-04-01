using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.Commands
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example
	{
		public Example()
		{
            // Asuring the commands are properly initialized in the grid itself
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(RadGridViewCommands).TypeHandle);

			InitializeComponent();
        }
	}
}
