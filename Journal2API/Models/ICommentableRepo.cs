using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal2API.Models
{
    public interface ICommentableRepo<T>: ICrudRepoFor<Comment> where T:IItem
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

                repo.Save(comment);
            }
        }
        
        public static IQueryable<Comment> Comments<T>(this ICommentableRepo<T> repo, T obj)
            where T :IItem
        {
            return repo.All<Comment>()
                .Where(r => r.ClassName == obj.GetType().Name)
                .Where(r => r.ObjectId == obj.Id)
                ;
        }
    }
}
