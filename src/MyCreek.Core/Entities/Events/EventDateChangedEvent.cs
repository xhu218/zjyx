using Abp.Events.Bus.Entities;

namespace MyCreek.Entities.Events
{
    public class EventDateChangedEvent : EntityEventData<CreekEvent>
    {
        public EventDateChangedEvent(CreekEvent entity)
            : base(entity)
        {
        }
    }
}
