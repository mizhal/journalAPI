using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public class Comment : HasTimestamp, Item
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}