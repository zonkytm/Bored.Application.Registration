using Bored.Application.Registration.Client.Kafka.Events.Incoming;
using KafkaFlow.TypedHandler;

namespace Bored.Application.Registration.AppServices.Contracts.Activities.Kafka.Handlers;

public interface IAcceptActivityEventHandler : IMessageHandler<AcceptActivityEvent>
{
}