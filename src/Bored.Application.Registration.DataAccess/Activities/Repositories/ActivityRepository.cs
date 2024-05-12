using Bored.Application.Registration.Api.Contracts;
using Bored.Application.Registration.Api.Contracts.Activities;
using Bored.Application.Registration.AppServices.Contracts.Activities.Infos;
using Bored.Application.Registration.AppServices.Contracts.Activities.Repositories;
using Bored.Application.Registration.DataAccess.ApplicationContexts;
using LinqToDB;

namespace Bored.Application.Registration.DataAccess.Activities.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly ApplicationDbContext _context;

    public ActivityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Activity[]> GetUserActivitiesListAsync(long telegramId)
    {
        var activitiesList = from activities in _context.Activities
            where activities.TelegramId == telegramId
            select new Activity
            {
                ActivityId = activities.ActivityId,
                TelegramId = activities.TelegramId,
                ActivityText = activities.ActivityText
            };

        return activitiesList.ToArray();
    }

    public async Task AddActivity(AddActivityInfo activityInfo)
    {
        var activityEntity = new ActivityEntity
        {
            TelegramId = activityInfo.TelegramId,
            ActivityText = activityInfo.ActivityText
        };

        var activity = new Activity
        {
            TelegramId = activityInfo.TelegramId,
            ActivityText = activityInfo.ActivityText
        };

        var isActivityAdded = await IsActivityAdded(activity, CancellationToken.None);

        if (isActivityAdded)
        {
            return;
        }

        await _context.InsertAsync(activityEntity);
    }

    public Task<bool> DeleteUserActivity(DeleteActivityInfo deleteActivityInfo)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsActivityAdded(Activity activity, CancellationToken cancellationToken)
    {
        var activityEntity = await _context.Activities
            .FirstOrDefaultAsync(x => x.ActivityText != null && x.ActivityText.Equals(activity.ActivityText), cancellationToken);

        return activityEntity != null;
    }
}