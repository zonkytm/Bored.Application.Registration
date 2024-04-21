using Bored.Application.Registration.Api.Contracts;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Repositories;

public interface IUserRepository
{
    Task<Guid> CreateAsync(User user, CancellationToken cancellationToken);
    Task<bool> IsUserRegistered(User user, CancellationToken cancellationToken);
    Task AddUserLove(User user, string loveUsername);
}