using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace New.Hope.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Iniciando New Hope Stundents API");

            var server = new Program().CreateWebHost().Build();

            server.Run();
        }

        public IWebHostBuilder CreateWebHost()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();

            return host;
        }
    }
}
