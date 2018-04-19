using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyCreek.Entities.Events;

namespace MyCreek.Events.Dtos
{
    [AutoMapFrom(typeof(CreekEvent))]
    public class EventDetailOutput : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsCancelled { get; set; }

        public virtual int MaxRegistrationCount { get; protected set; }

        public int RegistrationsCount { get; set; }

        public ICollection<EventRegistrationDto> Registrations { get; set; }
    }
}
