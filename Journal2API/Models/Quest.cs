using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Journal2API.Models
{
    public class Quest : Item, HasTimestamp, IHasWorkflow, Commentable, ISortable<Quest>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(4098)]
        public string Description { get; set; }

        [Required]
        public WorkflowState State { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<QuestSection> Sections { get; set; }

        [Required]
        public int Position { get; set; }

        public interface QuestSection
        {
            string Name { get; set; }
        }

        public class TodoSection : QuestSection
        {
            string QuestSection.Name { get; set; }

            public List<TodoItem> Todos;
        }

    }

    public partial class JournalContext: DbContext {
        public virtual DbSet<Quest> Quests
        {
            get; set;
        }
    }
}