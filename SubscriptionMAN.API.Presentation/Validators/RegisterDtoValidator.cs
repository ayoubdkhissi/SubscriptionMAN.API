using FluentValidation;
using SubscriptionMAN.API.Presentation.Utils.Requests;

namespace SubscriptionMAN.API.Presentation.Validators;

public class RegisterDtoValidator : AbstractValidator<RegisterRequest>
{
    public RegisterDtoValidator()
    {
        RuleFor(registerDto => registerDto.UserName).NotEmpty();

        RuleFor(registerDto => registerDto.Email).EmailAddress();

    }
}