﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Commands
{
    public class ExceptionCommandResult<TResult> : CommandResult<TResult>
    {
        private readonly Exception exception;

        public ExceptionCommandResult(Exception ex)
        {
            this.exception = ex;
            this.Details = string.Format("{0}{1}{1}Stack Trace:{1}==========={1}{2}", this.exception.Message, Environment.NewLine, this.exception.StackTrace);
        }

        public override bool IsSuccessful
        {
            get
            {
                return false;
            }
        }
    }
}
