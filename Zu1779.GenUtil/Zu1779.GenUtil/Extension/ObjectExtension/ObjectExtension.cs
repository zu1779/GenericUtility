using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Zu1779.GenUtil.Extension.ObjectExtension
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Check if parameter is null or default. <see cref="https://stackoverflow.com/questions/6553183/check-to-see-if-a-given-object-reference-or-value-type-is-equal-to-its-default"/>
        /// </summary>
        /// <remarks>Modified for consider <code>string.Empty</code> as default.</remarks>
        public static bool IsNullOrDefault<T>(this T argument)
        {
            if (argument is string && (argument as string) == string.Empty) return true;
            // deal with normal scenarios
            if (argument == null) return true;
            if (object.Equals(argument, default(T))) return true;

            // deal with non-null nullables
            Type methodType = typeof(T);
            if (Nullable.GetUnderlyingType(methodType) != null) return false;

            // deal with boxed value types
            Type argumentType = argument.GetType();
            if (argumentType.IsValueType && argumentType != methodType)
            {
                object obj = Activator.CreateInstance(argument.GetType());
                return obj.Equals(argument);
            }

            return false;
        }

        public static T As<T>(this object obj) => obj is T t ? t : default;

        public static IEnumerable<T> ToEnumerable<T>(this T obj) => new T[] { obj };
        public static IQueryable<T> ToQueryable<T>(this T obj) => obj.ToEnumerable().AsQueryable();
    }
}
