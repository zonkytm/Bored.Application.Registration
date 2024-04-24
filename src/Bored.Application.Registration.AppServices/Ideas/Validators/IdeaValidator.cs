using Bored.Application.Registration.AppServices.Contracts.Ideas.Infos;
using Bored.Application.Registration.AppServices.Contracts.Ideas.Validators;

namespace Bored.Application.Registration.AppServices.Ideas.Validators;

public class IdeaValidator : IIdeaValidator
{
    public bool Validate(ValidateIdeaInfo model)
    {
        var errorList = new List<string>();

        if (model.IdeaKey <= 0)
        {
            errorList.Add("Идентфикатор идеи не может быть меньше 0.");
        }

        if (model.TelegramId <= 0)
        {
            errorList.Add("Идентфикатор пользователя не может быть меньше 0.");

        }

        if (string.IsNullOrWhiteSpace(model.IdeaText) || model.IdeaText.Length == 0)
        {
            errorList.Add("Текст идеи не может быть пустым.");
        }

        return errorList.Any();
    }
}