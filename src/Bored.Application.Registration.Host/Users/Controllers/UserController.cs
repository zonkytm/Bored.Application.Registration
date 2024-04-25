using Bored.Application.Registration.Api.Contracts.Users.Controllers;
using Bored.Application.Registration.Api.Contracts.Users.Controllers.Routes;
using Bored.Application.Registration.Api.Contracts.Users.Web.Requests;
using Bored.Application.Registration.Api.Contracts.Users.Web.Responses;
using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Bored.Application.Registration.Host.Users.Controllers;

[Microsoft.AspNetCore.Components.Route(UserControllerRoutes.BaseRoute)]
public class UserController : IUserController
{
    private readonly IFindUserHandler _findUserHandler;

    public UserController(IFindUserHandler findUserHandler)
    {
        _findUserHandler = findUserHandler;
    }

    [HttpGet(UserControllerRoutes.FindUser.Route)]
    public async Task<FindUserResponse> FindUserByUserName(FindUserRequest request)
    {
        if (request == null)
        {
            throw new NullReferenceException();
        }

        var user = await _findUserHandler.Handle(request.Username);

        var response = new FindUserResponse
        {
            User = user
        };

        return response;
        
    }
}