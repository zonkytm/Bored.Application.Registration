using Bored.Application.Registration.Api.Contracts;
using Bored.Application.Registration.Api.Contracts.Activities;
using Bored.Application.Registration.AppServices.Contracts.Activities.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Activities.Repositories;

namespace Bored.Application.Registration.AppServices.Activities.Handlers;

public class GetUserActivitiesHandler : IGetUserActivitiesHandler
{
    private readonly IActivityRepository _repository;

    public GetUserActivitiesHandler(IActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Activity[]> Handle(long telegramId)
    {
        if (telegramId <= 0)
        {
            throw new ArgumentException();
        }

        var activityList = await _repository.GetUserActivitiesListAsync(telegramId);

        return activityList;
    }
}