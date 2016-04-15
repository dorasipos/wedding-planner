using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction;
using Dora.WeddingPlanner.UserInteraction.Queries.Tasks;
using Nancy;

namespace Dora.WeddingPlanner.Web.Api
{
    public class TasksModule : NancyModule
    {
        public TasksModule()
            : base("/tasks")
        {
            Get["/predefined"] = p =>
            {
                var result = Interactor.Query(new PredefinedWeddingTasksQuery(), null);
                return Response.AsJson(result).WithStatusCode(result.StatusCode());
            };
        }
    }
}
