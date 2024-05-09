using Bored.Application.Registration.Client.Kafka.Enums;
using DCS.Platform.Kafka.Abstractions;
using DCS.Platform.Kafka.Abstractions.Attributes;

namespace Bored.Application.Registration.Client.Kafka.Events.Outgoing;

/// <summary>
/// Результат события запроса на добавления партнера.
/// </summary>
[KafkaTopic("request-partner-event-result")]
public class RequestPartnerEventResult : IKafkaMessage
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public long TelegramId { get; set; }

    /// <summary>
    /// Статус добавления партнера.
    /// </summary>
    public PartnerRequestStatus Status { get; set; }
}