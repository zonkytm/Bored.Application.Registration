using Bored.Application.Registration.Client.Kafka.Events;

namespace Bored.Application.Registration.AppServices.Contracts.Kafka;

public interface IRegisterUserEventResultProducer
{
    Task ProduceRegisterUserEventResultAsync(RegisterUserEventResult registerUserEventResult);
}