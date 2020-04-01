using System;
using System.Linq;

namespace Telerik.Windows.Examples.GridView.Performance
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
        DateTime start;

        public Example()
        {
            InitializeComponent();

            RadGridView1.Sorting += ResetTime;
            RadGridView1.Grouping += ResetTime;
            RadGridView1.Filtering += ResetTime;

            ResetTimeAndSubscribeToLayoutUpdated();
        }

        void ResetTime(object sender, EventArgs e)
        {
            ResetTimeAndSubscribeToLayoutUpdated();
        }
  
        private void ResetTimeAndSubscribeToLayoutUpdated()
        {
            RadGridView1.LayoutUpdated += RadGridView1_LayoutUpdated;

            start = DateTime.Now;
        }

        void RadGridView1_LayoutUpdated(object sender, EventArgs e)
        {
            RadGridView1.LayoutUpdated -= RadGridView1_LayoutUpdated;

            TextBlock1.Text = String.Format("Total time to load: {0} ms", 
                Math.Round((DateTime.Now - start).TotalMilliseconds));
        }
    }
}