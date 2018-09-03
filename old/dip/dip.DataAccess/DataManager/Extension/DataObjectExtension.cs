using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using dip.DataAccess.DataObject.Interface;

namespace dip.DataAccess.DataManager.Extension
{
    public static class DataObjectExtension
    {
        public static void UnpackXML<T>(this List<T> entities, XElement xml) where T : IEntity, new()
        {
            string typeName = typeof(T).Name;
            if (xml == null)
            {
                entities = null;
                return;
            }
            entities.Clear();
            entities.AddRange(xml.Elements(typeName).Select(x => CreateAndFillObject<T>(x)).ToList());
        }
        private static T CreateAndFillObject<T>(XElement xml) where T : IEntity, new()
        {
            T entity = new T();
            entity.UnpackXML(xml);
            return entity;
        }
        public static T ToEnum<T>(this object value) where T : struct
        {
            if (DBNull.Value != (value ?? DBNull.Value) && false == string.IsNullOrWhiteSpace(value.ToString()))
            {
                T temp;
                if (Enum.TryParse<T>(value.ToString(), out temp))
                {
                    return temp;
                }
            }
            return default(T);
        }
        public static T ToEnum<T>(this XAttribute instance) where T : struct
        {
            if (null != instance && false == string.IsNullOrWhiteSpace(instance.Value))
            {
                T temp;
                if (Enum.TryParse<T>(instance.Value, out temp))
                {
                    return temp;
                }
            }
            return default(T);
        }
        public static T ToEnum<T>(this XElement instance, string nodeName) where T : struct
        {
            if (null != instance && null != instance.Attribute(nodeName) && false == string.IsNullOrWhiteSpace(instance.Attribute(nodeName).Value))
            {
                T temp;
                if (Enum.TryParse<T>(instance.Attribute(nodeName).Value, out temp))
                {
                    return temp;
                }
            }
            return default(T);
        }

        #region T ToType<T>( Object )

        public static T ToType<T>(this object value, string format = "dd/MM/yyyy")
        {
            if (value == null || value == DBNull.Value) return default(T);
            if (value is string && typeof(T) != typeof(string))
            {
                if (string.IsNullOrWhiteSpace(value.ToString())) return default(T);
            }
            else if (!(value is string) && typeof(T) == typeof(string))
            {
                return (T)(object)value.ToString();
            }
            else if (!(value is T))
            {
                throw new Exception(string.Format("Current value {0} is of type {1} cannot be convert into {2}", value, value.GetType(), typeof(T)));
            }
            else
            {
                return (T)value;
            }
            if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
            {
                bool temp;
                if (bool.TryParse(value.ToString(), out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(byte) || typeof(T) == typeof(byte?))
            {
                byte temp;
                if (byte.TryParse(value.ToString(), out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
            {
                short temp;
                if (short.TryParse(value.ToString(), out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
            {
                int temp;
                if (int.TryParse(value.ToString(), out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
            {
                long temp;
                if (long.TryParse(value.ToString(), out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
            {
                decimal temp;
                if (decimal.TryParse(value.ToString(), out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
            {
                DateTime temp;
                if (DateTime.TryParseExact(value.ToString(), format, CultureInfo.CurrentCulture, DateTimeStyles.None, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(TimeSpan) || typeof(T) == typeof(TimeSpan?))
            {
                TimeSpan temp;
                if (TimeSpan.TryParseExact(value.ToString(), format, CultureInfo.CurrentCulture, TimeSpanStyles.None, out temp))
                {
                    return (T)(object)temp;
                }
            }
            return default(T);
        }
        #endregion

        #region T data<T> (XElement)

        public static T Data<T>(this XElement instance, string nodeName)
        {
            return Data<T>(instance, nodeName, new string[] { "yyyy-MM-ddTHH:mm:ss", "yyyy-MM-ddTHH:mm:ss.fff", "yyyy-MM-dd" });
        }

        public static T Data<T>(this XElement instance, string nodeName, string[] format)
        {
            if (null == instance || null == instance.Attribute(nodeName)) { return default(T); }
            var attribute = instance.Attribute(nodeName);
            if (typeof(T) == typeof(string))
            {
                return (T)(object)attribute.Value;
            }

            if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
            {
                int temp;
                if (int.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
            {
                short temp;
                if (short.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
            {
                double temp;
                if (double.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
            {
                DateTime temp;
                if (DateTime.TryParseExact(attribute.Value, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
            {
                bool temp;
                if (bool.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(byte) || typeof(T) == typeof(byte?))
            {
                byte temp;
                if (byte.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
            {
                long temp;
                if (long.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
            {
                decimal temp;
                if (decimal.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            return default(T);
        }
        #endregion

        #region T ToType<T> (XAttribute)

        public static T ToType<T>(this XAttribute attribute)
        {
            return ToType<T>(attribute, new string[] { "yyyy-MM-ddTHH:mm:ss", "yyyy-MM-ddTHH:mm:ss.fff", "yyyy-MM-dd" });
        }

        public static T ToType<T>(this XAttribute attribute, string[] format)
        {
            if (attribute == null)
            {
                return default(T);
            }
            if (typeof(T) == typeof(string))
            {
                return (T)(object)attribute.Value;
            }
            else if (typeof(T) == typeof(Guid))
            {
                Guid temp = Guid.Empty;
                if (Guid.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
            {
                int temp;
                if (int.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
            {
                short temp;
                if (short.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
            {
                double temp;
                if (double.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
            {
                DateTime temp;
                if (DateTime.TryParseExact(attribute.Value, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
            {
                bool temp;
                if (bool.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(byte) || typeof(T) == typeof(byte?))
            {
                byte temp;
                if (byte.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
            {
                long temp;
                if (long.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            else if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
            {
                decimal temp;
                if (decimal.TryParse(attribute.Value, out temp))
                {
                    return (T)(object)temp;
                }
            }
            return default(T);
        }
        #endregion

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
