using System.ComponentModel.DataAnnotations;
using LinqToDB.Mapping;

namespace Bored.Application.Registration.DataAccess.Users;

[LinqToDB.Mapping.Table( Schema = "bored_schema" , Name = "users")]
public class UserEntity
{
    [PrimaryKey]
    [Column("telegram_id")]
    public long TelegramId { get; set; }

    [Required]
    [Column("chat_id")]
    public long ChatId { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }

    [Column("user_name")]
    public string UserName { get; set; }

    [Column("partner_id")]
    public long PartnerId { get; set; } = 0;
}