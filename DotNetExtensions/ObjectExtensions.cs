using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNetExtensions
{
    public static class ObjectExtensions
    {
        public static bool In<T>(this T source, params T[] list)
        {
// ReSharper disable CompareNonConstrainedGenericWithNull
            if (source == null) throw new ArgumentNullException("source");
// ReSharper restore CompareNonConstrainedGenericWithNull
            return list.Contains(source);
        }

        public static bool NotNullAndIn<T>(this T source, params T[] list)
        {
            if (source == null)
            {
                return false;
            }
            return source.In(list);
        }

        public static Dictionary<string,object> ReflectToDictionary<T>(this T source)
        {
            var dictionary = new Dictionary<string, object>();
            var properties = typeof (T).GetProperties();
            foreach (var propertyInfo in properties)
            {
                dictionary.Add(propertyInfo.Name,propertyInfo.GetValue(source,null));
            }
            return dictionary;
        }

        public static string ToStringOrNull(this object @object)
        {
            string @string = null;
            if (@object != null)
            {
                @string = @object.ToString();
            }
            return @string;
        }
    }
}