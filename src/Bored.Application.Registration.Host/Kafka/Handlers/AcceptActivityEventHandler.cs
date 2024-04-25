using Bored.Application.Registration.AppServices.Contracts.Activities.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Activities.Infos;
using Bored.Application.Registration.AppServices.Contracts.Kafka.Handlers;
using Bored.Application.Registration.Client.Kafka.Events.Incoming;
using KafkaFlow;

namespace Bored.Application.Registration.Host.Kafka.Handlers;

public class AcceptActivityEventHandler : IAcceptActivityEventHandler
{
    private readonly IAddActivityHandler _addActivityHandler;


    public AcceptActivityEventHandler(IAddActivityHandler activityHandler)
    {
        _addActivityHandler = activityHandler;
    }


    public async Task Handle(IMessageContext context, AcceptActivityEvent message)
    {

        if (message == null)
        {
            return;
        }

        var addUserInfo = new AddActivityInfo
        {
            ActivityId = message.ActivityId,
            TelegramId = message.TelegramId,
            ActivityText = message.ActivityText
        };

        await _addActivityHandler.Handle(addUserInfo);
    }
}