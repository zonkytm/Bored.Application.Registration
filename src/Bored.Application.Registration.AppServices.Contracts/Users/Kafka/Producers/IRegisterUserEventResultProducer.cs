using Bored.Application.Registration.Client.Kafka.Events.Outgoing;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Producers;

public interface IRegisterUserEventResultProducer
{
    Task ProduceRegisterUserEventResultAsync(RegisterUserEventResult registerUserEventResult);
}