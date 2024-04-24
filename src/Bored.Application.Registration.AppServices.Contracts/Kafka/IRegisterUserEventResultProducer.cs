using Bored.Application.Registration.Client.Kafka.Events;
using Bored.Application.Registration.Client.Kafka.Events.Outgoing;

namespace Bored.Application.Registration.AppServices.Contracts.Kafka;

public interface IRegisterUserEventResultProducer
{
    Task ProduceRegisterUserEventResultAsync(RegisterUserEventResult registerUserEventResult);
}