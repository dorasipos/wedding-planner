using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.WeddingTaskOutcomes
{
    public class ComposedOutcome : WeddingTaskOutcome
    {
        public ComposedOutcome(string takeaway) : base(takeaway)
        {
        }
    }
}
