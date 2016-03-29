using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Journal2API.Models
{
    public class TodoItem : HasTimestamp, IParanoid, IHasWorkflow, IItem, INestable<TodoItem>
    {
        [Key]
        public long Id { get; set; }
        public WorkflowState State { get; set; }
        public string Title { get; set; }

        public TodoItem Parent { get; set; }

        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get; set; }

        public long Position { get; set; }

        public DateTime? DeletedAt { get; set; }
    }

    public partial class JournalContext
    {
        public virtual DbSet<TodoItem> TodoItems { get; set; }
    }
}