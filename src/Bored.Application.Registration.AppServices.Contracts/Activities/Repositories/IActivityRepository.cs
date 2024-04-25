using Bored.Application.Registration.Api.Contracts.Activities;
using Bored.Application.Registration.AppServices.Contracts.Activities.Infos;

namespace Bored.Application.Registration.AppServices.Contracts.Activities.Repositories;

public interface IActivityRepository
{
    public Task<Activity[]> GetUserActivitiesListAsync(long telegramId);

    public Task AddActivity(AddActivityInfo activityInfo);

    public Task<bool> DeleteUserActivity(DeleteActivityInfo deleteActivityInfo);

    public Task<bool> IsActivityAdded(Activity activity, CancellationToken cancellationToken);
}