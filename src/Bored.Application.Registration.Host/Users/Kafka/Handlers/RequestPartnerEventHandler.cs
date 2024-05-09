using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Users.Infos;
using Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Handlers;
using Bored.Application.Registration.Client.Kafka.Events.Incoming;
using KafkaFlow;

namespace Bored.Application.Registration.Host.Users.Kafka.Handlers;

public class RequestPartnerEventHandler : IRequestPartnerEventHandler
{
    private readonly IRequestPartnerHandler _requestPartnerHandler;

    public RequestPartnerEventHandler(IRequestPartnerHandler requestPartnerHandler)
    {
        _requestPartnerHandler = requestPartnerHandler;
    }

    public async Task Handle(IMessageContext context, RequestPartnerEvent @event)
    {
        if (@event != null)
        {
            var requestPartnerInfo = new RequestPartnerInfo
            {
                TelegramId = @event.TelegramId,
                PartnerUsername = @event.PartnerUsername
            };

            await _requestPartnerHandler.Handle(requestPartnerInfo);
        }
    }
}