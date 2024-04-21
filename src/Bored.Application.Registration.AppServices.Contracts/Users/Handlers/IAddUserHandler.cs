using Bored.Application.Registration.AppServices.Contracts.Users.Infos;
using Bored.Application.Registration.Client.Kafka.Events;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Handlers;

public interface IAddUserHandler
{
    public Task<Guid> Handle(AddUserInfo addUserInfo, CancellationToken cancellationToken);
}