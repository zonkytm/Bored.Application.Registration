using Bored.Application.Registration.Client.Kafka.Events.Outgoing;

namespace Bored.Application.Registration.AppServices.Contracts.Kafka.Producers;

public interface IRegisterUserEventResultProducer
{
    Task ProduceRegisterUserEventResultAsync(RegisterUserEventResult registerUserEventResult);
}