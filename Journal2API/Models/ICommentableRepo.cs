using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal2API.Models
{
    public interface ICommentableRepo<T>:IRepo where T:IItem
    {
        
    }

    public static class ICommentableRepoExtensions
    {
        public static void AddComment<T>(this ICommentableRepo<T> repo, T obj, Comment comment)
            where T:IItem
        {
            using (var ctx = repo.CurrentContext())
            {
                comment.ClassName = obj.GetType().Name;
                comment.ObjectId = obj.Id;

                var set = ctx.Set<Comment>();
                set.Add(comment);
                ctx.SaveChanges();
            }
        }
        
        public static IQueryable<Comment> Comments<T>(this ICommentableRepo<T> repo, T obj)
            where T :IItem
        {
            using (var ctx = repo.CurrentContext())
            {
                return ctx.Set<Comment>()
                    .Where(r => r.ClassName == obj.GetType().Name)
                    .Where(r => r.ObjectId == obj.Id)
                    ;
            }
        }
    }
}
