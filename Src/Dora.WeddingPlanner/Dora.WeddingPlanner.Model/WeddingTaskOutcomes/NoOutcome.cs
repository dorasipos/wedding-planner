﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.WeddingTaskOutcomes
{
    public class NoOutcome : WeddingTaskOutcome
    {
        public NoOutcome() : base("Nothing")
        {
        }

        public override bool IsClosed()
        {
            return false;
        }
    }
}
