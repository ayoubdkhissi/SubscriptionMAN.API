using FluentValidation;

namespace SubscriptionMAN.API.Presentation.DTOs;

public class RegisterDto
{
    public string UserName { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;   
    public string Email { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;

}

