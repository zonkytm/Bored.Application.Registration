using Bored.Application.Registration.Api.Contracts;
using Bored.Application.Registration.AppServices.Contracts.Users.Repositories;
using Bored.Application.Registration.DataAccess.ApplicationContexts;
using LinqToDB;

namespace Bored.Application.Registration.DataAccess.Users.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(User user, CancellationToken cancellationToken)
    {
        var userEntity = new UserEntity
        {
            Id = Guid.NewGuid(),
            ChatId = user.ChatId,
            TelegramId = user.TelegramId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            UserLoveId = null
        };

        var isUserRegistered = await IsUserRegistered(user, cancellationToken);
        
        if (isUserRegistered)
        {
            return Guid.Empty;
        }
        
        await _context.InsertAsync(userEntity, token: cancellationToken);
        return userEntity.Id;
    }

    public async Task<bool> IsUserRegistered(User user, CancellationToken cancellationToken)
    {
        var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.ChatId == user.ChatId, cancellationToken);

            return userEntity != null;
        }

    public async Task AddUserLove(User user, string loveUsername)
    {
        return;
    }
}