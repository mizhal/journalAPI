using Journal2API.Models.Libs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Journal2API.Models.Auth
{
    public class Role : IItem, HasTimestamp, IParanoid, HasFriendlyId
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }

        public ICollection<User> Users;

        public Role() {
            Users = new HashSet<User>();
        }

        public string GenerateSlug()
        {
            return Slugify.GetInstance().slugify(Name);
        }
    }

    public partial class JournalContext : DbContext
    {
        public virtual DbSet<Role> Roles { get; set; }
    }
}