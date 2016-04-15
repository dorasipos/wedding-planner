using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.WeddingTasks.Predefined
{
    public class PlanReligiousCeremonyTask : PredefinedWeddingTask
    {
        public PlanReligiousCeremonyTask()
            : base("Plan the Religious Ceremony")
        { }

        public override string Id
        {
            get
            {
                return "PlanReligiousCeremonyWeddingTask";
            }
        }
    }
}
