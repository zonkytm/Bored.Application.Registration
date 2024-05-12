namespace Bored.Application.Registration.Api.Contracts.Activities;

/// <summary>
/// Модель идеи.
/// </summary>
public class Activity
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