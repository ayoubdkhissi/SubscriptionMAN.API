﻿using FluentValidation;

namespace SubscriptionMAN.API.Presentation.Utils.Requests;

public class RegisterRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

}

