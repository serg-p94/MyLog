using System;
using System.Linq;

namespace MyLog.Core.Extensions
{
    public static class ReflectionExtension
    {
        public static bool Implements<TInterface>(this Type type)
        {
            return type.GetInterfaces().Contains(typeof(TInterface));
        }
    }
}
