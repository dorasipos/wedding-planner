﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction.Commands;
using Nancy;

namespace Dora.WeddingPlanner.Web.Api
{
    internal static class CommandStatusCode
    {
        public static HttpStatusCode StatusCode<TResult>(this CommandResult<TResult> result)
        {
            if (result.IsSuccessful)
            {
                return HttpStatusCode.Accepted;
            }

            return HttpStatusCode.BadRequest;
        }
    }
}
