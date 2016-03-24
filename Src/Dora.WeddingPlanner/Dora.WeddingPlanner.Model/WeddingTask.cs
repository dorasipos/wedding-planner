using Dora.WeddingPlanner.Model.WeddingTaskOutcomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dora.WeddingPlanner.Model
{
    public class WeddingTask
    {
        private WeddingTaskOutcome outcome = new NoOutcome();

        public WeddingTaskOutcome Outcome
        {
            get
            {
                return this.outcome;
            }
        }
    }
}
