using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Journal2API.Models
{
    public class Workflow
    {
        [Key]
        public int Id { get; set; }
        [Index(IsUnique=true)]
        [MaxLength(64)]
        [Required]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public virtual ICollection<WorkflowTransition> Transitions { get; set; }
        public virtual ICollection<WorkflowState> States { get; set; }

        public Workflow()
        {
            States = new HashSet<WorkflowState>();
            Transitions = new HashSet<WorkflowTransition>();
        }

        public bool validTransition(int origin_status, int final_status)
        {
            return false; // transicion no definida o invalida
        }

        public List<int> getValidTransitions(int status)
        {
            return new List<int>();
        }

        public void defineState(string name)
        {
            if (States.Where(r => r.Name == name).Any())
                throw new Exception($"Workflow state {name} already exists");
            else
            {
                var state = new WorkflowState { Name = name, Workflow = this };
                States.Add(state);
            }
        }

        public WorkflowState getState(string name)
        {
            return States.First(r => r.Name == name);
        }

        public void defineTransition(string name_from, string name_to)
        {
            var from = States.First(x => x.Name == name_from);
            var to = States.First(x => x.Name == name_to);
            var transition = new WorkflowTransition { Origin = from, Destination = to, Workflow = this };
            Transitions.Add(transition);
        }
    }

    public class WorkflowState
    {
        public int Id { get; set; }
        [MaxLength(128)]
        [Index("StateName", 0, IsUnique=true)]
        public string Name { get; set; }
        [Index("StateName", 1, IsUnique = true)]
        public Workflow Workflow { get; set; }
    }

    public class WorkflowTransition
    {
        public int Id { get; set; }
        [Index("Transition", 0, IsUnique = true)]
        public WorkflowState Origin { get; set; }
        [Index("Transition", 1, IsUnique = true)]
        public WorkflowState Destination { get; set; }
        [Index("Transition", 2, IsUnique = true)]
        public Workflow Workflow { get; set; }
    }

    public class WorkflowDefinition
    {
        public int Id { get; set; }
        [Index("Definition", 0, IsUnique = true)]
        [MaxLength(128)]
        public string ClassName { get; set; }
        [Index("Definition", 1, IsUnique = true)]
        public Workflow Workflow { get; set; }
        }

    public partial class JournalContext: DbContext
    {
        public virtual DbSet<WorkflowTransition> WorkflowItems { get; set; }
        public virtual DbSet<WorkflowDefinition> WorkflowDefinitions { get; set; }
        public virtual DbSet<WorkflowState> WorkflowStates { get; set; }
        public virtual DbSet<Workflow> Workflows { get; set; }
    }
}