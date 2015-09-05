using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Journal2API.Models
{
    public abstract class HasTimestamp
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public interface Item
    {
        int Id { get; set; }
    }

    public interface Commentable
    {

    }

    public interface Nestable<T>
    {
        T Parent { get; set; }
        List<T> Children { get; set; }

        List<T> roots();
    }

    public partial class Journal2ApiContext : DbContext
    {
        public Journal2ApiContext() : base("name=JournalContext") { }

    }
}