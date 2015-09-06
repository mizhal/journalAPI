using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Journal2API.Models
{
    public class Workflow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private List<string> States { get; set; }
        private Dictionary<int, List<int>> Transitions { get; set; }
        private Log log { get; set; }

        public bool validTransition(int origin_status, int final_status)
        {
            if (Transitions[origin_status].Contains(final_status))
                return true; // transicion definida en el workflow como valida
            else
                return false; // transicion no definida o invalida
        }

        public List<int> getValidTransitions(int status)
        {
            return Transitions[status];
        }
    }

    public class WorkflowState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Workflow Workflow { get; set; }
    }

    public class WorkflowTransition
    {
        public int Id { get; set; }
        public int Origin { get; set; }
        public int Destination { get; set; }
        public Workflow Workflow { get; set; }
    }

    public class WorkflowDefinition
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public Workflow Workflow { get; set; }
    }

    public partial class JournalContext: DbContext
    {
        public virtual List<WorkflowTransition> WorkflowItems { get; set; }
        public virtual List<WorkflowDefinition> WorkflowDefinitions { get; set; }
        public virtual List<WorkflowState> WorkflowStates { get; set; }
    }
}