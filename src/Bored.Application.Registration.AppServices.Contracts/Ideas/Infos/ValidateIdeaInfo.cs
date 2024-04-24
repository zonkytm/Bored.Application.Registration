namespace Bored.Application.Registration.AppServices.Contracts.Ideas.Infos;

public class ValidateIdeaInfo
{
    /// <summary>
    /// Идентификатор идеи.
    /// </summary>
    public long IdeaKey { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public long TelegramId { get; set; }
    
    /// <summary>
    /// Текст идеи.
    /// </summary>
    public string? IdeaText { get; set; }
}