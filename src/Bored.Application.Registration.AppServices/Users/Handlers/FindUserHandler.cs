using Bored.Application.Registration.Api.Contracts.Users;
using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Users.Repositories;

namespace Bored.Application.Registration.AppServices.Users.Handlers;

public class FindUserHandler : IFindUserHandler
{
    private readonly IUserRepository _repository;

    public FindUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Handle(string requestUsername)
    {
        if (string.IsNullOrWhiteSpace(requestUsername) || requestUsername.Length == 0)
        {
            return null;
        }

        var user = await _repository.FindUserByUserName(requestUsername);

        return user;
    }
}