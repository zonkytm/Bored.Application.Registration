using Bored.Application.Registration.AppServices.Contracts.Activities.Repositories;
using Bored.Application.Registration.AppServices.Contracts.Users.Repositories;
using Bored.Application.Registration.DataAccess.Activities.Repositories;
using Bored.Application.Registration.DataAccess.ApplicationContexts;
using Bored.Application.Registration.DataAccess.Users.Repositories;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bored.Application.Registration.DataAccess.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLinqToDBContext<ApplicationDbContext>((provider, options)
        => options.UsePostgreSQL(configuration.GetConnectionString("Default")));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
    }
}