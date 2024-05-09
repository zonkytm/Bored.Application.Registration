using Bored.Application.Registration.Client.Kafka.Enums;
using DCS.Platform.Kafka.Abstractions;
using DCS.Platform.Kafka.Abstractions.Attributes;

namespace Bored.Application.Registration.Client.Kafka.Events.Outgoing;

/// <summary>
/// Резудьтат события добавления в партнеры к пользователю.
/// </summary>
[KafkaTopic("add-partner-event-result")]
public class AddPartnerEventResult : IKafkaMessage
{
    /// <summary>
    /// Идентификатор пользователя который добавлялся в партнеры.
    /// </summary>
    public long TelegramId { get; set; }

    /// <summary>
    /// Результат запроса в партнеры.
    /// </summary>
    public AddPartnerStatus Status { get; set; }
}