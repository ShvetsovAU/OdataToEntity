using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ASE.MD.MDP2.Product.MDP2Service.Utils
{
    public static class EnumUtils
    {
        public static IEnumerable<object> GetValuesAndDescriptions(Type enumType)
        {
            var values = Enum.GetValues(enumType).Cast<object>();
            var valuesAndDescriptions = from value in values
                                        select new
                                        {
                                            Value = value,
                                            Description = GetDescription(value)
                                        };
            return valuesAndDescriptions;
        }

        public static IEnumerable<object> GetStateValuesAndDescriptions(Type enumType)
        {
            var values = Enum.GetValues(enumType).Cast<object>();
            var valuesAndDescriptions = from value in values
                                        select new
                                        {
                                            Value = value,
                                            Description = GetDescription(value)
                                        };

            const string Neo_WeldInProgress = "In progress";
            return valuesAndDescriptions.Where(x => x.Description != Neo_WeldInProgress);//LocalizationManager.GetString("Neo_WeldInProgress"));
        }

        public static IEnumerable<string> GetDescriptions(Type enumType)
        {
            var values = Enum.GetValues(enumType).Cast<object>();
            var descriptions = values.Select(GetDescription);
            return descriptions;
        }

        public static string GetDescription(object value)
        {
            var attribute =
                value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(true)
                    .OfType<DescriptionAttribute>()
                    .FirstOrDefault();

            return attribute != null
                ? attribute.Description
                : value.ToString();
        }

        public static string GetDescription(object value, Type type)
        {
            var name = Enum.GetName(type, value);
            return GetDescription(type, name);
        }

        public static string GetDescription(Type type, string value)
        {
            var attribute = type.GetMember(value)[0].GetCustomAttributes(true).OfType<DescriptionAttribute>().FirstOrDefault();
            return attribute != null ? attribute.Description : value;
        }

        public static string GetCompositeDescription(Enum value)
        {
            var values = value.ToString().Split(',');
            var type = value.GetType();
            return string.Join("; ", values.Select(x => GetDescription(type, x.Trim())));
        }

        public static object GetEnumValueByDescription(Type enumType, string description)
        {
            var values = Enum.GetValues(enumType);
            foreach (var value in values)
            {
                if (GetDescription(enumType, value.ToString()) == description)
                    return value;
            }
            return null;
        }
    }

    #region Converter

    //public class EnumDescriptionConverter : IValueConverter //System.Windows.Data.IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (value == null) return null;
    //        return EnumUtils.GetDescription(value);
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class EnumDescriptionConverterFromValue : IValueConverter //System.Windows.Data.IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        var type = parameter as Type;
    //        if (value == null || type == null) return null;
    //        return EnumUtils.GetDescription(value, type);
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class BooleanToOpacityConverter : IValueConverter //System.Windows.Data.IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return ((bool)value) ? 1 : 0.5;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class EnumConverter : IValueConverter //System.Windows.Data.IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        Enum enumValue = default(Enum);
    //        if (parameter is Type)
    //        {
    //            enumValue = (Enum)Enum.Parse((Type)parameter, value.ToString());
    //        }
    //        return enumValue;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        int returnValue = 0;
    //        if (parameter is Type)
    //        {
    //            returnValue = (byte)Enum.Parse((Type)parameter, value.ToString());
    //        }
    //        return returnValue;
    //    }
    //}

    #endregion Converter
}