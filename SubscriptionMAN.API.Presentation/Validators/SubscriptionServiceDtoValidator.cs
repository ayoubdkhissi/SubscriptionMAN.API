using FluentValidation;
using SubscriptionMAN.API.Core.Entities;
using SubscriptionMAN.API.Presentation.Utils.Requests;

namespace SubscriptionMAN.API.Presentation.Validators;

public class SubscriptionServiceDtoValidator : AbstractValidator<SubscriptionServiceDTO>
{
    public SubscriptionServiceDtoValidator()
    {
        RuleFor(subscriptionService => subscriptionService.Name).NotEmpty();
    }
}
