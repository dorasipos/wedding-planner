using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Commands
{
    public interface ImAnInteractionCommand<TResult>
    {
        TResult Execute();
    }
}
