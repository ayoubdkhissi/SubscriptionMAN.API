using FluentValidation;
using SubscriptionMAN.API.Presentation.Utils.Requests;
using SubscriptionMAN.API.Presentation.Utils.Responses;

namespace SubscriptionMAN.API.Presentation.Validators;

public static class ValidatorsInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterRequest>, RegisterDtoValidator>();
        
        services.AddScoped<IValidator<SubscriptionServiceForListingDTO>, SubscriptionServiceDtoValidator>();

        return services;
    }
}
