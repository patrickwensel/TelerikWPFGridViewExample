using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using System.Linq;
using Telerik.Windows.Controls.GridView;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.GridView.RowDetails
{ 
    public class ConfigurationPanelBehavior : ViewModelBase
    {
        private readonly RadGridView gridView = null;
        private readonly FrameworkElement controlPanel = null;
        private readonly FrameworkElement layoutRoot = null;
        private readonly FrameworkElement externalDetailsBorder = null;
        public readonly IEnumerable<string> DetailsTemplateChoices = new List<string>() { "Employee Info", "Employee Notes" };
        public readonly string[] InlineDetailsChoices = { "Visible When Selected", "Visible", "Collapsed" };
        public readonly string[] ExternalDetailsPresenterChoices = { "Collapsed", "Visible" };
        public readonly string[] HorizontalScrollingChoices = { "Unfrozen", "Frozen" };

        private string _currentDetailsTemplate;
        private string _currentInlineDetails;
        private string _currentExternalDetailsPresenter;
        private string _currentHorizontalScrolling;
        
        public string CurrentDetailsTemplate
        {
            get
            {
                return this._currentDetailsTemplate;
            }
            set
            {
                if (this._currentDetailsTemplate != value)
                {
                    this._currentDetailsTemplate = value;
                    OnPropertyChanged("CurrentDetailsTemplate");
                    DetailsTemplateSelectionChanged(value);
                }
            }
        }

        public string CurrentInlineDetails
        {
            get
            {
                return this._currentInlineDetails;
            }
            set
            {
                if (this._currentInlineDetails != value)
                {
                    this._currentInlineDetails = value;
                    OnPropertyChanged("CurrentInlineDetails");
                    InlineDetailsSelectionChanged(value);
                }
            }
        }

        public string CurrentExternalDetailsPresenter
        {
            get
            {
                return this._currentExternalDetailsPresenter;
            }
            set
            {
                if (this._currentExternalDetailsPresenter != value)
                {
                    this._currentExternalDetailsPresenter = value;
                    OnPropertyChanged("CurrentExternalDetailsPresenter");
                    ExternalDetailsPresenterSelectionChanged(value);
                }
            }
        }

        public string CurrentHorizontalScrollingchoices
        {
            get
            {
                return this._currentHorizontalScrolling;
            }
            set
            {
                if (this._currentHorizontalScrolling != value)
                {
                    this._currentHorizontalScrolling = value;
                    OnPropertyChanged("CurrentHorizontalScrollingchoices");
                    HorizontalScrollingSelectionChanged(value);
                }
            }
        }

        public static readonly DependencyProperty ConrolPanelProperty =
        DependencyProperty.RegisterAttached("ControlPanel", typeof(FrameworkElement), typeof(ConfigurationPanelBehavior),
            new PropertyMetadata(new PropertyChangedCallback(OnControlPanelPropertyChanged)));

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
            this.gridView = (from i in layoutRoot.ChildrenOfType<RadGridView>() where i.Name == "radGridView" select i).FirstOrDefault();
            this.externalDetailsBorder = (from i in layoutRoot.ChildrenOfType<Border>() where i.Name == "externalDetailsBorder" select i).FirstOrDefault();
            
            this.CurrentDetailsTemplate = DetailsTemplateChoices.FirstOrDefault();
            this.CurrentInlineDetails = InlineDetailsChoices.FirstOrDefault();
            this.CurrentExternalDetailsPresenter = ExternalDetailsPresenterChoices.FirstOrDefault();
            this.CurrentHorizontalScrollingchoices = HorizontalScrollingChoices.FirstOrDefault();
            
            this.controlPanel.LayoutUpdated += controlPanel_LayoutUpdated;
        }

        void controlPanel_LayoutUpdated(object sender, EventArgs e)
        {
            this.controlPanel.DataContext = this;
            foreach (RadComboBox comboBox in controlPanel.ChildrenOfType<RadComboBox>())
            {
                switch (comboBox.Name)
                {
                    case "DetailsTemplateComboBox":
                        comboBox.ItemsSource = this.DetailsTemplateChoices;
                        comboBox.SelectedItem = this.CurrentDetailsTemplate;
                        break;
                    case "InlineDetailsComboBox":
                        comboBox.ItemsSource = this.InlineDetailsChoices;
                        comboBox.SelectedItem = this.CurrentInlineDetails;
                        break;
                    case "ExternalDetailsComboBox":
                        comboBox.ItemsSource = this.ExternalDetailsPresenterChoices;
                        comboBox.SelectedItem = this.CurrentExternalDetailsPresenter;
                        break;
                    case "HorizontalScrollingComboBox":
                        comboBox.ItemsSource = this.HorizontalScrollingChoices;
                        comboBox.SelectedItem = this.CurrentHorizontalScrollingchoices;
                        break;
                }
            }
        }

        void HorizontalScrollingSelectionChanged(string scrollingString)
        {
            if (scrollingString == "Frozen")
            {
                this.gridView.AreRowDetailsFrozen = true;
                return;
            }

            if (scrollingString == "Unfrozen")
            {
                this.gridView.AreRowDetailsFrozen = false;
                return;
            }
        }

        void ExternalDetailsPresenterSelectionChanged(string detailsString)
        {
            if (detailsString == "Visible")
            {
                this.externalDetailsBorder.Visibility = Visibility.Visible;   
                this.CurrentInlineDetails = (from i in this.InlineDetailsChoices where i == "Collapsed" select i).FirstOrDefault();
                   
                return;
            }

            if (detailsString == "Collapsed")
            {
                this.externalDetailsBorder.Visibility = Visibility.Collapsed;
                this.CurrentInlineDetails = (from i in this.InlineDetailsChoices where i == "Visible When Selected" select i).FirstOrDefault();
                   
                return;
            }
        }

        void InlineDetailsSelectionChanged(string detailsString)
        {
            if (detailsString == "Visible")
            {
                if (this.gridView.CurrentCell != null)
                {
                    this.gridView.CurrentCell.IsCurrent = false;
                }

                this.gridView.RowDetailsVisibilityMode = GridViewRowDetailsVisibilityMode.Visible;
                return;
            }

            if (detailsString == "Visible When Selected")
            {
                if (this.gridView.CurrentCell != null)
                {
                    this.gridView.CurrentCell.IsCurrent = false;
                }

                this.gridView.RowDetailsVisibilityMode = GridViewRowDetailsVisibilityMode.VisibleWhenSelected;
                return;
            }

            if (detailsString == "Collapsed")
            {
                if (this.gridView.CurrentCell != null)
                {
                    this.gridView.CurrentCell.IsCurrent = false;
                }

                this.gridView.RowDetailsVisibilityMode = GridViewRowDetailsVisibilityMode.Collapsed;
                return;
            }
        }

        void DetailsTemplateSelectionChanged(string templateString)
        {
            if (templateString == "Employee Info")
            {
                this.gridView.RowDetailsTemplate = (DataTemplate)this.layoutRoot.Resources["EmployeeInfoRowDetailsTemplate"];
                return;
            }

            if (templateString == "Employee Notes")
            {
                this.gridView.RowDetailsTemplate = (DataTemplate)this.layoutRoot.Resources["EmployeeNotesRowDetailsTemplate"];
                return;
            }
        }
    }
}