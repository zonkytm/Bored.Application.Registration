using Bored.Application.Registration.Api.Contracts;
using Bored.Application.Registration.Api.Contracts.Users;
using Bored.Application.Registration.AppServices.Contracts.Users.Repositories;
using Bored.Application.Registration.DataAccess.ApplicationContexts;
using Bored.Application.Registration.DataAccess.Users.Mappers;
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
        var userEntity = UserMapper.MapUserToUserEntity(user);

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

    public async Task<User?> FindUserByUserName(string username)
    {
        var userEntity = await _context.Users.FirstOrDefaultAsync(entity => entity.UserName.Equals(username));

        var user = UserMapper.MapUserEntityToUser(userEntity);

        return user;
    }
}