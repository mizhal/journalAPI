using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal2API.Models
{
    public interface ICrudRepoParanoidFor<T> : ICrudRepoFor<T> where T : IParanoid
    {

    }

    public static class ICrudRepoParanoidForExtensions
    {
        public static T Get<T>(this ICrudRepoParanoidFor<T> repo, long Id)
            where T: class, IParanoid
        {
            return repo.All()
                .Where(x => x.Id == Id)
                .FirstOrDefault()
                ;
        }

        public static IQueryable<T> All<T>(this ICrudRepoParanoidFor<T> repo)
            where T : class, IParanoid
        {
            var ctx = repo.CurrentContext();
            return ctx.Set<T>().Where(x => x.DeletedAt != null);
        }

        public static void Delete<T>(this ICrudRepoParanoidFor<T> repo, T item)
            where T : class, IParanoid
        {
            var ctx = repo.CurrentContext();
            item.DeletedAt = DateTime.Now;
            var set = ctx.Set<T>();
            set.Add(item);
            ctx.SaveChanges();
        }
    }
}
