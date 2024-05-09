using Bored.Application.Registration.Api.Contracts;
using Bored.Application.Registration.Api.Contracts.Users;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Repositories;

public interface IUserRepository
{
    Task<long> CreateAsync(User user, CancellationToken cancellationToken);
    Task<bool> IsUserRegistered(User user, CancellationToken cancellationToken);
    Task AddPartner(long id, long partnerId);
    Task<User?> GetUserByUserName(string username);
    Task<User?> GetUserById(long id);
}