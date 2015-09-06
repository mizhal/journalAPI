using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;

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

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class JournalContext : DbContext
    {
        public JournalContext() : base("name=JournalContext") {
            Database.SetInitializer<JournalContext>(null);
        }

    }
}