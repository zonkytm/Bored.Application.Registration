using DCS.Platform.Kafka.Abstractions;
using DCS.Platform.Kafka.Abstractions.Attributes;

namespace Bored.Application.Registration.Client.Kafka.Events;

/// <summary>
/// Событие регистрации пользователя.
/// </summary>
[KafkaTopic("register-user-event")]
public class RegisterUserEvent : IKafkaMessage
{
    /// <summary>
    /// Идентификатор чата пользователя
    /// </summary>
    public long ChatId { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя в телеграмм.
    /// </summary>
    public long TelegramId { get; set; }
    
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Ник пользователя.
    /// </summary>
    public string UserName { get; set; }
}