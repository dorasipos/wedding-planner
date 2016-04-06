using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Queries
{
    public abstract class QueryResult<TResult>
    {
        public abstract bool IsSuccessful { get; }

        public virtual string Details { get; protected set; }

        public virtual TResult Result { get; protected set; }

        public override string ToString()
        {
            if (this.IsSuccessful)
            {
                return string.Format("SUCCESSFULLY executed query{0}Result:{0}{1}{0}", Environment.NewLine, this.Details ?? "[Nothing]");
            }

            return string.Format("ERROR executing query{0}{0}Result:{0}{1}{0}", Environment.NewLine, this.Details ?? "[Nothing]");
        }
    }
}
