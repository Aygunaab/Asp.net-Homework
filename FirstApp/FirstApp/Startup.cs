using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller}/{action=about}"
                    
                    );
                endpoints.MapControllerRoute(
                   "default2",
                   "{controller=home}/{action=index}"

                   );
                endpoints.MapControllerRoute(
                  "default3",
                  "esas-sehife",
                  defaults:new {controller="home",action="index"}

                  );
                endpoints.MapControllerRoute(
                 "default4",
                 "what-we-do",
                 defaults: new { controller = "home", action = "about" }

                 );
                endpoints.MapControllerRoute(
                "default5",
                "elaqe",
                defaults: new { controller = "home", action = "contact" }

                );
            });
        }
    }
}
