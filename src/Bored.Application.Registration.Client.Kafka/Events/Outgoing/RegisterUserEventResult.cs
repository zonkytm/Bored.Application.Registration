using Bored.Application.Registration.Client.Kafka.Enums;
using DCS.Platform.Kafka.Abstractions;
using DCS.Platform.Kafka.Abstractions.Attributes;

namespace Bored.Application.Registration.Client.Kafka.Events.Outgoing;

/// <summary>
/// Результат регистрации пользователя.
/// </summary>
[KafkaTopic("register-user-event-result")]
public class RegisterUserEventResult : IKafkaMessage
{
   /// <summary>
   /// Идентификатор чата пользователя.
   /// </summary>
   public long ChatId { get; set; }
   
   /// <summary>
   /// Статус регистрации пользователя.
   /// </summary>
   public RegisterStatus RegisterStatus { get; set; }
}