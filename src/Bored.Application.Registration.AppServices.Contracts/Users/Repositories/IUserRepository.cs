using Bored.Application.Registration.Api.Contracts;
using Bored.Application.Registration.Api.Contracts.Users;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Repositories;

public interface IUserRepository
{
    Task<Guid> CreateAsync(User user, CancellationToken cancellationToken);
    Task<bool> IsUserRegistered(User user, CancellationToken cancellationToken);
    Task AddUserLove(User user, string loveUsername);
    Task<User?> FindUserByUserName(string username);
}