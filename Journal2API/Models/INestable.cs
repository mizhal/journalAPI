using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public interface INestable<T>
    {
        T Parent { get; set; }
    }

    public static class INestableExtension
    {
        public static IQueryable<T> Roots<T>(this INestable<T> nestable) where T:class
        {
            using (var ctx = new JournalContext())
            {
                return ctx.Set<T>().Where(y => (y as INestable<T>).Parent == null);
            }
        }

        public static IQueryable<T> Children<T>(this INestable<T> nestable) where T : class
        {
            using ( var ctx = new JournalContext())
            {
                return ctx.Set<T>().Where(y => (y as INestable<T>).Parent == nestable);
            } 
        }
    }
}