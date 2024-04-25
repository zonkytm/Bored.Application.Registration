using Bored.Application.Registration.Api.Contracts.Activities.Controllers;
using Bored.Application.Registration.Api.Contracts.Activities.Controllers.Routes;
using Bored.Application.Registration.Api.Contracts.Activities.Web.Responses;
using Bored.Application.Registration.AppServices.Contracts.Activities.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Bored.Application.Registration.Host.Activities.Controllers;

[Route(ActivityControllerRoutes.BaseRoute)]
public class ActivityController : ControllerBase, IActivityController
{
    private readonly IGetUserActivitiesHandler _getUserActivitiesHandler;

    public ActivityController(IGetUserActivitiesHandler getUserActivitiesHandler)
    {
        _getUserActivitiesHandler = getUserActivitiesHandler;
    }

    [HttpGet(ActivityControllerRoutes.GetUserActivities.Route)]
    public async Task<GetUserActivitiesResponse> GetUserActivities([FromQuery] long telegramId)
    {
        var activityList = await _getUserActivitiesHandler.Handle(telegramId);

        var response = new GetUserActivitiesResponse
        {
            Activities = activityList
        };

        return response;
    }
}