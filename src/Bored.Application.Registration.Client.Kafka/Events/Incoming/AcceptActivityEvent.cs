using DCS.Platform.Kafka.Abstractions;
using DCS.Platform.Kafka.Abstractions.Attributes;

namespace Bored.Application.Registration.Client.Kafka.Events.Incoming;

/// <summary>
/// Событие добавления идеи пользователю.
/// </summary>
[KafkaTopic("accept-activity-event")]
public class AcceptActivityEvent : IKafkaMessage
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