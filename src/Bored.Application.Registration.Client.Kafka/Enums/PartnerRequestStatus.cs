namespace Bored.Application.Registration.Client.Kafka.Enums;

/// <summary>
/// Статус запроса на добавления партнера.
/// </summary>
public enum PartnerRequestStatus
{
    /// <summary>
    /// Запрос на добавление принят.
    /// </summary>
    Accepted,

    /// <summary>
    /// Запрос на добавление отклонен.
    /// </summary>
    Denied,

    /// <summary>
    /// Партнер добавлен.
    /// </summary>
    AlreadyPartners
}