using Abp.Modules;
using Abp.Quartz;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CreekQuartz
{
  
    [DependsOn(typeof(AbpQuartzModule))]
    public class CreekQuartzModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            var workManager = IocManager.Resolve<IQuartzScheduleJobManager>();
            workManager.Start();
        }
    }
}
