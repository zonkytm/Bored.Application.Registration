using Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Producers;
using Bored.Application.Registration.Client.Kafka.Events.Outgoing;
using DCS.Platform.Kafka.Abstractions.Attributes;
using KafkaFlow;

namespace Bored.Application.Registration.Host.Users.Kafka.Producers;

[KafkaTopic("add-partner-event")]
public class AddPartnerEventProducer : IAddPartnerEventProducer
{
    private readonly IMessageProducer<RegisterUserEventResultProducer> _messageProducer;

    public AddPartnerEventProducer(IMessageProducer<RegisterUserEventResultProducer> messageProducer)
    {
        _messageProducer = messageProducer;
    }

    public async Task ProduceAddPartnerEventAsync(AddPartnerEvent addPartnerEvent)
    {
        await _messageProducer.ProduceAsync(addPartnerEvent.TelegramId.ToString(), addPartnerEvent);
    }
}