using Bored.Application.Registration.AppServices.Contracts.Ideas.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Ideas.Infos;
using Bored.Application.Registration.AppServices.Contracts.Ideas.Repositories;
using Bored.Application.Registration.AppServices.Contracts.Ideas.Validators;

namespace Bored.Application.Registration.AppServices.Ideas.Handlers;

public class AddIdeaHandler : IAddIdeaHandler
{
    private readonly IIdeaRepository _repository;

    private readonly IIdeaValidator _validator; 
    
    public AddIdeaHandler(IIdeaRepository repository, IIdeaValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task Handle(AddIdeaInfo addIdeaInfo)
    {
        if (addIdeaInfo == null)
        {
            return;
        }

        var validateInfo = new ValidateIdeaInfo
        {
            IdeaKey = addIdeaInfo.IdeaKey,
            TelegramId = addIdeaInfo.TelegramId,
            IdeaText = addIdeaInfo.IdeaText
        };

        if (_validator.Validate(validateInfo))
        {
            return;
        }
        
        await _repository.AddIdea(addIdeaInfo);
    }
}