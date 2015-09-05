using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public class Workflow
    {
        public string Name { get; set; }
        public List<string> States { get; set; }
        public Dictionary<int, List<int>> Transitions { get; set; }
        public Log log { get; set; }

        public bool doTransition(int origin_status, int final_status)
        {
            if (Transitions[origin_status].Contains(final_status))
                return true; // transicion definida en el workflow como valida
            else
                return false; // transicion no definida o invalida
        }
    }
}