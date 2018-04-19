﻿using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCreek.Entities.Events
{
    public static class DomainEvents
    {
        public static IEventBus EventBus { get; set; }

        static DomainEvents()
        {
            EventBus = Abp.Events.Bus.EventBus.Default;
        }
    }
}
