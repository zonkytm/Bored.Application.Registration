using Bored.Application.Registration.Client.Kafka.Events.Incoming;
using KafkaFlow.TypedHandler;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Handlers;

public interface IRegisterUserEventHandler : IMessageHandler<RegisterUserEvent>
{
}