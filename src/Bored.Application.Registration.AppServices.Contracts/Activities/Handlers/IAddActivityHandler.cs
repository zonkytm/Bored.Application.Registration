using Bored.Application.Registration.AppServices.Contracts.Activities.Infos;

namespace Bored.Application.Registration.AppServices.Contracts.Activities.Handlers;

public interface IAddActivityHandler
{
    Task Handle(AddActivityInfo addIdeaInfo);
}