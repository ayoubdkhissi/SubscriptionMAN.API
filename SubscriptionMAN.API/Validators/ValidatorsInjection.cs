using FluentValidation;
using SubscriptionMAN.API.Presentation.DTOs;
using SubscriptionMAN.API.Presentation.Validators.DtoValidators;

namespace SubscriptionMAN.API.Presentation.Validators;

public static class ValidatorsInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();

        return services;
    }
}
