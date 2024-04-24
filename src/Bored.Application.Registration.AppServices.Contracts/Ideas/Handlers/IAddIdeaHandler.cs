using Bored.Application.Registration.AppServices.Contracts.Ideas.Infos;

namespace Bored.Application.Registration.AppServices.Contracts.Ideas.Handlers;

public interface IAddIdeaHandler
{
    Task Handle(AddIdeaInfo addIdeaInfo);
}