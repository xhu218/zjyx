using Abp.Events.Bus;
using MyCreek.Authorization.Users;
using MyCreek.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCreek.Services.TaskEnent
{
    public class TaskEventData : EventData
    {
        public MyTask Task { get; set; }
    }

    public class TaskCreatedEventData : TaskEventData
    {
        public User CreatorUser { get; set; }
    }

    public class TaskCompletedEventData : TaskEventData
    {
        public User CompletorUser { get; set; }
    }
}
