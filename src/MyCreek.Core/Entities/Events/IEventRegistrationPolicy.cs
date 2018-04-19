using System.Threading.Tasks;
using Abp.Domain.Services;
using MyCreek.Authorization.Users;

namespace MyCreek.Entities.Events
{
    public interface IEventRegistrationPolicy: IDomainService
    {
        /// <summary>
        /// Checks if given user can register to <see cref="@event"/> and throws exception if can not.
        /// </summary>
        Task CheckRegistrationAttemptAsync(CreekEvent @event, User user);
    }
}