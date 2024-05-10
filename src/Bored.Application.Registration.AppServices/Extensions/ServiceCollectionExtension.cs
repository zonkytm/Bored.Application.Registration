using Bored.Application.Registration.AppServices.Activities.Handlers;
using Bored.Application.Registration.AppServices.Activities.Validators;
using Bored.Application.Registration.AppServices.Contracts.Activities.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Activities.Validators;
using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;
using Bored.Application.Registration.AppServices.Users.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Bored.Application.Registration.AppServices.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<IAddUserHandler, AddUserHandler>();
        services.AddScoped<IAddActivityHandler, AddActivityHandler>();
        services.AddScoped<IFindUserHandler, FindUserHandler>();
        services.AddScoped<IAddPartnerHandler, AddPartnerHandler>();
        services.AddScoped<IRequestPartnerHandler, RequestPartnerHandler>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IActivityValidator, ActivityValidator>();
        services.AddScoped<IGetUserActivitiesHandler, GetUserActivitiesHandler>();
    }
}