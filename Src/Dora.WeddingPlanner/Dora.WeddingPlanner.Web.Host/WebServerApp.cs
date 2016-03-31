using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Dora.WeddingPlanner.Web.Host
{
    public static class WebServerApp
    {
        public static IDisposable Run()
        {
            return WebApp.Start<Starter>(ConfigurationManager.AppSettings["WebServerApp.Host.Url"] ?? "http://+:9666");
        }
    }
}
