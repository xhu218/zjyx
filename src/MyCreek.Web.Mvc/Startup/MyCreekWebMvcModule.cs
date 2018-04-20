using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCreek.Configuration;
using CreekQuartz;

namespace MyCreek.Web.Startup
{
    [DependsOn(typeof(MyCreekWebCoreModule), typeof(CreekQuartzModule))]
    public class MyCreekWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyCreekWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<MyCreekNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCreekWebMvcModule).GetAssembly());
        }
    }
}
