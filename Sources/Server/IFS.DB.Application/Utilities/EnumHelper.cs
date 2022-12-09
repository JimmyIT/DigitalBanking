using IFS.DB.Application.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Z.Core.Extensions;
using Z.Reflection.Extensions;

namespace IFS.DB.Application.Utilities
{
    public static class EnumHelper
    {
        public static IEnumerable<string> GetEnumValues<TEnum>()
        {
            Type type = Nullable.GetUnderlyingType(typeof(TEnum)) ?? typeof(TEnum);

            if (!type.IsEnum)
            {
                throw new ArgumentException("TEnum must be Enum type");
            }

            var validValues = new List<string>();
            foreach (TEnum e in Enum.GetValues(type))
            {
                validValues.Add(e.ToString());
            }

            return validValues;
        }

        #region Get Attribute value

        /// <summary>
        /// For enums use the "DatabaseValue" attribute
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetDbValue(this Enum @enum)
        {
            if (@enum == null)
                return null;

            try
            {
                DatabaseValueAttribute attr = @enum.GetCustomAttribute<DatabaseValueAttribute>();

                if (attr == null)
                    throw new NotImplementedException($"Missing 'DatabaseValue' attribute definition for this enum member: {@enum.GetType()}");

                return attr.Value;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public static int GetDbIntValue(this Enum @enum)
        {
            string value = @enum.GetDbValue();
            return !string.IsNullOrEmpty(value) ? int.Parse(value) : 0;
        }

        public static Guid GetDbGuidValue(this Enum @enum)
        {
            string value = @enum.GetDbValue();
            return !string.IsNullOrEmpty(value) ? new Guid(value) : Guid.Empty;
        }

        /// <summary>
        /// For enums use the "Description" attribute
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetDesc(this Enum @enum)
        {
            DescriptionAttribute attr = @enum.GetCustomAttribute<DescriptionAttribute>();

            if (attr == null)
                throw new NotImplementedException($"Missing 'DescriptionAttribute' definition for this enum member: {@enum}");

            return attr.Description;
        }

        #endregion Get Attribute value

        #region Convert to Enum

        /// <summary>
        /// Convert to enum from value
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this int value, TEnum defaultValue, bool ignoreCase = true) where TEnum : struct
        {
            Type type = typeof(TEnum);
            if (!type.IsEnum) throw new Exception(type.Name + "is not the type of Enum");

            return Enum.TryParse(value.ToStringSafe(), ignoreCase, out TEnum result) ? result : defaultValue;
        }

        /// <summary>
        /// Convert to enum from value
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this string value, TEnum defaultValue, bool ignoreCase = true) where TEnum : struct
        {
            Type type = typeof(TEnum);
            if (!type.IsEnum) throw new Exception(type.Name + "is not the type of Enum");

            return Enum.TryParse(value, ignoreCase, out TEnum result) ? result : defaultValue;
        }

        /// <summary>
        /// Convert to Enum by value from DatabaseValueAttribute
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumMemberVal"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static TEnum ToEnumFromDbValue<TEnum>(this string value, TEnum defaultValue = default, bool ignoreCase = true) where TEnum : struct
        {
            return ToEnumFromAttr<TEnum, DatabaseValueAttribute>(value, defaultValue, ignoreCase);
        }

        /// <summary>
        /// Convert to Enum by value from DatabaseValueAttribute
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumMemberVal"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static TEnum ToEnumFromDbValue<TEnum>(this int? value, TEnum defaultValue = default, bool ignoreCase = true) where TEnum : struct
        {
            return ToEnumFromAttr<TEnum, DatabaseValueAttribute>(value.ToString(), defaultValue, ignoreCase);
        }

        /// <summary>
        /// Convert to Enum by value from DatabaseValueAttribute
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumMemberVal"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static TEnum ToEnumFromDbValue<TEnum>(this Guid? value, TEnum defaultValue = default, bool ignoreCase = true) where TEnum : struct
        {
            return ToEnumFromAttr<TEnum, DatabaseValueAttribute>(value.ToString(), defaultValue, ignoreCase);
        }

        /// <summary>
        /// Convert to Enum by value from Attribute
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <typeparam name="TAttr"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        private static TEnum ToEnumFromAttr<TEnum, TAttr>(this string value, TEnum defaultValue = default, bool ignoreCase = true)
            where TEnum : struct
            where TAttr : Attribute
        {
            Type type = typeof(TEnum);
            if (!type.IsEnum) throw new Exception(type.Name + "is not the type of Enum");

            StringComparison opt = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            foreach (FieldInfo field in type.GetFields())
            {
                var attr = Attribute.GetCustomAttribute(field, typeof(TAttr));

                if (attr is EnumMemberAttribute emAttr)
                {
                    if (string.Equals(emAttr.Value, value, opt))
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
                else if (attr is DescriptionAttribute descAttr)
                {
                    if (string.Equals(descAttr.Description, value, opt))
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
                else if (attr is DatabaseValueAttribute eiAttr)
                {
                    if (string.Equals(eiAttr.Value, value, opt))
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
            }
            return defaultValue;
        }

        #endregion Convert to Enum
    }
}
