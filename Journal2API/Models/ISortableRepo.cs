using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public interface ISortableRepo<T>: IRepo where T:ISortable, IItem
    {
    }

    public static class ISortableExtensions
    {
        public const int GAP = 100;

        public static void InsertBefore<T>(this ISortableRepo<T> repo, T item, T before_this) where T : class, ISortable, IItem
        {
            var ctx = repo.CurrentContext();
                
            T prev_element = repo.Previous(before_this);

            ulong position;
            repo.InsertBetween(ref prev_element, ref before_this, out position);
            item.Position = position;

            var set = ctx.Set<T>();
            set.Add(item);  
        }

        public static void InsertAfter<T>(this ISortableRepo<T> repo, T item, T after_this) where T : class, ISortable, IItem
        {
            var ctx = repo.CurrentContext();

            T next_element = repo.Next(after_this);
            
            ulong position;
            repo.InsertBetween(ref after_this, ref next_element, out position);
            item.Position = position;

            var set = ctx.Set<T>();
            set.Add(item);
            ctx.SaveChanges();
        }

        public static void SwapWith<T>(this ISortableRepo<T> repo, T item, T other) where T : class, ISortable, IItem
        {
            var ctx = repo.CurrentContext();
            var pos_this = item.Position;
            var pos_other = other.Position;
            other.Position = pos_this;
            item.Position = pos_other;

            var set = ctx.Set<T>();
            set.Add(other);
            set.Add(item);
        }

        public static T Previous<T>(this ISortableRepo<T> repo, T item) where T : class, ISortable, IItem
        {
            var ctx = repo.CurrentContext();
            var found = ctx.Set<T>().OrderByDescending(r => r.Position)
                .FirstOrDefault(r => r.Position < item.Position);
            return found;
        }

        public static T Next<T>(this ISortableRepo<T> repo, T item) where T : class, ISortable, IItem
        {
            var ctx = repo.CurrentContext();
            var found = ctx.Set<T>().OrderBy(r => r.Position)
                .FirstOrDefault(r => r.Position > item.Position);
            return found;
        }

        public static bool IsFirst<T>(this ISortableRepo<T> repo, T item) where T : class, ISortable, IItem
        {
            return repo.Previous(item) == null;
        }

        public static bool IsLast<T>(this ISortableRepo<T> repo, T item) where T : class, ISortable, IItem
        {
            return repo.Next(item) == null;
        }

        public static void InitSortable<T>(this ISortableRepo<T> repo, T item) where T : class, ISortable, IItem
        {
            var ctx = repo.CurrentContext();
            var after_element = repo.Last<T>();
            ulong position;
            T nullref = null;
            repo.InsertBetween(ref after_element, ref nullref, out position);
            item.Position = position;

            ctx.Set<T>().Add(item);
        }

        public static T Last<T>(this ISortableRepo<T> repo) where T: class, ISortable, IItem
        {
            var ctx = repo.CurrentContext();
            var set = ctx.Set<T>();
            return set.OrderByDescending(x => x.Position).FirstOrDefault();
        }

        public static void InsertBetween<T>(this ISortableRepo<T> repo, ref T first, ref T second, out ulong position) where T : class, ISortable, IItem
        {
            ulong second_position;
            ulong first_position;

            if(first == null)
            {
                first_position = 0;
                second_position = second.Position;
            } else if (second == null)
            {
                first_position = first.Position;
                second_position = first_position + GAP;
            } else
            {
                first_position = first.Position;
                second_position = second.Position;
            }

            if(second_position >= int.MaxValue) throw new WrapAlert();

            if (second_position - first_position >= 2)
            {
                position = first_position + (second_position - first_position) / 2;
            } else
            {
                repo.RearrangePositions<T>(ref first, ref second);
                repo.InsertBetween(ref first, ref second, out position);
            }
        }

        public static void RearrangePositions<T>(this ISortableRepo<T> repo, ref T first, ref T second) 
            where T : class, ISortable, IItem
        {
            // Re-allocates positions evenly separated to allow insertions between elements
            // without the necessity to recalculate the positions of next elements 

            // eventualy (when a gap is exhausted) this methods should be called with a cost of O(n)
            // but this is an amortized cost over all insertion costs we saved with this solution

            var ctx = repo.CurrentContext();

            ulong counter = 1; // it's recommendable to put a gap before the first element too to enable front insertions
            var set = ctx.Set<T>();

            if (set.Count() * GAP >= int.MaxValue)
            {
                throw new WrapAlert();
            }

            var all = from el in ctx.Set<T>()
                        select el;
            foreach (T element in all)
            {
                element.Position = counter * GAP;
                counter++;
            }
            ctx.Configuration.ValidateOnSaveEnabled = false;
            ctx.SaveChanges();
            ctx.Configuration.ValidateOnSaveEnabled = true;
            first = set.Find(first.Id);
            second = set.Find(second.Id);
        }
    }

    public class WrapAlert : Exception
    {
        public WrapAlert() : base("Wrap alert")
        {

        }
    }
}