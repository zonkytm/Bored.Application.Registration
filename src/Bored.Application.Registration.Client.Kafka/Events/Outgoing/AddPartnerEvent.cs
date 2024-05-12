using Bored.Application.Registration.Api.Contracts.Users;
using DCS.Platform.Kafka.Abstractions;
using DCS.Platform.Kafka.Abstractions.Attributes;

namespace Bored.Application.Registration.Client.Kafka.Events.Outgoing;

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
    public User PotentialPartner { get; set; }
}