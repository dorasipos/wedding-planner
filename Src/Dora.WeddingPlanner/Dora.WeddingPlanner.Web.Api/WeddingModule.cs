using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction;
using Dora.WeddingPlanner.UserInteraction.Queries.Weddings;
using Nancy;

namespace Dora.WeddingPlanner.Web.Api
{
    public class WeddingModule : NancyModule
    {
        public WeddingModule()
            : base("/wedding")
        {
            Get["/"] = p =>
            {
                return Response.AsJson(Interactor.Query(new AvailableWeddingsQuery()).ToArray());
            };
        }
    }
}
