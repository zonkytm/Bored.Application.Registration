namespace Bored.Application.Registration.Api.Contracts;

/// <summary>
/// Модель идеи.
/// </summary>
public class Idea
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