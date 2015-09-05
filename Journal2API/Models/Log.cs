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
        public List<LogItem> items { get; set; }

        public class LogItem : HasTimestamp, Item
        {
            public int Id
            {
                get;
                set;
            }
            public string Text
            {
                get;
                set;
            }
        }

        public partial class Journal2ApiContext: DbContext
        {
            public DbSet<LogItem> LogItems { get; set; }
        }
    }
}