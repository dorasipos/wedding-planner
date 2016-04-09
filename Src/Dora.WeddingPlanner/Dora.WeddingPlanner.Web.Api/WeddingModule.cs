using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction;
using Dora.WeddingPlanner.UserInteraction.Commands;
using Dora.WeddingPlanner.UserInteraction.Queries.Weddings;
using Nancy;
using Nancy.ModelBinding;

namespace Dora.WeddingPlanner.Web.Api
{
    public class WeddingModule : NancyModule
    {
        public WeddingModule()
            : base("/wedding")
        {
            Get["/"] = p =>
            {
                var result = Interactor.Query(new AvailableWeddingsQuery(), null);
                return Response.AsJson(result).WithStatusCode(result.StatusCode());
            };

            Get["/{WeddingId}"] = p =>
            {
                var result = Interactor.Query(new LoadWeddingQuery(), (string)p.WeddingId);
                return Response.AsJson(result).WithStatusCode(result.StatusCode());
            };

            Post["/"] = _ =>
            {
                var result = Interactor.Run(this.Bind<CreateWeddingCommand>());
                return Response.AsJson(result).WithStatusCode(result.StatusCode());
            };
        }
    }
}
