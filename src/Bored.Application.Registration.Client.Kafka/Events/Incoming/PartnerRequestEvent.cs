using DCS.Platform.Kafka.Abstractions;
using DCS.Platform.Kafka.Abstractions.Attributes;

namespace Bored.Application.Registration.Client.Kafka.Events.Incoming;

/// <summary>
/// Событие запроса на добавления партнера.
/// </summary>
[KafkaTopic("partner-request-event-result")]
public class PartnerRequestEvent : IKafkaMessage
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public long TelegramId { get; set; }

    /// <summary>
    /// Идентификатор потенциального партнера.
    /// </summary>
    public long PartnerTelegramId { get; set; }
}