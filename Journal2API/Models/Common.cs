using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;

namespace Journal2API.Models
{
    public interface HasTimestamp
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }

    public interface IItem
    {
        ulong Id { get; set; }
    }

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class JournalContext : DbContext
    {
        public JournalContext() : base("name=JournalContext") {
            Database.SetInitializer<JournalContext>(null);
            Configuration.ProxyCreationEnabled = true;
        }

    }
}