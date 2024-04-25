namespace Bored.Application.Registration.AppServices.Contracts.Activities.Infos;

/// <summary>
/// Модель для работы с идеями.
/// </summary>
public class AddActivityInfo
{
    /// <summary>
    /// Идентификатор идеи.
    /// </summary>
    public long ActivityId { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public long TelegramId { get; set; }
    
    /// <summary>
    /// Текст идеи.
    /// </summary>
    public string? ActivityText { get; set; }
}