using System;
using System.Linq;
using System.Reflection;

namespace MyLog.Core.Extensions
{
    public static class ReflectionExtension
    {
        public static bool Implements<TInterface>(this Type type)
        {
            return type.GetInterfaces().Contains(typeof(TInterface));
        }

        public static bool HasAttribute<TAttribute>(this PropertyInfo pi) where TAttribute : Attribute
        {
            return pi.CustomAttributes.Any(attr => attr.AttributeType == typeof(TAttribute));
        }
    }
}
