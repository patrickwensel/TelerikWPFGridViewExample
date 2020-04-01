using System;
using System.Reflection;
using System.Resources;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Infrastructure;

namespace Telerik.Windows.Examples.GridView.Localization
{
    public partial class Example
    {
        protected override void OnInitialized(EventArgs e)
        {
            Dispatcher.BeginInvoke((Action) (() =>
            {
                NavigationService.Instance.Navigated += Instance_Navigated;
            }));
            base.OnInitialized(e);
        }

        private void Instance_Navigated(object sender, EventArgs e)
        {
            LocalizationManager.DefaultResourceManager = new ResourceManager("Telerik.Windows.Controls.Strings", Assembly.GetCallingAssembly());
            NavigationService.Instance.Navigated -= Instance_Navigated;
        }
    }
}
