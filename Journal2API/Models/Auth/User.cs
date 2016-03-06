using Journal2API.Models.Libs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Journal2API.Models.Auth
{
    public class User : IdentityUser, HasTimestamp, HasFriendlyId
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public string Login { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        
        public string Slug { get; set; }

        public User() { }

        public User(string login): base(login)
        {
            Login = login;
            Slug = GenerateSlug();
            Id = Slug;
        }

        public string GenerateSlug()
        {
            return Slugify.GetInstance().slugify(FullName);
        }
    }

    public class Claim: IdentityUserClaim
    {
        public Claim(string user_id, string claim_type, string claim_value)
        {
            UserId = user_id;
            ClaimType = claim_type;
            ClaimValue = claim_value;
        }
    }

    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext() : base("name=JournalContext") {
            Database.SetInitializer<JournalContext>(null);
            Configuration.ProxyCreationEnabled = true;
        }
    }
}

