using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace Journal2API.Models
{
    public class Log
    { 
    }
    
    public class LogItem : HasTimestamp, IItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public partial class JournalContext : DbContext
    {
        public virtual DbSet<LogItem> LogItems { get; set; }
    }
}