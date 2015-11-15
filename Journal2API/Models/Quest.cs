using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Journal2API.Models
{
    public class Quest : IItem, HasTimestamp, IHasWorkflow, ICommentable, ISortable<Quest>
    {

        #region "Campos"
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
        #endregion

        #region Operadores de comparacion
        public override bool Equals(object obj)
        {
            if (obj is Quest)
            {
                var obj_ = obj as Quest;
                return obj_.Id == this.Id;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
        #endregion

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