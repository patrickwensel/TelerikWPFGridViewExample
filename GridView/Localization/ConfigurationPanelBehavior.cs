using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using System.Linq;
using System.Resources;
using System.Reflection;

namespace Telerik.Windows.Examples.GridView.Localization
{
    public class ConfigurationPanelBehavior : ViewModelBase
    {
        private RadGridView gridView = null;
        private readonly FrameworkElement controlPanel = null;
        private readonly FrameworkElement layoutRoot = null;
        private readonly string[] _languageChoices = { "English", "German", "French" };
        private readonly string[] _directionChoices = { "Left to right", "Right to left" };
        private string _currentLanguage;
        private string _currentDirection;

        public static readonly DependencyProperty ConrolPanelProperty =
        DependencyProperty.RegisterAttached("ControlPanel", typeof(FrameworkElement), typeof(ConfigurationPanelBehavior),
            new PropertyMetadata(new PropertyChangedCallback(OnControlPanelPropertyChanged)));

        public string CurrentLanguage
        {
            get
            {
                return this._currentLanguage;
            }
            set
            {
                if (this._currentLanguage != value && value != null)
                {
                    this._currentLanguage = value;
                    OnPropertyChanged("CurrentLanguage");
                    this.ChangeLanguage(value);
                }
            }
        }

        public string CurrentDirection
        {
            get
            {
                return this._currentDirection;
            }
            set
            {
                if (this._currentDirection != value && value != null)
                {
                    this._currentDirection = value;
                    OnPropertyChanged("CurrentDirection");
                    this.ChangeDirection();
                }
            }
        }


        public string[] LanguageChoices
        {
            get
            {
                return this._languageChoices;
            }
        }

        public string[] DirectionChoices
        {
            get
            {
                return this._directionChoices;
            }
        }

        public static void SetControlPanel(DependencyObject dependencyObject, FrameworkElement panel)
        {
            dependencyObject.SetValue(ConrolPanelProperty, panel);
        }

        public static FrameworkElement GetControlPanel(DependencyObject dependencyObject)
        {
            return (FrameworkElement)dependencyObject.GetValue(ConrolPanelProperty);
        }

        public static void OnControlPanelPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement layoutRoot = dependencyObject as FrameworkElement;
            FrameworkElement panel = e.NewValue as FrameworkElement;

            if (layoutRoot != null && panel != null)
            {
                ConfigurationPanelBehavior behavior = new ConfigurationPanelBehavior(layoutRoot, panel);
            }
        }

        public ConfigurationPanelBehavior(FrameworkElement layoutRoot, FrameworkElement panel)
        {
            this.layoutRoot = layoutRoot;
            this.controlPanel = panel;
            this.CurrentLanguage = this.LanguageChoices.FirstOrDefault();
            this.CurrentDirection = this.DirectionChoices.FirstOrDefault();

            this.controlPanel.LayoutUpdated += this.controlPanel_LayoutUpdated;
        }

        void controlPanel_LayoutUpdated(object sender, EventArgs e)
        {
            this.controlPanel.DataContext = this;
        }

        private void ChangeLanguage(string language)
        {
            ChangeLocalization(language);

            this.LoadGrid();
        }

        private void ChangeLocalization(string localizationName)
        {
            switch (localizationName)
            {
                case "English":
                    LocalizationManager.DefaultResourceManager = new ResourceManager("Telerik.Windows.Examples.GridView.Localization.English", Assembly.GetCallingAssembly());
                    break;

                case "German":
                    LocalizationManager.DefaultResourceManager = new ResourceManager("Telerik.Windows.Examples.GridView.Localization.German", Assembly.GetCallingAssembly());
                    break;

                case "French":
                    LocalizationManager.DefaultResourceManager = new ResourceManager("Telerik.Windows.Examples.GridView.Localization.French", Assembly.GetCallingAssembly());
                    break;

                default:
                    break;
            }
        }

        private void ChangeDirection()
        {
            this.SetGridViewFlowDirection();
        }

        private void LoadGrid()
        {
            this.gridView = new RadGridView();
            this.gridView.CanUserFreezeColumns = false;
            this.gridView.HorizontalAlignment = HorizontalAlignment.Stretch;

            this.SetGridViewFlowDirection();
            this.CreateColumns();
            this.gridView.ItemsSource = new Northwind().CustomersCollection;

            (this.layoutRoot as Grid).Children.Clear();
            (this.layoutRoot as Grid).Children.Add(gridView);
        }

        private void CreateColumns()
        {
            this.gridView.AutoGenerateColumns = false;

            this.AddGridViewDataColumn("CustomerID");
            this.AddGridViewDataColumn("CompanyName");
            this.AddGridViewDataColumn("ContactName");
            this.AddGridViewDataColumn("Address");
            this.AddGridViewDataColumn("City");
            this.AddGridViewDataColumn("PostalCode");
            this.AddGridViewDataColumn("Country");
            this.AddGridViewDataColumn("Phone");
            this.AddGridViewDataColumn("Fax");
        }

        private void AddGridViewDataColumn(string propertyName)
        {
            GridViewDataColumn column = new GridViewDataColumn();
			column.DataMemberBinding = new System.Windows.Data.Binding(propertyName);
            column.Header = LocalizationManager.GetString(propertyName);

            this.gridView.Columns.Add(column);
        }

        private void SetGridViewFlowDirection()
        {
            this.gridView.FlowDirection = this.GetFlowDirection();
        }

        private FlowDirection GetFlowDirection()
        {
            if (this.CurrentDirection == "Left to right")
            {
                return FlowDirection.LeftToRight;
            }

            return FlowDirection.RightToLeft;
        }
    }
}
