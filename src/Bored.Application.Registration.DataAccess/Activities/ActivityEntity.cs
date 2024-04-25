using LinqToDB.Mapping;

namespace Bored.Application.Registration.DataAccess.Activities;

/// <summary>
/// Модель идеи.
/// </summary>
[Table(Schema = "bored_schema", Name = "activities")]
public class ActivityEntity
{
    /// <summary>
    /// Идентификатор идеи.
    /// </summary>
    [PrimaryKey]
    [Column("activity_id"), Identity]
    public long ActivityId { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    [Column("telegram_id")]
    public long TelegramId { get; set; }
    
    /// <summary>
    /// Текст идеи.
    /// </summary>
    [Column("activity_text")]
    public string? ActivityText { get; set; }
}