using FluentValidation;
using SubscriptionMAN.API.Presentation.Utils.Requests;

namespace SubscriptionMAN.API.Presentation.Validators;

public static class ValidatorsInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterRequest>, RegisterDtoValidator>();
        
        services.AddScoped<IValidator<SubscriptionServiceDTO>, SubscriptionServiceDtoValidator>();

        return services;
    }
}
