using System.ComponentModel.Design;
using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Bored.Application.Registration.AppServices.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<IAddUserHandler, AddUserHandler>();
    }
}