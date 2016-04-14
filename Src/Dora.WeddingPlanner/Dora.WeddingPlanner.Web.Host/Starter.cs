using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using Microsoft.Owin;

namespace Dora.WeddingPlanner.Web.Host
{
    internal class Starter
    {
        public void Configuration(IAppBuilder app)
        {
            Interactor.Initialize();

            var physicalFileSystem = new PhysicalFileSystem(@"../../Dora.WeddingPlanner.Web.UI");
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem,
                RequestPath = new PathString("/ui")
            };
            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };

            app
                .UseCors(CorsOptions.AllowAll)
                .UseFileServer(options)
                .UseNancy(cfg => cfg.Bootstrapper = new NancyBootstrapper());
        }
    }
}
