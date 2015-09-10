using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public interface INestable<T>: ISortable<INestable<T>>
    {
        T Parent { get; set; }
    }

    public static class INestableExtension
    {
        public static IQueryable<T> Roots<T>(this INestable<T> nestable) where T:class, INestable<T>
        {
            using (var ctx = new JournalContext())
            {
                return ctx.Set<T>().Where(y => y.Parent == null);
            }
        }

        public static IQueryable<T> Children<T>(this INestable<T> nestable) where T : class, INestable<T>
        {
            using ( var ctx = new JournalContext())
            {
                return ctx.Set<T>().Where(y => y.Parent == nestable);
            } 
        }

        public static void AddChild<T>(this INestable<T> nestable, int position, T node) where T : class, INestable<T>
        {
            using (var ctx = new JournalContext())
            {
                node.Parent = (nestable as T);
                ctx.Set<T>().Add(node);
                ctx.SaveChanges();
            }
        }

        public static void InsertBefore<T>(this INestable<T> nestable, INestable<T> before_this)
            where T : class, INestable<T>
        {
            (nestable as ISortable<INestable<T>>).InsertBefore(before_this as ISortable<INestable<T>>);
            nestable.KeepParent(before_this);
        }

        public static void KeepParent<T>(this INestable<T>  nestable, INestable<T> other)
            where T : class, INestable<T>
        {
            using (var ctx = new JournalContext())
            {
                nestable.Parent = other.Parent;
                var set = ctx.Set<T>();
                set.Add(nestable as T);
                ctx.SaveChanges();
            }
        }

        public static void InsertAfter<T>(this INestable<T> nestable, INestable<T> after_this)
            where T : class, INestable<T>
        {
            (nestable as ISortable<INestable<T>>).InsertAfter(after_this as ISortable<INestable<T>>);
            nestable.KeepParent(after_this);
        }
    }
}