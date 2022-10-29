using FluentValidation;
using SubscriptionMAN.API.Presentation.Utils.Requests;
using SubscriptionMAN.API.Presentation.Validators.DtoValidators;

namespace SubscriptionMAN.API.Presentation.Validators;

public static class ValidatorsInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterRequest>, RegisterDtoValidator>();

        return services;
    }
}
