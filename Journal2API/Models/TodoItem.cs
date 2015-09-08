﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace Journal2API.Models
{
    public class TodoItem : HasTimestamp, IHasWorkflow, Item, Commentable, INestable<TodoItem>
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }

        public TodoItem Parent { get; set; }
        public List<TodoItem> Children { get; set;}

        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get; set; }

        public List<TodoItem> roots()
        {
            throw new NotImplementedException();
        }
    }

    public partial class JournalContext: DbContext
    {
        public virtual DbSet<TodoItem> TodoItems { get; set; }
    }
}