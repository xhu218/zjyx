using Abp.Events.Bus.Entities;

namespace MyCreek.Entities.Events
{
    public class EventCancelledEvent : EntityEventData<CreekEvent>
    {
        public EventCancelledEvent(CreekEvent entity)
            : base(entity)
        {
        }
    }
}
