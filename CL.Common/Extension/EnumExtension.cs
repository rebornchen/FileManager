using System;
using System.Collections.Generic;
using System.Linq;

namespace CL.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举的整型值
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int ToInt32(this Enum src)
        {
            return Convert.ToInt32(Enum.Parse(src.GetType(), src.ToString()));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Parse<T>(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new System.ArgumentNullException("value", "value== null");

            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch (Exception ex)
            {
                Manager.Logger.Error(ex.Message, ex);
            }

            return default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Parse<T>(int value)
        {
            try
            {
                return (T)Enum.ToObject(typeof(T), value);
            }
            catch (Exception ex)
            {
                Manager.Logger.Error(ex.Message, ex);
            }

            return default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        //public static string GetDescription(this Enum enumValue)
        //{
        //    if (enumValue== null)
        //        throw new System.ArgumentNullException("enumValue", "enumValue== null");

        //    var enumType = enumValue.GetType();

        //    var descriptions = GetEnumDescriptions(enumType);
        //    if (descriptions != null && descriptions.Length > 0)
        //    {
        //        foreach (var item in descriptions)
        //            if (enumValue.Equals(item.Value))
        //                return StringFormatter.Format(item.Description);
        //    }
        //    return enumValue.ToString();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        //public static EnumDescriptionAttribute[] GetEnumDescriptions(Type enumType)
        //{
        //    if (enumType == null)
        //        throw new System.ArgumentNullException("enumType", "enumType== null");

        //    if (!enumType.IsEnum)
        //        return null;

        //    if (!cache.ContainsKey(enumType))
        //    {
        //        var fields = enumType.GetFields();
        //        var attrs = new List<EnumDescriptionAttribute>();


        //        foreach (FieldInfo fi in fields)
        //        {
        //            object[] tmpAttrs = fi.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
        //            if (tmpAttrs.Length != 1) continue;

        //            var attr = tmpAttrs[0] as EnumDescriptionAttribute;
        //            attr.FieldName = fi.Name;
        //            if (string.IsNullOrEmpty(attr.Description))
        //                attr.DefaultDescription = attr.FieldName;

        //            attr.Value = (Enum)fi.GetValue(null);
        //            attrs.Add(attr);
        //        }

        //        cache[enumType] = attrs.ToArray();
        //    }

        //    var descriptions = cache[enumType];
        //    if (descriptions == null || descriptions.Length <= 0)
        //        return null;

        //    return descriptions;
        //}
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Enum<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

    }
}
