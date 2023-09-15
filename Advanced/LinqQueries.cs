using System;
using System.Collections.Generic;

namespace Advanced
{
    public static class LinqQueries
    {
        public static void WhereCondition()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var newItems = items.NewWhere(x => x % 2 == 0);
            foreach (var item in newItems)
            {
                Console.WriteLine(item);
            }
        }
    }

    public static class IEnumerableExtension
    {
        public static IEnumerable<T> NewWhere<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var list = new List<T>();
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    //list.Add(item);
                    yield return item;
                }
            }
            // return list;
        }
    }
}