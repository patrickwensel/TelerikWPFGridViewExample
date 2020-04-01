using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using System.Collections.Generic;
using Telerik.Windows.Controls.GridView;
using System.Linq;
using System.Text.RegularExpressions;

namespace Telerik.Windows.Examples.GridView.Validation
{
    public class ValidationBehavior
    {
        private readonly RadGridView gridView = null;
        private readonly bool isValidationEnabled = false;
        private List<string> allCountries;

        public static readonly DependencyProperty IsValidationEnabledProperty =
            DependencyProperty.RegisterAttached("IsValidationEnabled", typeof(bool), typeof(ValidationBehavior),
            new PropertyMetadata(new PropertyChangedCallback(OnValidationSummaryPropertyChanged)));

        public static void SetIsValidationEnabled(DependencyObject dependencyObject, bool isEnabled)
        {
            dependencyObject.SetValue(IsValidationEnabledProperty, isEnabled);
        }

        public static bool GetIsValidationEnabled(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(IsValidationEnabledProperty);
        }

        public static void OnValidationSummaryPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            RadGridView gridView = dependencyObject as RadGridView;
            bool isEnabled = (bool)e.NewValue;

            if (gridView != null && isEnabled)
            {
                ValidationBehavior behavior = new ValidationBehavior(gridView, isEnabled);
            }
        }

        public ValidationBehavior(RadGridView gridView, bool isEnabled)
        {
            this.gridView = gridView;
            this.isValidationEnabled = isEnabled;

            this.gridView.CellValidating += this.GridView_CellValidating;
        }

        void GridView_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {
            bool isValid = true;
            string validationText = "Validation failed. ";
            GridViewCell cell = e.Cell;
            switch (cell.Column.UniqueName)
            {
                case "ContactName":
                    isValid = ValidateName((string)e.NewValue);
                    if (!isValid)
                    {
                        validationText += "The name of the customer may contain only Latin letters" +
                                          Environment.NewLine + "and empty spaces and must start with a letter.";
                    }
                    break;
                case "Country":
                    isValid = this.ValidateCountry((string)e.NewValue);
                    if (!isValid)
                    {
                        validationText += "The name of the country must match the name of an existing one.";
                    }
                    break;
                case "Phone":
                    isValid = ValidatePhone((string)e.NewValue);
                    if (!isValid)
                    {
                        validationText += "The phone must be in one of the formats X.X.X.X, Y or (X) Y, where " +
                                          Environment.NewLine +
                                          "X is a random sequence of numerals and Y is a random sequence of numerals, " +
                                          Environment.NewLine +
                                          "empty spaces and '-', which starts and ends with a numeral.";
                    }
                    break;
                case "PostalCode":
                    isValid = ValidatePostalCode(e.NewValue);
                    if (!isValid)
                    {
                        validationText += "The postal code of the customer must not be empty.";
                    }
                    break;
            }
            if (!isValid)
            {
                this.MarkCell(cell, validationText);
            }
            else
            {
                this.RestoreCell(cell);
            }

            e.ErrorMessage = validationText;
            e.IsValid = isValid;
        }

        private static List<string> GetAllCountries()
        {
            List<string> allCountries = new List<string>(1);
            IEnumerable<string> customerCountries = from customer in new Northwind().CustomersCollection
                                                    select customer.Country;
            foreach (string country in customerCountries)
            {
                allCountries.Add(country);
            }
            allCountries.Add("UK");
            allCountries.Sort();
            return allCountries;
        }

        private static bool ValidatePostalCode(object postalCode)
        {
            if (postalCode == null)
            {
                return false;
            }
            return !string.IsNullOrEmpty(postalCode.ToString());
        }

        private bool ValidateCountry(string country)
        {
            if (this.allCountries == null)
            {
                this.allCountries = GetAllCountries();
            }
            return this.allCountries.Contains(country);
        }

        private static bool ValidateName(string name)
        {
            if (name == null)
            {
                return false;
            }
            return Regex.IsMatch(name, @"^([A-Za-z]+\s*)+$");
        }

        private static bool ValidatePhone(string phone)
        {
            return string.IsNullOrEmpty(phone) ||
                   Regex.IsMatch(phone, @"^([0-9]+\.){3}[0-9]+$") || Regex.IsMatch(phone, @"^(\([0-9]+\))?\s?([0-9]+(-|\s)*)*[0-9]+\s*$");
        }

        private void MarkCell(Control cell, string validationText)
        {
            ToolTipService.SetToolTip(cell, validationText);
        }

        private void RestoreCell(Control cell)
        {
            ToolTipService.SetToolTip(cell, null);
        }
    }
}
