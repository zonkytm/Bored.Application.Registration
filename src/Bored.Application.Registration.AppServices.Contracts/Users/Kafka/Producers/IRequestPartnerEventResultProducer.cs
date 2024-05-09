using Bored.Application.Registration.Client.Kafka.Events.Outgoing;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Producers;

public interface IRequestPartnerEventResultProducer
{
    Task ProduceRequestPartnerEventResultAsync(RequestPartnerEventResult requestPartnerEventResult);
}