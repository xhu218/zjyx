using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MyCreek.Authorization.Users;

namespace MyCreek.Entities.Events
{
    public class EventManager : IEventManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IEventRegistrationPolicy _registrationPolicy;
        private readonly IRepository<EventRegistration> _eventRegistrationRepository;
        private readonly IRepository<CreekEvent, Guid> _eventRepository;

        public EventManager(
            IEventRegistrationPolicy registrationPolicy,
            IRepository<EventRegistration> eventRegistrationRepository,
            IRepository<CreekEvent, Guid> eventRepository)
        {
            _registrationPolicy = registrationPolicy;
            _eventRegistrationRepository = eventRegistrationRepository;
            _eventRepository = eventRepository;

            EventBus = NullEventBus.Instance;
        }

        public async Task<CreekEvent> GetAsync(Guid id)
        {
            var @event = await _eventRepository.FirstOrDefaultAsync(id);
            if (@event == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
            }

            return @event;
        }

        public async Task CreateAsync(CreekEvent @event)
        {
            await _eventRepository.InsertAsync(@event);
        }

        public void Cancel(CreekEvent @event)
        {
            @event.Cancel();
            EventBus.Trigger(new EventCancelledEvent(@event));
        }

        public async Task<EventRegistration> RegisterAsync(CreekEvent @event, User user)
        {
            return await _eventRegistrationRepository.InsertAsync(
                await EventRegistration.CreateAsync(@event, user, _registrationPolicy)
                );
        }

        public async Task CancelRegistrationAsync(CreekEvent @event, User user)
        {
            var registration = await _eventRegistrationRepository.FirstOrDefaultAsync(r => r.EventId == @event.Id && r.UserId == user.Id);
            if (registration == null)
            {
                //No need to cancel since there is no such a registration
                return;
            }

            await registration.CancelAsync(_eventRegistrationRepository);
        }

        public async Task<IReadOnlyList<User>> GetRegisteredUsersAsync(CreekEvent @event)
        {
            return await _eventRegistrationRepository
                .GetAll()
                .Include(registration => registration.User)
                .Where(registration => registration.EventId == @event.Id)
                .Select(registration => registration.User)
                .ToListAsync();
        }
    }
}
