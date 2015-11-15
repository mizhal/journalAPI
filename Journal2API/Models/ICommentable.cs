using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal2API.Models
{
    public interface ICommentable: IItem
    {

    }

    public static class ICommentableExtension
    {
        public static void AddComment(this ICommentable obj, Comment comment)
        {
            using (var ctx = new JournalContext())
            {
                comment.ClassName = obj.GetType().Name;
                comment.ObjectId = obj.Id;

                ctx.Comments.Add(comment);
                ctx.SaveChanges();
            }
        }

        public static IQueryable<Comment> Comments(this ICommentable obj)
        {
            using (var ctx = new JournalContext())
            {
                return ctx.Comments.Where(r => r.ClassName == obj.GetType().Name && r.ObjectId == obj.Id);
            }
        }
    }
}
