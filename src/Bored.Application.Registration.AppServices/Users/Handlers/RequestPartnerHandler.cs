using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Users.Infos;
using Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Producers;
using Bored.Application.Registration.AppServices.Contracts.Users.Repositories;
using Bored.Application.Registration.Client.Kafka.Enums;
using Bored.Application.Registration.Client.Kafka.Events.Outgoing;

namespace Bored.Application.Registration.AppServices.Users.Handlers;

public class RequestPartnerHandler : IRequestPartnerHandler
{
    private readonly IUserRepository _repository;
    private readonly IRequestPartnerEventResultProducer _requestPartnerEventResultProducer;
    private readonly IAddPartnerEventProducer _addPartnerEventProducer;

    public RequestPartnerHandler(IUserRepository repository, IRequestPartnerEventResultProducer requestPartnerEventResultProducer, IAddPartnerEventProducer addPartnerEventProducer)
    {
        _repository = repository;
        _requestPartnerEventResultProducer = requestPartnerEventResultProducer;
        _addPartnerEventProducer = addPartnerEventProducer;
    }

    public async Task Handle(RequestPartnerInfo requestPartnerInfo)
    {
        var user = await _repository.GetUserById(requestPartnerInfo.TelegramId);

        var partner = await _repository.GetUserByUserName(requestPartnerInfo.PartnerUsername);

        if (user == null || partner == null)
        {
            return;
        }

        if (user.PartnerId == partner.TelegramId)
        {
            var requestPartnerEventResult = new RequestPartnerEventResult
            {
                TelegramId = requestPartnerInfo.TelegramId,
                Status = PartnerRequestStatus.AlreadyPartners
            };

            await _requestPartnerEventResultProducer.ProduceRequestPartnerEventResultAsync(requestPartnerEventResult);
        }
        else
        {
            var addPartnerEvent = new AddPartnerEvent
            {
                TelegramId = partner.TelegramId,
                PotentialPartnerUsername = user
            };

            await _addPartnerEventProducer.ProduceAddPartnerEventAsync(addPartnerEvent);
        }
    }
}