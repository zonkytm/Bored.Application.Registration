using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Users.Infos;
using Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Handlers;
using Bored.Application.Registration.Client.Kafka.Enums;
using Bored.Application.Registration.Client.Kafka.Events.Incoming;
using DCS.Platform.Kafka.Abstractions.Attributes;
using KafkaFlow;

namespace Bored.Application.Registration.Host.Users.Kafka.Handlers;

[KafkaTopic("add-partner-event-result")]
public class AddPartnerEventResultHandler : IAddPartnerEventResultHandler
{
    private readonly IAddPartnerHandler _addPartnerHandler;

    public AddPartnerEventResultHandler(IAddPartnerHandler addPartnerHandler)
    {
        _addPartnerHandler = addPartnerHandler;
    }

    public async Task Handle(IMessageContext context, AddPartnerEventResult @event)
    {
        if (@event.Status.Equals(AddPartnerStatus.Accepted))
        {
            var addPartnerInfo = new AddPartnerInfo
            {
                TelegramId = @event.TelegramId,
                PartnerId = @event.PartnerId
            };
            await _addPartnerHandler.Handle(addPartnerInfo);
        }
    }
}