using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal2API.Models
{
    public interface ICrudRepoFor<T> : IRepo where T : IItem
    {

    }

    public static class ICrudRepoForExtensions
    {
        public static T Get<T>(this ICrudRepoFor<T> repo, ulong Id)
            where T : class, IItem
        {
            return repo.All()
                .Where(x => x.Id == Id)
                .FirstOrDefault()
                ;
        }

        public static ulong Save<T>(this ICrudRepoFor<T> repo, T item)
            where T : class, IItem
        {
            var ctx = repo.CurrentContext();
            var set = ctx.Set<T>();
            set.Add(item);
            ctx.SaveChanges();
            return item.Id;
        }
        public static ulong Update<T>(this ICrudRepoFor<T> repo, T item)
            where T : class, IItem
        {
            var ctx = repo.CurrentContext();
            var set = ctx.Set<T>();
            set.Add(item);
            ctx.SaveChanges();
            return item.Id;
        }
        public static ulong SaveOrUpdate<T>(this ICrudRepoFor<T> repo, T item)
            where T : class, IItem
        {
            var ctx = repo.CurrentContext();
            var set = ctx.Set<T>();
            set.Add(item);
            ctx.SaveChanges();
            return item.Id;
        }

        public static IQueryable<T> All<T>(this ICrudRepoFor<T> repo)
            where T : class, IItem
        {
            var ctx = repo.CurrentContext();
            return ctx.Set<T>();
        }

        public static void Delete<T>(this ICrudRepoFor<T> repo, T item)
            where T : class, IItem
        {
            var ctx = repo.CurrentContext();
            var set = ctx.Set<T>();
            set.Remove(item);
            ctx.SaveChanges();
        }

        public static void Delete<T>(this ICrudRepoFor<T> repo, ulong Id)
            where T : class, IItem
        {
            var item = repo.Get(Id);
            repo.Delete(item);
        }
    }
}
