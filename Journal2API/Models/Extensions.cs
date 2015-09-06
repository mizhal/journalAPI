using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    namespace Extensions
    {
        public static class WorkflowExtension
        {
            public static Workflow Workflow(this HasWorkflow item)
            {
                using (var ctx = new JournalContext())
                {
                    var def = ctx.WorkflowDefinitions.Find(r => r.ClassName == item.GetType().Name);
                    if (def != null)
                    {
                        return def.Workflow;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}