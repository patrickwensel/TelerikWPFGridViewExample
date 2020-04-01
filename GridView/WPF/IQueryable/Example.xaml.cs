using QuickStart.DataBase;
using System.Linq;

namespace Telerik.Windows.Examples.GridView.WPF.IQueryable
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
        public Example()
        {
            this.InitializeComponent();

            try
            {
                var context = new NorthwindEntities(DataBaseHelper.GetConnectionString());
                this.DataContext = context.Customers.OrderBy(c => c.Customer_ID);
            }
            catch
            {

            }
        }
    }
}