using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction.Commands;
using Dora.WeddingPlanner.UserInteraction.Queries;

namespace Dora.WeddingPlanner.UserInteraction
{
    internal static class CommandAndQueryRunner
    {
        public static CommandResult<TResult> Run<TResult>(ImAnInteractionCommand<TResult> command)
        {
            Exception exception;
            TResult result;
            if (!TryRunCommand(command, out result, out exception))
            {
                return new ExceptionCommandResult<TResult>(exception);
            }
            return new SuccessfulCommandResult<TResult>(result);
        }

        private static bool TryRunCommand<TResult>(ImAnInteractionCommand<TResult> command, out TResult result, out Exception exception)
        {
            exception = null;
            try
            {
                result = command.Execute();
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                result = default(TResult);
                return false;
            }
        }

        public static QueryResult<TResult> Query<TResult, TParameter>(ImAQuery<TResult, TParameter> query, TParameter parameter)
        {
            Exception exception;
            TResult result;
            if (!TryQuery(query, parameter, out result, out exception))
            {
                return new ExceptionQueryResult<TResult>(exception);
            }
            return new SuccessfulQueryResult<TResult>(result);
        }

        private static bool TryQuery<TResult, TParameter>(ImAQuery<TResult, TParameter> query, TParameter parameter, out TResult result, out Exception exception)
        {
            exception = null;
            try
            {
                result = query.Query(parameter);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                result = default(TResult);
                return false;
            }
        }
    }
}
