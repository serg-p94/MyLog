using System;
using System.Collections.Generic;

namespace MyLog.Core.Extensions
{
    public static class LinqExtension
    {
        public static void ForEach<TItem>(this IEnumerable<TItem> items, Action<TItem> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}
