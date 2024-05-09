using Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Producers;
using Bored.Application.Registration.Client.Kafka.Events.Outgoing;
using DCS.Platform.Kafka.Abstractions.Attributes;
using KafkaFlow;

namespace Bored.Application.Registration.Host.Users.Kafka.Producers;

[KafkaTopic("request-partner-event-result")]
public class RequestPartnerEventResultProducer : IRequestPartnerEventResultProducer
{
    private readonly IMessageProducer<RegisterUserEventResultProducer> _messageProducer;

    public RequestPartnerEventResultProducer(IMessageProducer<RegisterUserEventResultProducer> messageProducer)
    {
        _messageProducer = messageProducer;
    }

    public async Task ProduceRequestPartnerEventResultAsync(RequestPartnerEventResult requestPartnerEventResult)
    {
        await _messageProducer.ProduceAsync(requestPartnerEventResult.TelegramId.ToString(), requestPartnerEventResult);
    }
}