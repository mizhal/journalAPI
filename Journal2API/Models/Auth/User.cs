using Journal2API.Models.Libs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Journal2API.Models.Auth
{
    public class User : IItem, HasTimestamp, HasFriendlyId, IParanoid
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public string Email { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }

        public string Slug { get; set; }

        public ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
        }

        public string GenerateSlug()
        {
            return Slugify.GetInstance().slugify(FullName);
        }
    }

    public partial class JournalContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
    }
}