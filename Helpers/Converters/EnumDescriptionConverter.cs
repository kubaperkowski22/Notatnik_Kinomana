using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Notatnik_Kinomana_v2.Helpers.Converters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            Type type = value.GetType();
            if (!type.IsEnum)
                return value.ToString();

            FieldInfo fieldInfo = type.GetField(value.ToString());
            DescriptionAttribute attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                      .FirstOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            foreach (var field in targetType.GetFields())
            {
                DescriptionAttribute attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                      .FirstOrDefault() as DescriptionAttribute;
                if (attribute != null && attribute.Description == value.ToString())
                {
                    return Enum.Parse(targetType, field.Name);
                }
            }

            return Enum.Parse(targetType, value.ToString());
        }
    }
}
