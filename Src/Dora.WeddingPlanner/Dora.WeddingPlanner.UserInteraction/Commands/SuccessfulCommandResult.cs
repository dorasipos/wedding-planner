﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Commands
{
    public class SuccessfulCommandResult<TResult> : CommandResult<TResult>
    {
        private SuccessfulCommandResult()
            : base()
        { }

        public SuccessfulCommandResult(TResult result)
            : base()
        {
            this.Result = result;
            this.Details = result.ToString();
        }

        public override bool IsSuccessful
        {
            get
            {
                return true;
            }
        }
    }
}
