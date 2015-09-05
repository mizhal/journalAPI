using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public class HasTimestamp
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public interface Item
    {
        int Id{ get; set;}
    }

    public interface Commentable
    {

    }



}