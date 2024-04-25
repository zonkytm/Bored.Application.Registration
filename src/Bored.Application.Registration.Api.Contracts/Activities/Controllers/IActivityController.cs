using Bored.Application.Registration.Api.Contracts.Activities.Web.Responses;

namespace Bored.Application.Registration.Api.Contracts.Activities.Controllers;

public interface IActivityController
{
    Task<GetUserActivitiesResponse> GetUserActivities(long telegramId);
}