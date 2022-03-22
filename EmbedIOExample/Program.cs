using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EmbedIOExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var server = ServerCreate.Instance.CreateWebServer("http://localhost:5858");
            server.RunAsync();
            Host.CreateDefaultBuilder(args).Build().Run();
            //await System.Threading.Tasks.Task.Delay(-1);
        }
    }
}

