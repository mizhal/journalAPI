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
        public static void InsertBefore<T>(this ISortable<T> item, ISortable<T> before_this) where T : class, ISortable<T>
        {
            using (var ctx = new JournalContext())
            {
                int before_pos = before_this.Position;
                item.Position = before_pos;

                before_this.Position++;
                var set = ctx.Set<T>();
                set.Add(item as T);
                set.Add(before_this as T);
                var next_items = set.Where(x => before_this.Position >= item.Position);
                foreach (var it in next_items)
                {
                    it.Position++;
                    set.Add(it as T);
                }

                ctx.SaveChanges();
            }
        }

        public static void InsertAfter<T>(this ISortable<T> item, ISortable<T> after_this) where T : class, ISortable<T>
        {
            using (var ctx = new JournalContext())
            {
                int after_pos = after_this.Position;
                item.Position = after_pos + 1;

                after_this.Position++;
                var set = ctx.Set<T>();
                set.Add(item as T);
                set.Add(after_this as T);
                var next_items = set.Where(x => x.Position >= item.Position);
                foreach(var it in next_items)
                {
                    it.Position++;
                    set.Add(it as T);
                }

                ctx.SaveChanges();
            }
        }

        public static void SwapWith<T>(this ISortable<T> item, ISortable<T> other) where T : class, ISortable<T>
        {
            using (var ctx = new JournalContext())
            {
                int pos_this = item.Position;
                int pos_other = other.Position;
                other.Position = pos_this;
                item.Position = pos_other;

                var set = ctx.Set<T>();
                set.Add(other as T);
                set.Add(item as T);
                ctx.SaveChanges();
            }
        }

        public static T Previous<T>(this ISortable<T> item) where T : class, ISortable<T>
        {
            using(var ctx = new JournalContext())
            {
                var found = ctx.Set<T>().OrderBy(r => r.Position).
                    First(r => r.Position < item.Position);
                return found;
            }
        }

        public static T Next<T>(this ISortable<T> item) where T : class, ISortable<T>
        {
            using (var ctx = new JournalContext())
            {
                var found = ctx.Set<T>().OrderBy(r => r.Position).
                    First(r => r.Position > item.Position);
                return found;
            }
        }
    }
}