namespace Bored.Application.Registration.AppServices.Contracts.Users.Infos;

public class AddUserInfo
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