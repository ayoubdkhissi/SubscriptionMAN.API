using FluentValidation;
using SubscriptionMAN.API.Presentation.DTOs;

namespace SubscriptionMAN.API.Presentation.Validators.DtoValidators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(registerDto => registerDto.UserName).NotEmpty();

        RuleFor(registerDto => registerDto.Email).EmailAddress();

    }
}