namespace Bored.Application.Registration.Api.Contracts.Users;

public class User
{
    public long ChatId { get; set; }
    public long TelegramId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string UserName { get; set; }
    
}