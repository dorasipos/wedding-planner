using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Web.Host;

namespace Dora.WeddingPlanner.Web.Server
{
    internal class Service
    {
        private IDisposable webServerApp;

        public void Start()
        {
            this.webServerApp = WebServerApp.Run();
        }

        public void Stop()
        {
            webServerApp.Dispose();
        }
    }
}
