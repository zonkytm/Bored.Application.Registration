using Bored.Application.Registration.Client.Kafka.Enums;
using DCS.Platform.Kafka.Abstractions;
using DCS.Platform.Kafka.Abstractions.Attributes;

namespace Bored.Application.Registration.Client.Kafka.Events.Incoming;

/// <summary>
/// Результат события добавления в партнеры к пользователю.
/// </summary>
[KafkaTopic("add-partner-event-result")]
public class AddPartnerEventResult : IKafkaMessage
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public long TelegramId { get; set; }

    /// <summary>
    /// Идентификатор пользователя который добавлялся в партнеры.
    /// </summary>
    public string PartnerUsername { get; set; }

    /// <summary>
    /// Результат запроса в партнеры.
    /// </summary>
    public AddPartnerStatus Status { get; set; }
}