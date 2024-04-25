using Bored.Application.Registration.Api.Contracts.Users;

namespace Bored.Application.Registration.DataAccess.Users.Mappers;

public static class UserMapper
{
    public static User? MapUserEntityToUser(UserEntity userEntity)
    {
        if (userEntity == null)
        {
            return null;
        }

        return new User
        {
            ChatId = userEntity.ChatId,
            TelegramId = userEntity.TelegramId,
            FirstName = userEntity.FirstName,
            LastName = userEntity.LastName,
            UserName = userEntity.UserName
        };
    }

    public static UserEntity MapUserToUserEntity(User user)
    {
        return new UserEntity
        {
            Id = Guid.NewGuid(),
            ChatId = user.ChatId,
            TelegramId = user.TelegramId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName
        };
    }
}