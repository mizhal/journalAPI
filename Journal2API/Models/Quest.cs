using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public class Quest : HasTimestamp, Item, Commentable
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<QuestSection> Sections { get; set; }

        public Workflow workflow { get; set; }

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
}