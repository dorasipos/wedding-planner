using Dora.WeddingPlanner.UserInteraction;
using Dora.WeddingPlanner.UserInteraction.Commands.Weddings;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Web.Api
{
    public class WeddingTaskModule : NancyModule
    {
        public WeddingTaskModule()
            : base("/task")
        {
            Post["/"] = p =>
            {
                var result = Interactor.Run(this.Bind<CreateWeddingTaskCommand>());
                return Response.AsJson(result).WithStatusCode(result.StatusCode());
            };
        }
    }
}
