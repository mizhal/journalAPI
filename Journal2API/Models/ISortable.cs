using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public interface ISortable<T> where T : ISortable<T>
    {
        int Position { get; set; }
    }

    public static class ISortableExtensions
    {
        public static void InsertBefore<T>(this ISortable<T> item, ISortable<T> before_this) where T : class, ISortable<T>
        {
            using (var ctx = new JournalContext())
            {
                ISortable<T> prev_element = before_this.Previous();

                int position;
                SortableHelper.InsertBetween(prev_element, before_this, out position);
                item.Position = position;

                var set = ctx.Set<T>();
                set.Add(item as T);

                ctx.SaveChanges();
            }
        }

        public static void InsertAfter<T>(this ISortable<T> item, ISortable<T> after_this) where T : class, ISortable<T>
        {
            using (var ctx = new JournalContext())
            {
                ISortable<T> next_element = after_this.Next();
            
                int position;
                SortableHelper.InsertBetween(after_this, next_element, out position);
                item.Position = position;

                var set = ctx.Set<T>();
                set.Add(item as T);

                ctx.SaveChanges();
            }
        }

        public static void SwapWith<T>(this ISortable<T> item, ISortable<T> other) where T : class, ISortable<T>
        {
            using (var ctx = new JournalContext())
            {
                int pos_this = item.Position;
                int pos_other = other.Position;
                other.Position = pos_this;
                item.Position = pos_other;

                var set = ctx.Set<T>();
                set.Add(other as T);
                set.Add(item as T);
                ctx.SaveChanges();
            }
        }

        public static T Previous<T>(this ISortable<T> item) where T : class, ISortable<T>
        {
            using(var ctx = new JournalContext())
            {
                var found = ctx.Set<T>().OrderBy(r => r.Position).
                    First(r => r.Position < item.Position);
                return found;
            }
        }

        public static T Next<T>(this ISortable<T> item) where T : class, ISortable<T>
        {
            using (var ctx = new JournalContext())
            {
                var found = ctx.Set<T>().OrderBy(r => r.Position).
                    First(r => r.Position > item.Position);
                return found;
            }
        }

        public static bool IsFirst<T>(this ISortable<T> item) where T : class, ISortable<T>
        {
            return item.Previous() == null;
        }

        public static bool IsLast<T>(this ISortable<T> item) where T : class, ISortable<T>
        {
            return item.Next() == null;
        }

        public static void Init<T>(this ISortable<T> item) where T : class, ISortable<T>
        {
            using (var ctx = new JournalContext())
            {
                var after_element = SortableHelper.Last<T>();
                int position;
                SortableHelper.InsertBetween(after_element, null, out position);
                item.Position = position;

                ctx.Set<T>().Add(item as T);
                ctx.SaveChanges();
            }
        }

        static class SortableHelper
        {
            public const int GAP = 100;

            public static ISortable<T> Last<T>() where T : class, ISortable<T>
            {
                using (var ctx = new JournalContext())
                {
                    var set = ctx.Set<T>();
                    return set.OrderByDescending(x => x.Position).First();
                };
            }

            public static void InsertBetween<T>(ISortable<T> first, ISortable<T> second, out int position) where T : class, ISortable<T>
            {
                int second_position;
                int first_position;

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
                    RearrangePositions<T>();
                    InsertBetween(first, second, out position);
                }
            }

            public static void RearrangePositions<T>() where T : class, ISortable<T>
            {
                // Re-allocates positions evenly separated to allow insertions between elements
                // without the necessity to recalculate the positions of next elements 

                // eventualy (when a gap is exhausted) this methods should be called with a cost of O(n)
                // but this is an amortized cost over all insertion costs we saved with this solution

                using (var ctx = new JournalContext())
                {
                    int counter = 1; // it's recommendable to put a gap before the first element too to enable front insertions
                    var set = ctx.Set<T>();

                    if (set.Count() * GAP >= int.MaxValue)
                    {
                        throw new WrapAlert();
                    }

                    foreach (var element in set)
                    {
                        element.Position = counter * GAP;
                        counter++;
                        set.Add(element);
                    }
                    ctx.SaveChanges();
                }
            }
        }

    }

    public class WrapAlert : Exception
    {
        public WrapAlert() : base("Wrap alert")
        {

        }
    }
}