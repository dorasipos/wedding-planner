using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Commands
{
    public abstract class CommandResult
    {
        public abstract bool IsSuccessful { get; }

        public virtual string Details { get; protected set; }
    }
}
