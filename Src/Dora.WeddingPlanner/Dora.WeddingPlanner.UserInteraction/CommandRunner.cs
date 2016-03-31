using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction.Commands;

namespace Dora.WeddingPlanner.UserInteraction
{
    internal static class CommandRunner
    {
        public static CommandResult Run(ImAnInteractionCommand command)
        {
            Exception exception;
            string result;
            if (!TryRunCommand(command, out result, out exception))
            {
                return new ExceptionCommandResult(exception);
            }
            return new SuccessfulCommandResult(result);
        }

        private static bool TryRunCommand(ImAnInteractionCommand command, out string result, out Exception exception)
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
                result = ex.Message;
                return false;
            }
        }
    }
}
