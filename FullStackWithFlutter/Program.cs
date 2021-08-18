using FullStackWithFlutter.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackWithFlutter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // seed int db data

            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var dbInit = service.GetRequiredService<IDatabaseInitializer>();
                try
                {
                    dbInit.SeedSampleData().Wait();
                }
                catch(Exception ex)
                {
                    var msg = ex.Message;
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
