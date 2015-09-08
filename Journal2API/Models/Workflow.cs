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
        public int Id { get; set; }
        [Index(IsUnique=true)]
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public virtual List<WorkflowTransition> Transitions { get; set; }
        public virtual List<WorkflowState> States { get; set; }

        private Dictionary<int, List<int>> _CompiledTransitions;
        private Dictionary<string, WorkflowState> _StateIndex;

        public Workflow()
        {
            _CompiledTransitions = new Dictionary<int, List<int>>();
            _StateIndex = new Dictionary<string, WorkflowState>();
        }

        public bool validTransition(int origin_status, int final_status)
        {
            if (_CompiledTransitions[origin_status].Contains(final_status))
                return true; // transicion definida en el workflow como valida
            else
                return false; // transicion no definida o invalida
        }

        public List<int> getValidTransitions(int status)
        {
            return _CompiledTransitions[status];
        }

        public void defineState(string name)
        {
            if (_StateIndex.ContainsKey(name))
                throw new Exception($"Workflow state {name} already exists");
            else
            {
                var state = new WorkflowState { Name = name, Workflow = this };
                States.Add(state);
                _StateIndex[name] = state;
            }
        }

        public void defineTransition(string name_from, string name_to)
        {
            var from = _StateIndex[name_from];
            var to = _StateIndex[name_to];
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
        public string ClassName { get; set; }
        [Index("Definition", 1, IsUnique = true)]
        public Workflow Workflow { get; set; }
    }

    public partial class JournalContext: DbContext
    {
        public virtual List<WorkflowTransition> WorkflowItems { get; set; }
        public virtual List<WorkflowDefinition> WorkflowDefinitions { get; set; }
        public virtual List<WorkflowState> WorkflowStates { get; set; }
        public virtual List<Workflow> Workflows { get; set; }
    }
}