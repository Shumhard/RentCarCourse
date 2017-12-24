using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Extentions
{
    public static class CodeHelper
    {
        public static double? ToDouble(this string source, double? defaultValue)
        {
            double val;
            if(Double.TryParse(source, out val))
            {
                return val;
            }

            return defaultValue;
        }

        public static DateTime ToDateTime(this string source)
        {
            return DateTime.Parse(source);
        }

        public static DateTime? ToDateTime(this string source, DateTime? defaultValue)
        {
            DateTime val;
            if (DateTime.TryParse(source, out val))
            {
                return val;
            }

            return defaultValue;
        }

        public static string DescriptionAttr<T>(this T source)
        {
            if (source == null)
            {
                return null;
            }
            FieldInfo fi = source.GetType().GetField(source.ToString());
            if (fi == null)
            {
                return null;
            }
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return source.ToString();
        }
    }
}
