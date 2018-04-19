using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;
using MyCreek.Authorization.Users;

namespace MyCreek.Entities.Events
{
    public interface IEventManager: IDomainService
    {
        Task<CreekEvent> GetAsync(Guid id);

        Task CreateAsync(CreekEvent @event);

        void Cancel(CreekEvent @event);

        Task<EventRegistration> RegisterAsync(CreekEvent @event, User user);

        Task CancelRegistrationAsync(CreekEvent @event, User user);

        Task<IReadOnlyList<User>> GetRegisteredUsersAsync(CreekEvent @event);
    }
}