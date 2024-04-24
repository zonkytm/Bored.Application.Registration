using Bored.Application.Registration.AppServices.Contracts.Kafka;
using Bored.Application.Registration.Client.Kafka.Events.Outgoing;
using DCS.Platform.Kafka.Abstractions.Attributes;
using KafkaFlow;

namespace Bored.Application.Registration.Host.Kafka.Producers;

[KafkaTopic("register-user-event-result")]
public class RegisterUserEventResultProducer : IRegisterUserEventResultProducer
{
    private readonly IMessageProducer<RegisterUserEventResultProducer> _messageProducer;

    public RegisterUserEventResultProducer(IMessageProducer<RegisterUserEventResultProducer> messageProducer)
    {
        _messageProducer = messageProducer;
    }

    public async Task ProduceRegisterUserEventResultAsync(RegisterUserEventResult registerUserEventResult)
    {
        await _messageProducer.ProduceAsync(registerUserEventResult.ChatId.ToString(), registerUserEventResult);
    }
}