using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction.Commands;
using Dora.WeddingPlanner.UserInteraction.Queries;
using Dora.WeddingPlanner.Tracing;
using NLog;

namespace Dora.WeddingPlanner.UserInteraction
{
    internal static class CommandAndQueryRunner
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public static CommandResult<TResult> Run<TResult>(ImAnInteractionCommand<TResult> command)
        {
            Exception exception;
            TResult result;

            if (!Trace.Able(command.Execute).Try(out result, out exception))
            {
                log.Error("Error running command {1}{0}Details{0}========={0}{2}{0}{3}", Environment.NewLine, command, exception.Message, exception.StackTrace);
                return new ExceptionCommandResult<TResult>(exception);
            }

            return new SuccessfulCommandResult<TResult>(result);
        }

        public static QueryResult<TResult> Query<TResult, TParameter>(ImAQuery<TResult, TParameter> query, TParameter parameter)
        {
            Exception exception;
            TResult result;

            if (!Trace.Able(query.Query, parameter).Try(out result, out exception))
            {
                log.Error("Error running query {1}{0}Details{0}========={0}{2}{0}{3}", Environment.NewLine, query, exception.Message, exception.StackTrace);
                return new ExceptionQueryResult<TResult>(exception);
            }

            return new SuccessfulQueryResult<TResult>(result);
        }
    }
}
