using Bored.Application.Registration.Api.Contracts.Users;
using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Users.Infos;
using Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Producers;
using Bored.Application.Registration.AppServices.Contracts.Users.Repositories;
using Bored.Application.Registration.Client.Kafka.Enums;
using Bored.Application.Registration.Client.Kafka.Events.Outgoing;

namespace Bored.Application.Registration.AppServices.Users.Handlers;

internal class AddUserHandler : IAddUserHandler
{
    private readonly IRegisterUserEventResultProducer _userEventResultProducer;

    private readonly IUserRepository _repository;
    
    public AddUserHandler(IRegisterUserEventResultProducer userEventResultProducer, IUserRepository repository)
    {
        _userEventResultProducer = userEventResultProducer;
        _repository = repository;
    }

    public async Task<Guid> Handle(AddUserInfo addUserInfo, CancellationToken cancellationToken)
    {
        var user = new User
        {
            ChatId = addUserInfo.ChatId,
            TelegramId = addUserInfo.TelegramId,
            FirstName = addUserInfo.FirstName,
            LastName = addUserInfo.LastName,
            UserName = addUserInfo.UserName
        };


        var registerUserId = await _repository.CreateAsync(user, cancellationToken);

        var registerUserEventResult = new RegisterUserEventResult
        {
            ChatId = addUserInfo.ChatId,
            RegisterStatus = registerUserId == Guid.Empty ? RegisterStatus.AlreadyExisted : RegisterStatus.Registered
        };

        await _userEventResultProducer.ProduceRegisterUserEventResultAsync(registerUserEventResult);

        return registerUserId;
    }
}