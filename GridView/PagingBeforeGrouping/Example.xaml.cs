using Telerik.Windows.Controls.GridView;
namespace Telerik.Windows.Examples.GridView.PagingBeforeGrouping
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
        public Example()
        {
            InitializeComponent();

			var csd = new ColumnSortDescriptor() { Column = this.radGridView.Columns["Country"] };
			this.radGridView.SortDescriptors.Add(csd);

			var cgd = new ColumnGroupDescriptor() { Column = this.radGridView.Columns["Country"] };
			this.radGridView.GroupDescriptors.Add(cgd);
		}
    }
}