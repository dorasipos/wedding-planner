using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.WeddingTasks.Predefined
{
    public class PlanWeddingReceptionPartyTask : PredefinedWeddingTask
    {
        public PlanWeddingReceptionPartyTask()
            : base("Plan the Wedding Reception Party")
        { }

        public override string Id
        {
            get
            {
                return "PlanWeddingReceptionPartyWeddingTask";
            }
        }
    }
}
