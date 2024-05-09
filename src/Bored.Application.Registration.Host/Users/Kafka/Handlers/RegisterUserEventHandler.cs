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

    public async Task Handle(IMessageContext context, RegisterUserEvent @event)
    {
        if (@event != null)
        {
            var addUserInfo = new AddUserInfo
            {
                ChatId = @event.ChatId,
                TelegramId = @event.TelegramId,
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                UserName = @event.UserName
            };

            await _addUserHandler.Handle(addUserInfo, CancellationToken.None);
        }
    }
}