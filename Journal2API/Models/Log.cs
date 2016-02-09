using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Journal2API.Models
{
    public class Log
    { 
    }
    
    public class LogItem : HasTimestamp, IItem
    {
        [Key]
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public partial class JournalContext : DbContext
    {
        public virtual DbSet<LogItem> LogItems { get; set; }
    }
}