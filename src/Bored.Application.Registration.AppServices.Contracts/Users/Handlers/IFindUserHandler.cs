using Bored.Application.Registration.Api.Contracts.Users;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Handlers;

public interface IFindUserHandler
{
    Task<User> Handle(string requestUsername);
}