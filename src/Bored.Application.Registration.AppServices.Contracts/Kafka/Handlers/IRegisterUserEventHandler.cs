using Bored.Application.Registration.Client.Kafka.Events;
using Bored.Application.Registration.Client.Kafka.Events.Incoming;
using KafkaFlow;
using KafkaFlow.TypedHandler;

namespace Bored.Application.Registration.AppServices.Contracts.Kafka.Handlers;

public interface IRegisterUserEventHandler : IMessageHandler<RegisterUserEvent>
{
    Task Handle(IMessageContext context, RegisterUserEvent eventResult);
}