using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Telerik.Windows.Examples.GridView
{
    /// <summary>
    /// Helper method for enum types
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets all enum values.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns>String array of all enum values</returns>
        public static string[] GetValuesAsString(Type enumType)
        {
            IEnumerable<string> valuesAsString = from v in EnumHelper.GetValues(enumType)
                                                 select Convert.ToString(v);
            return valuesAsString.ToArray();
        }

        /// <summary>
        /// Gets all enum values.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns>Object array of all enum values</returns>
        public static object[] GetValues(Type enumType)
        {
            List<object> values = new List<object>();

            IEnumerable<FieldInfo> fields = from field in enumType.GetFields()
                                            where field.IsLiteral
                                            select field;

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(enumType);
                values.Add(value);
            }

            return values.ToArray();
        }
    }
}
