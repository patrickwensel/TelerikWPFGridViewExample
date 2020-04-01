using System.ComponentModel;
using System;
using System.Globalization;
using System.Reflection;

namespace Telerik.Windows.Examples
{
    public class DateTimeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var s = value as string;
            if (s != null)
            {
                s = s.Trim();

                if (s.Length == 0)
                {
                    return DateTime.MinValue;
                }
                try
                {
                    DateTimeFormatInfo provider = null;
                    if (culture != null)
                    {
                        provider = (DateTimeFormatInfo) culture.GetFormat(typeof(DateTimeFormatInfo));
                    }
                    if (provider != null)
                    {
                        return DateTime.Parse(s, provider);
                    }
                    return DateTime.Parse(s, culture);
                }
                catch (FormatException exception)
                {
                    throw new FormatException("Invalid DateTime!");
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}