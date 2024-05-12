using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Users.Infos;
using Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Producers;
using Bored.Application.Registration.AppServices.Contracts.Users.Repositories;

namespace Bored.Application.Registration.AppServices.Users.Handlers;

public class AddPartnerHandler : IAddPartnerHandler
{
    private readonly IRequestPartnerEventResultProducer _requestPartnerEventResultProducer;
    private readonly IUserRepository _repository;

    public AddPartnerHandler(IRequestPartnerEventResultProducer requestPartnerEventResultProducer, IUserRepository repository)
    {
        _requestPartnerEventResultProducer = requestPartnerEventResultProducer;
        _repository = repository;
    }

    public async Task Handle(AddPartnerInfo addPartnerInfo)
    {
        var partner = await _repository.GetUserById(addPartnerInfo.PartnerId);

        await _repository.AddPartner(addPartnerInfo.TelegramId, partner.TelegramId);
        await _repository.AddPartner(partner.TelegramId, addPartnerInfo.TelegramId);
    }
}