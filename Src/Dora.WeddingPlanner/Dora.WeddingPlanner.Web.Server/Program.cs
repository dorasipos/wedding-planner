using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Dora.WeddingPlanner.Web.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.UseNLog();

                x.SetServiceName("Dora.Wedding.Planner");
                x.SetDisplayName("Dora Wedding Planner Server");
                x.SetDescription("Dora Wedding Planner Server");

                x.Service<Service>(s =>
                {
                    s.ConstructUsing(_ => new Service());
                    s.WhenStarted(svc => svc.Start());
                    s.WhenStopped(svc => svc.Stop());
                });

                x.RunAsLocalSystem();

                x.StartAutomatically();
            });
        }
    }
}
