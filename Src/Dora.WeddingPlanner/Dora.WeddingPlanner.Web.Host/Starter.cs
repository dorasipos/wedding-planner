using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction;
using Microsoft.Owin.Cors;
using Owin;

namespace Dora.WeddingPlanner.Web.Host
{
    internal class Starter
    {
        public void Configuration(IAppBuilder app)
        {
            Interactor.Initialize();

            app
                .UseCors(CorsOptions.AllowAll)
                .UseNancy(cfg => cfg.Bootstrapper = new NancyBootstrapper());
        }
    }
}
