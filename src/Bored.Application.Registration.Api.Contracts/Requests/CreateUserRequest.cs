namespace Bored.Application.Registration.Api.Contracts.Requests;

public class CreateUserRequest
{
    public long ChatId { get; set; }
    public long TelegramId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string UserName { get; set; }
}