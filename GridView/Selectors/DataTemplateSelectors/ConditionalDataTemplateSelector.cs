using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Telerik.Windows.Examples
{
    public class ConditionalDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            object conditionValue = this.ConditionConverter.Convert(item, null, null, null);
            foreach (ConditionalDataTemplateRule rule in this.Rules)
            {
                if (Equals(rule.Value, conditionValue))
                {
                    return rule.DataTemplate;
                }
            }

            return base.SelectTemplate(item, container);
        }

        List<ConditionalDataTemplateRule> _Rules;
        public List<ConditionalDataTemplateRule> Rules 
        {
            get
            {
                if (this._Rules == null)
                {
                    this._Rules = new List<ConditionalDataTemplateRule>();
                }

                return this._Rules;
            }
        }

        IValueConverter _ConditionConverter;
        public IValueConverter ConditionConverter
        {
            get
            {
                return this._ConditionConverter;
            }
            set
            {
                this._ConditionConverter = value;
            }
        }
    }

    public class ConditionalDataTemplateRule
    {
        object _Value;
        public object Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }

        DataTemplate _DataTemplate;
        public DataTemplate DataTemplate
        {
            get
            {
                return this._DataTemplate;
            }
            set
            {
                this._DataTemplate = value;
            }
        }
   }
}
