using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public interface INestable<T>
    {
        T Parent { get; set; }
        List<T> Children { get; set; }
    }

    public static class INestableExtension
    {
        public static IQueryable<INestable<T>> Roots<T>(this INestable<T> nestable) where T:class
        {
            using (var ctx = new JournalContext())
            {
                return ctx.Set<INestable<T>>().Where(y => y.Parent == null);
            }
        }
    }
}