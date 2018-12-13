using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TraderInfo.Interfaces;
using TraderInfo.Models;
using TraderInfo.Repository;

namespace TraderInfo
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.ResolveConflictingActions(api => api.First());
            });

            services.AddSingleton<IAzureDBRepository<Trader>, AzureDBRepository<Trader>>();
            services.AddScoped<IAzureDBRepository<CompletedTradesLog>, AzureDBRepository<CompletedTradesLog>>();
            services.AddScoped<IAzureDBRepository<CurrentTrade>, AzureDBRepository<CurrentTrade>>();
            services.AddSingleton<IAzureDBRepository<PlannedTrade>, AzureDBRepository<PlannedTrade>>();
            services.AddScoped<IAzureDBRepository<ProsumerTraderInfo>, AzureDBRepository<ProsumerTraderInfo>>();
            services.AddScoped<IAzureDBRepository<ProsumerTradesOffer>, AzureDBRepository<ProsumerTradesOffer>>();
            services.AddScoped<IAzureDBRepository<ProsumerTradesSale>, AzureDBRepository<ProsumerTradesSale>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseStaticFiles();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = string.Empty;
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
