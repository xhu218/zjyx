using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using MyCreek.Authentication.JwtBearer;
using MyCreek.Configuration;
using MyCreek.Identity;
using MyCreek.Web.Resources;
using Swashbuckle.AspNetCore.Swagger;
using Abp.PlugIns;

#if FEATURE_SIGNALR
using Owin;
using Abp.Owin;
using MyCreek.Owin;
#elif FEATURE_SIGNALR_ASPNETCORE
using Abp.AspNetCore.SignalR.Hubs;
#endif

namespace MyCreek.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            var pluginPath = $"{env.ContentRootPath}\\MyPlugIns";
            if (!System.IO.Directory.Exists(pluginPath))
            {
                System.IO.Directory.CreateDirectory(pluginPath);
            }
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            );

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddScoped<IWebResourceManager, WebResourceManager>();

#if FEATURE_SIGNALR_ASPNETCORE
            services.AddSignalR();
#endif

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "AbpZeroTemplate API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
            });

            var pluginPath =  Environment.CurrentDirectory;
            // Configure Abp and Dependency Injection
            return services.AddAbp<MyCreekWebMvcModule>(
                // Configure Log4Net logging
                options =>
                {
                    options.PlugInSources.Add(new FolderPlugInSource($"{pluginPath}\\MyPlugIns"));
                    options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                        f => f.UseAbpLog4Net().WithConfig("log4net.config")
                    );
                }
            );
           
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); // Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseJwtTokenMiddleware();

#if FEATURE_SIGNALR
            // Integrate with OWIN
            app.UseAppBuilder(ConfigureOwinServices);
#elif FEATURE_SIGNALR_ASPNETCORE
            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });
#endif


            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AbpZeroTemplate API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

#if FEATURE_SIGNALR
        private static void ConfigureOwinServices(IAppBuilder app)
        {
            app.Properties["host.AppName"] = "MyCreek";

            app.UseAbp();

            app.MapSignalR();
        }
#endif
    }
}
