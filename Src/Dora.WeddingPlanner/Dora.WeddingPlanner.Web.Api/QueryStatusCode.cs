using Dora.WeddingPlanner.UserInteraction.Queries;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Web.Api
{
    internal static class QueryStatusCode
    {
        public static HttpStatusCode StatusCode<TResult>(this QueryResult<TResult> result)
        {
            if (result.IsSuccessful)
            {
                return HttpStatusCode.Accepted;
            }

            return HttpStatusCode.BadRequest;
        }
    }
}
