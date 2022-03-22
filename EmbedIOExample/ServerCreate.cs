using EmbedIO;
using EmbedIO.Actions;
using EmbedIO.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmbedIOExample
{
    public class ServerCreate
    {
        #region Singleton
        private static Lazy<ServerCreate> instance = new Lazy<ServerCreate>(() => new ServerCreate());
        public static ServerCreate Instance => instance.Value;
        private WebServer webServer;
        #endregion

        public WebServer CreateWebServer(string url)
        {
            webServer = new WebServer(x => x.WithUrlPrefix(url).WithMode(HttpListenerMode.EmbedIO))
                .WithLocalSessionManager()
                .WithWebApi("/api", y => y.RegisterController<ExampleController>())
                .WithModule(new Example());
            //.WithModule(new ActionModule("/", HttpVerbs.Any, async (context) => { await context.SendDataAsync(""); }));


            return webServer;
        }

    }
    public class Example : IWebModule
    {
        public string BaseRoute => "/";

        public bool IsFinalHandler => true;

        public ExceptionHandlerCallback OnUnhandledException { get; set; }
        public HttpExceptionHandlerCallback OnHttpException { get; set; }

        public Task HandleRequestAsync(IHttpContext context)
        {
            Console.WriteLine("Handle...");
            return Task.CompletedTask;
        }

        public RouteMatch MatchUrlPath(string urlPath)
        {
            return RouteMatch.UnsafeFromRoot(BaseRoute);
        }

        public void Start(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starting...");
        }
    }
}
