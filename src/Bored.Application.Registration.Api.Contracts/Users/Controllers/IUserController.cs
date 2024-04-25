using Bored.Application.Registration.Api.Contracts.Users.Web.Requests;
using Bored.Application.Registration.Api.Contracts.Users.Web.Responses;

namespace Bored.Application.Registration.Api.Contracts.Users.Controllers;

public interface IUserController
{
    public Task<FindUserResponse> FindUserByUserName(FindUserRequest request);
}