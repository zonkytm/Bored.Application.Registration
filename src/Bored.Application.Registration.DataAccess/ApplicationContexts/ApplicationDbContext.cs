using Bored.Application.Registration.DataAccess.Users;
using LinqToDB;
using LinqToDB.Data;

namespace Bored.Application.Registration.DataAccess.ApplicationContexts;

public class ApplicationDbContext : DataConnection
{
    public ApplicationDbContext(DataOptions options) : base(options)
    {
    }

    public ITable<UserEntity> Users => this.GetTable<UserEntity>();
}