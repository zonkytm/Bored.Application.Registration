using Bored.Application.Registration.Api.Contracts;
using Bored.Application.Registration.Api.Contracts.Activities;

namespace Bored.Application.Registration.AppServices.Contracts.Activities.Handlers;

public interface IGetUserActivitiesHandler
{
    Task<Activity[]> Handle(long telegramId);
}