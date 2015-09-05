using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public class TodoItem : HasTimestamp, Item, Commentable
    {
        public Workflow workflow { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
    }
}