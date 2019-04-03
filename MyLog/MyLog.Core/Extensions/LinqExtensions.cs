using System;
using System.Collections.Generic;

namespace MyLog.Core.Extensions
{
    public static class LinqExtensions
    {
        public static void ForEach<TItem>(this IEnumerable<TItem> items, Action<TItem> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public static void ForEach<TItem>(this IEnumerable<TItem> items, Action<TItem, int> action)
        {
            var i = 0;
            items.ForEach(item => action(item, i++));
        }
    }
}
