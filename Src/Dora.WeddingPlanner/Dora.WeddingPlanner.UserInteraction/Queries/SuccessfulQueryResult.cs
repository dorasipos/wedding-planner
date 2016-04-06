using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Queries
{
    public class SuccessfulQueryResult<TResult> : QueryResult<TResult>
    {
        private SuccessfulQueryResult()
            : base()
        { }

        public SuccessfulQueryResult(TResult result)
            : base()
        {
            this.Result = result;
            this.Details = result.ToString();
        }

        public override bool IsSuccessful
        {
            get
            {
                return true;
            }
        }
    }
}
