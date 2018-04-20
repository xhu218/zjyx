using Abp.Dependency;
using Abp.Quartz;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreekQuartz
{
    public class MyLogJob : JobBase, ITransientDependency
    {
        public override Task Execute(IJobExecutionContext context)
        {
            Logger.Info("Executed MyLogJob..!");
            return Task.CompletedTask;
        }
    }
}
