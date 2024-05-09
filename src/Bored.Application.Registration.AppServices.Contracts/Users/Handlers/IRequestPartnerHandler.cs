using Bored.Application.Registration.AppServices.Contracts.Users.Infos;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Handlers;

public interface IRequestPartnerHandler
{
    Task Handle(RequestPartnerInfo requestPartnerInfo);
}