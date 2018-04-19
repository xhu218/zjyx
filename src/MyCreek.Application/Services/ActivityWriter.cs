using Abp.Application.Services;
using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using MyCreek.Services.TaskEnent;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCreek.Services
{
    public class ActivityWriter :IEventHandler<TaskCompletedEventData>,IEventHandler<TaskCreatedEventData>,ITransientDependency
    {
        public void HandleEvent(TaskCompletedEventData eventData)
        {
            //TODO: handle the event...
        }

        public void HandleEvent(TaskCreatedEventData eventData)
        {
            //TODO: handle the event...
        }
    }
}
