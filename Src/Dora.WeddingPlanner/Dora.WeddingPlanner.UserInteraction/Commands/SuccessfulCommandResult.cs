using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Commands
{
    public class SuccessfulCommandResult : CommandResult
    {
        public override bool IsSuccessful
        {
            get
            {
                return true;
            }
        }
    }
}
