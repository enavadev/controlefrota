using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Veiculos.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseKestrel()
               .UseSetting("detailedErrors", "true")
               .UseIISIntegration()
               .UseStartup<Startup>()
               .ConfigureAppConfiguration((builderContext, config) => {

                   IWebHostEnvironment env = builderContext.HostingEnvironment;

                   config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
               })
               .Build();
    }
}
