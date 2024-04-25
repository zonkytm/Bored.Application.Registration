using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Users.Infos;
using Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Handlers;
using Bored.Application.Registration.Client.Kafka.Events.Incoming;
using KafkaFlow;

namespace Bored.Application.Registration.Host.Users.Kafka.Handlers;

public class RegisterUserEventHandler : IRegisterUserEventHandler
{
    private readonly IAddUserHandler _addUserHandler;

    public RegisterUserEventHandler(IAddUserHandler addUserHandler)
    {
        _addUserHandler = addUserHandler;
    }

    public async Task Handle(IMessageContext context, RegisterUserEvent registerUserEventevent)
    {
        if (registerUserEventevent != null)
        {
            var addUserInfo = new AddUserInfo
            {
                ChatId = registerUserEventevent.ChatId,
                TelegramId = registerUserEventevent.TelegramId,
                FirstName = registerUserEventevent.FirstName,
                LastName = registerUserEventevent.LastName,
                UserName = registerUserEventevent.UserName
            };

            await _addUserHandler.Handle(addUserInfo, CancellationToken.None);
        }
    }
}