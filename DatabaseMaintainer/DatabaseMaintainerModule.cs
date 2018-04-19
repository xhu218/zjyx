using Abp.AspNetCore;
using Abp.Modules;
using Abp.Threading.BackgroundWorkers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DatabaseMaintainer
{
    [DependsOn(typeof(AbpAspNetCoreModule))]
    public class DatabaseMaintainerModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            workManager.Add(IocManager.Resolve<DeleteOldAuditLogsWorker>());
        }
    }
}
