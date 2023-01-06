using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SubscriptionMAN.API.Core.Interfaces;
using SubscriptionMAN.API.Core.Interfaces.Queries;
using SubscriptionMAN.API.Core.Interfaces.Repository;
using SubscriptionMAN.API.Infrastructure.Identity;
using SubscriptionMAN.API.Infrastructure.Identity.Repository;
using SubscriptionMAN.API.Infrastructure.Services;
using SubscriptionMAN.API.Infrastructure.Services.Queries;
using SubscriptionMAN.API.Infrastructure.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure;
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        
        services.Configure<IdentityOptions>(options => {

            options.User.RequireUniqueEmail = true;
        });

        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IRefreshTokenValidator, RefreshTokenValidator>();
        services.AddScoped<IRefershTokenGenerator, RefreshTokenGenerator>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        services.AddScoped<ISubscriptionServiceRepository, SubscriptionServiceRepository>();
        services.AddScoped<IGetUserSubscriptionServicesQuery, GetUserSubscriptionServicesQuery>();
        services.AddScoped<IGetTotalNumberOfUserSubscriptionServices, GetTotalNumberOfUserSubscriptionServices>();
        services.AddScoped<IGetSubscriptionServiceTotalNumberOfClientsQuery, GetSubscriptionServiceTotalNumberOfClientsQuery>();
        services.AddScoped<IGetSubscriptionServiceNumberOfActiveClientsQuery, GetSubscriptionServiceNumberOfActiveClientsQuery>();
        return services;
    }
}
