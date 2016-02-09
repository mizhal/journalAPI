using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal2API.Models
{
    public interface ICrudRepoFor<T> : IRepo where T : IItem, HasTimestamp
    {

    }

    public static class ICrudRepoForExtensions
    {
        public static T Create<T>(this ICrudRepoFor<T> repo)
            where T : class, IItem, HasTimestamp
        {
            var ctx = repo.CurrentContext();
            var set = ctx.Set<T>();
            var new_ = set.Create();
            new_.CreatedAt = DateTime.Now;
            return new_;
        }

        public static T Get<T>(this ICrudRepoFor<T> repo, long Id)
            where T : class, IItem, HasTimestamp
        {
            return repo.All()
                .Where(x => x.Id == Id)
                .FirstOrDefault()
                ;
        }

        public static long Save<T>(this ICrudRepoFor<T> repo, T item)
            where T : class, IItem, HasTimestamp
        {
            var ctx = repo.CurrentContext();
            var set = ctx.Set<T>();
            item.UpdatedAt = DateTime.Now;
            set.Add(item);
            ctx.SaveChanges();
            set.Attach(item);
            return item.Id;
        }
        public static long Update<T>(this ICrudRepoFor<T> repo, T item)
            where T : class, IItem, HasTimestamp
        {
            var ctx = repo.CurrentContext();
            var set = ctx.Set<T>();
            item.UpdatedAt = DateTime.Now;
            ctx.SaveChanges();
            return item.Id;
        }
        public static long SaveOrUpdate<T>(this ICrudRepoFor<T> repo, T item)
            where T : class, IItem, HasTimestamp
        {
            if (item.Id > 0)
                repo.Update(item);
            else
                repo.Save(item);
            return item.Id;
        }

        public static IQueryable<T> All<T>(this ICrudRepoFor<T> repo)
            where T : class, IItem, HasTimestamp
        {
            var ctx = repo.CurrentContext();
            return ctx.Set<T>();
        }

        public static void Delete<T>(this ICrudRepoFor<T> repo, T item)
            where T : class, IItem, HasTimestamp
        {
            var ctx = repo.CurrentContext();
            var set = ctx.Set<T>();
            set.Remove(item);
            ctx.SaveChanges();
        }

        public static void Delete<T>(this ICrudRepoFor<T> repo, long Id)
            where T : class, IItem, HasTimestamp
        {
            var item = repo.Get(Id);
            repo.Delete(item);
        }

        public static bool Exists<T>(this ICrudRepoFor<T> repo, long Id)
            where T : class, IItem, HasTimestamp
        {
            return repo.All()
                .Where(x => x.Id == Id)
                .Any()
                ;
        }

        public static T WhoIs<T>(this ICrudRepoFor<T> repo, long Id)
            where T : class, IItem, HasTimestamp
        {
            return repo.All()
                .Where(x => x.Id == Id)
                .FirstOrDefault()
                ;
        }
    }
}
