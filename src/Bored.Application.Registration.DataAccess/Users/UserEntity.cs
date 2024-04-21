using System.ComponentModel.DataAnnotations;
using LinqToDB.Mapping;

namespace Bored.Application.Registration.DataAccess.Users;

[LinqToDB.Mapping.Table( Schema = "bored_schema" , Name = "users")]
public class UserEntity
{
    [Key]
    [LinqToDB.Mapping.Column("id")]
    public Guid Id { get; set; }

    [Required]
    [LinqToDB.Mapping.Column("chat_id")]
    public long ChatId { get; set; }
    
    [Required]
    [LinqToDB.Mapping.Column("telegram_id")]
    public long TelegramId { get; set; }

    [LinqToDB.Mapping.Column("first_name")]
    public string FirstName { get; set; }

    [LinqToDB.Mapping.Column("last_name")] public string LastName { get; set; }

    [LinqToDB.Mapping.Column("user_name")] public string UserName { get; set; }

    [LinqToDB.Mapping.Column("user_love_id")]
    public Guid? UserLoveId { get; set; } = Guid.Empty;
}