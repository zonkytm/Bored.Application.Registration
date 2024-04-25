namespace Bored.Application.Registration.AppServices.Contracts.Activities.Infos;

public class ValidateActivityInfo
{
    /// <summary>
    /// Идентификатор идеи.
    /// </summary>
    public long ActivityKey { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public long TelegramId { get; set; }
    
    /// <summary>
    /// Текст идеи.
    /// </summary>
    public string? ActivityText { get; set; }
}