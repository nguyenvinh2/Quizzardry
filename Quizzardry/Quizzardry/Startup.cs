using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quizzardry.Data;
using Quizzardry.Models.Interfaces;
using Quizzardry.Models.Services;
using Quizzardry.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Quizzardry
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // USER SECRETS
            //var cb = new ConfigurationBuilder().AddEnvironmentVariables();
            //cb.AddUserSecrets<Startup>();
            //Configuration = cb.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSession();
            services.AddMemoryCache();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSignalR();
            services.AddDbContext<QuestionsDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("LocalQuestionsDB"));
            });

            services.AddDbContext<GamesDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LocalGamesDB"));
            });

            services.AddScoped<IPlayer, PlayerService>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //    name: "default",
            //    template: "{Controller=Index}");
            //});

            app.UseSignalR(routes =>
            {
                routes.MapHub<TriviaHub>("/triviaHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
