using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction.Commands;
using Dora.WeddingPlanner.UserInteraction.Queries;
using Dora.WeddingPlanner.Tracing;

namespace Dora.WeddingPlanner.UserInteraction
{
    internal static class CommandAndQueryRunner
    {
        public static CommandResult<TResult> Run<TResult>(ImAnInteractionCommand<TResult> command)
        {
            Exception exception;
            TResult result;

            if (!new Func<TResult>(() => command.Execute()).Try(out result, out exception))
            {
                return new ExceptionCommandResult<TResult>(exception);
            }

            return new SuccessfulCommandResult<TResult>(result);
        }

        public static QueryResult<TResult> Query<TResult, TParameter>(ImAQuery<TResult, TParameter> query, TParameter parameter)
        {
            Exception exception;
            TResult result;

            if (!new Func<TResult>(() => query.Query(parameter)).Try(out result, out exception))
            {
                return new ExceptionQueryResult<TResult>(exception);
            }

            return new SuccessfulQueryResult<TResult>(result);
        }
    }
}
