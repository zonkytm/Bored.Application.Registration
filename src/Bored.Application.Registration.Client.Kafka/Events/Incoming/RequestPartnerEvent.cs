using DCS.Platform.Kafka.Abstractions;
using DCS.Platform.Kafka.Abstractions.Attributes;

namespace Bored.Application.Registration.Client.Kafka.Events.Incoming;

/// <summary>
/// Событие запроса на добавления партнера.
/// </summary>
[KafkaTopic("request-partner-event-result")]
public class RequestPartnerEvent : IKafkaMessage
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public long TelegramId { get; set; }

    /// <summary>
    /// Ник потенциального партнера.
    /// </summary>
    public string PartnerUsername { get; set; }
}