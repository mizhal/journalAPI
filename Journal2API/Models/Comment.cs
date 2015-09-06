using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Journal2API.Models
{
    public class Comment : HasTimestamp, Item
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public partial class JournalContext: DbContext
    {
        public virtual DbSet<Comment> Comments { get; set; }
    }
}