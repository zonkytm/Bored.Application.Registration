using Bored.Application.Registration.AppServices.Contracts.Users.Infos;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Handlers;

public interface IAddPartnerHandler
{
    Task Handle(AddPartnerInfo addPartnerInfo);
}