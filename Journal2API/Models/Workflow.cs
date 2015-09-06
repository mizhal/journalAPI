using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public class Workflow
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
}