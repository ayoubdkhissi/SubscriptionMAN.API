using FluentValidation;
using SubscriptionMAN.API.Core.Entities;
using SubscriptionMAN.API.Presentation.Utils.Responses;

namespace SubscriptionMAN.API.Presentation.Validators;

public class SubscriptionServiceDtoValidator : AbstractValidator<SubscriptionServiceForListingDTO>
{
    public SubscriptionServiceDtoValidator()
    {
        RuleFor(subscriptionService => subscriptionService.Name).NotEmpty();
    }
}
