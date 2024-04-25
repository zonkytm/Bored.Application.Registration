using Bored.Application.Registration.Client.Kafka.Events.Incoming;
using KafkaFlow;
using KafkaFlow.TypedHandler;

namespace Bored.Application.Registration.AppServices.Contracts.Kafka.Handlers;

public interface IAcceptActivityEventHandler : IMessageHandler<AcceptActivityEvent>
{
}