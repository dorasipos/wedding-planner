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

        public override string ToString()
        {
            if (this.IsSuccessful)
            {
                return "SUCCESSFULLY executed interaction command";
            }

            return string.Format("ERROR executing interaction command{0}{0}Details:{0}{1}", Environment.NewLine, this.Details);
        }
    }
}
