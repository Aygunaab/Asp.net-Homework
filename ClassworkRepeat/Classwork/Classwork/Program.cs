using Classwork.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using( var scope = host.Services.CreateScope())
            {
                var DbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var RolMaager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                DataInitialiser dataInit = new DataInitialiser(DbContext, RolMaager);
                await dataInit.SeedData();
            }
           
               await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
