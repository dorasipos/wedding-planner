using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Queries
{
    public interface ImAQuery<TResult, TParameter>
    {
        TResult Query(TParameter parameter);
    }
}
