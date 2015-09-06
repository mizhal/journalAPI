using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Journal2API.Models
{
    public interface HasTimestamp
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }

    public interface HasWorkflow
    {
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

    public partial class JournalContext : DbContext
    {
        public JournalContext() : base("name=JournalContext") { }

    }
}