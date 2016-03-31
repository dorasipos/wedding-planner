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
            if (!TryRunCommand(command, out exception))
            {
                return new ExceptionCommandResult(exception);
            }
            return new SuccessfulCommandResult();
        }

        private static bool TryRunCommand(ImAnInteractionCommand command, out Exception exception)
        {
            exception = null;
            try
            {
                command.Execute();
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }
    }
}
