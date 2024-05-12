using Bored.Application.Registration.AppServices.Contracts.Activities.Infos;
using Bored.Application.Registration.AppServices.Contracts.Activities.Validators;

namespace Bored.Application.Registration.AppServices.Activities.Validators;

public class ActivityValidator : IActivityValidator
{
    public bool Validate(ValidateActivityInfo model)
    {
        var errorList = new List<string>();

        if (model.TelegramId <= 0)
        {
            errorList.Add("Идентфикатор пользователя не может быть меньше 0.");

        }

        if (string.IsNullOrWhiteSpace(model.ActivityText) || model.ActivityText.Length == 0)
        {
            errorList.Add("Текст идеи не может быть пустым.");
        }

        return errorList.Any();
    }
}