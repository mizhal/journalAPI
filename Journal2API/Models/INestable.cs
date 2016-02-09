using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public interface INestable<T>: ISortable, IItem
    {
        T Parent { get; set; }
    }

    public interface INestableRepo<T>: ICrudRepoFor<T>, ISortableRepo<T> where T : INestable<T>, HasTimestamp
    {

    }

    public static class INestableRepoExtension
    {
        public static IQueryable<T> Roots<T>(this INestableRepo<T> repo, T nestable) where T:class, INestable<T>, HasTimestamp
        {
            return repo.All<T>().Where(y => y.Parent == null);
        }

        public static IQueryable<T> Children<T>(this INestableRepo<T> repo, T nestable) where T : class, INestable<T>, HasTimestamp
        {
            return repo.All<T>().Where(y => y.Parent == nestable);
        }

        public static void AddChild<T>(this INestableRepo<T> repo, T nestable, T node) where T : class, INestable<T>, HasTimestamp
        {
            node.Parent = nestable;
            repo.SaveOrUpdate(node);
        }

        public static void InsertBefore<T>(this INestableRepo<T> repo, T nestable, T before_this)
            where T : class, INestable<T>, HasTimestamp
        {
            repo.InsertBefore(nestable, before_this);
            repo.KeepParent(nestable, before_this);
        }

        public static void KeepParent<T>(this INestableRepo<T> repo, T nestable, T other)
            where T : class, INestable<T>, HasTimestamp
        {
            nestable.Parent = other.Parent;
            repo.SaveOrUpdate(nestable);
        }

        public static void InsertAfter<T>(this INestableRepo<T> repo, T nestable, T after_this)
            where T : class, INestable<T>, HasTimestamp
        {
            repo.InsertAfter(nestable, after_this);
            repo.KeepParent(nestable, after_this);
        }
    }
}