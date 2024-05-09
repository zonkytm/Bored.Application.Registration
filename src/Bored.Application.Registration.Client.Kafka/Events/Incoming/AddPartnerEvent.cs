using DCS.Platform.Kafka.Abstractions;
using DCS.Platform.Kafka.Abstractions.Attributes;

namespace Bored.Application.Registration.Client.Kafka.Events.Incoming;

/// <summary>
/// Событие добавления в партнеры к пользователю.
/// </summary>
[KafkaTopic("add-partner-event")]
public class AddPartnerEvent : IKafkaMessage
{
    /// <summary>
    /// Идентификатор пользователя к которому добавляются в партнеры.
    /// </summary>
    public long TelegramId { get; set; }

    /// <summary>
    /// Идентификатор пользвателя который добавляется в партнеры.
    /// </summary>
    public long PotentialPartnerId { get; set; }
}