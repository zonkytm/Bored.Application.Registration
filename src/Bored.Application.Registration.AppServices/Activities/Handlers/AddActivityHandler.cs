using Bored.Application.Registration.AppServices.Contracts.Activities.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Activities.Infos;
using Bored.Application.Registration.AppServices.Contracts.Activities.Repositories;
using Bored.Application.Registration.AppServices.Contracts.Activities.Validators;

namespace Bored.Application.Registration.AppServices.Activities.Handlers;

public class AddActivityHandler : IAddActivityHandler
{
    private readonly IActivityRepository _repository;

    private readonly IActivityValidator _validator; 
    
    public AddActivityHandler(IActivityRepository repository, IActivityValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task Handle(AddActivityInfo addIdeaInfo)
    {
        if (addIdeaInfo == null)
        {
            return;
        }

        var validateInfo = new ValidateActivityInfo
        {
            ActivityKey = addIdeaInfo.ActivityId,
            TelegramId = addIdeaInfo.TelegramId,
            ActivityText = addIdeaInfo.ActivityText
        };

        if (_validator.Validate(validateInfo))
        {
            return;
        }
        
        await _repository.AddActivity(addIdeaInfo);
    }
}