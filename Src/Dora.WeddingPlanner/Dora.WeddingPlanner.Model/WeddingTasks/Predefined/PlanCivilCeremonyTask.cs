using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.WeddingTasks.Predefined
{
    public class PlanCivilCeremonyTask : PredefinedWeddingTask
    {
        public PlanCivilCeremonyTask()
            : base("Plan the Civil Ceremony")
        { }

        public override string Id
        {
            get
            {
                return "PlanCivilCeremonyWeddingTask";
            }
        }
    }
}
