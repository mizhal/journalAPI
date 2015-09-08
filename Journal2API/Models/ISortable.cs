using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public interface ISortable<T> where T : ISortable<T>
    {
        int Position { get; set; }
    }

    public static class ISortableExtensions
    {
        public static void InsertBefore<T>(this ISortable<T> item, ISortable<T> before_this) where T : ISortable<T>
        {

        }

        public static void InsertAfter<T>(this ISortable<T> item, ISortable<T> after_this) where T : ISortable<T>
        {

        }

        public static T Previous<T>(this ISortable<T> item) where T : class, ISortable<T>
        {
            using(var ctx = new JournalContext())
            {
                var found = ctx.Set<T>().OrderBy(r => (r as T).Position).
                    First(r => (r as T).Position < item.Position);
                return found;
            }
        }

        public static T Next<T>(this ISortable<T> item) where T : class, ISortable<T>
        {
            using (var ctx = new JournalContext())
            {
                var found = ctx.Set<T>().OrderBy(r => (r as T).Position).
                    First(r => (r as T).Position > item.Position);
                return found;
            }
        }
    }
}