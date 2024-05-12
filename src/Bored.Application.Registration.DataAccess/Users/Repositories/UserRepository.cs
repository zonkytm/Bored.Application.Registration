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

    public async Task<long> CreateAsync(User user, CancellationToken cancellationToken)
    {
        var userEntity = UserMapper.MapUserToUserEntity(user);

        var isUserRegistered = await IsUserRegistered(user, cancellationToken);

        if (isUserRegistered)
        {
            return default;
        }

        await _context.InsertAsync(userEntity, token: cancellationToken);
        return userEntity.TelegramId;
    }

    public async Task<bool> IsUserRegistered(User user, CancellationToken cancellationToken)
    {
        var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.TelegramId == user.TelegramId, cancellationToken);

            return userEntity != null;
    }

    public async Task AddPartner(long id, long partnerId)
    {
        await _context.GetTable<UserEntity>()
            .Where(u => u.TelegramId == id)
            .Set(u => u.PartnerId, partnerId)
            .UpdateAsync();
    }

    public async Task<User?> GetUserByUserName(string username)
    {
        var userEntity = await _context.Users.FirstOrDefaultAsync(entity => entity.UserName.Equals(username));

        var user = UserMapper.MapUserEntityToUser(userEntity);

        return user;
    }

    public async Task<User?> GetUserById(long id)
    {
        var userEntity = await _context.Users.FirstOrDefaultAsync(entity => entity.TelegramId == id);
        var user = UserMapper.MapUserEntityToUser(userEntity);

        return user;
    }
}