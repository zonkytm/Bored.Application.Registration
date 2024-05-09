namespace Bored.Application.Registration.Client.Kafka.Enums;

/// <summary>
/// Статусы события регистрации.
/// </summary>
public enum RegisterStatus
{
    /// <summary>
    /// Новый пользователь добавлен.
    /// </summary>
    Registered,

    /// <summary>
    /// Пользователь с такими данными уже существовал
    /// </summary>
    AlreadyExisted
}