using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class EnumExtension
    {
        /// <span class="code-SummaryComment"><summary></span>
        /// Gets the <span class="code-SummaryComment"><see cref="DescriptionAttribute" /> of an <see cref="Enum" /> </span>
        /// type value.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="value">The <see cref="Enum" /> type value.</param></span>
        /// <span class="code-SummaryComment"><returns>A string containing the text of the</span>
        /// <span class="code-SummaryComment"><see cref="DescriptionAttribute"/>.</returns></span>
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            string description = value.ToString();
            var fieldInfo = value.GetType().GetField(description);
            if (fieldInfo == null) return "";

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Converts the <span class="code-SummaryComment"><see cref="Enum" /> type to an <see cref="IList" /> </span>
        /// compatible object.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="type">The <see cref="Enum"/> type.</param></span>
        /// <span class="code-SummaryComment"><returns>An <see cref="IList"/> containing the enumerated</span>
        /// type value and description.<span class="code-SummaryComment"></returns></span>
        public static List<KeyValuePair<Enum, string>> ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var list = new List<KeyValuePair<Enum, string>>();
            var enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
                //list.Add(GetDescription(value));
            }

            return list;
        }

        public static T GetEnum<T>(this string value)
        {
            var enumValues = Enum.GetValues(typeof(T));

            return enumValues.Cast<T>().FirstOrDefault(val => GetDescription(val as Enum) == value);
        }

        public static T GetEnumByName<T>(this string value)
        {
            var enumValues = Enum.GetValues(typeof(T));

            return enumValues.Cast<T>().FirstOrDefault(val => val.ToString() == value);
        }
    }
    
}
