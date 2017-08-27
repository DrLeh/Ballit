using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ballit.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ballit.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<BallitContext>(opt => opt.UseInMemoryDatabase("Ballit"));
            //services.AddDbContext<BallitContext>(opt => opt.UseSqlServer("Ballit"));
            var connection = @"Server=(localdb)\mssqllocaldb;Database=Ballit;Trusted_Connection=True;";
            services.AddDbContext<BallitContext>(options => options.UseSqlServer(connection));

            services.AddMvc();


            new Ballit.Core.Startup.ContainerRegistry().Inject(services);
            new Ballit.Data.Startup.ContainerRegistry().Inject(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
