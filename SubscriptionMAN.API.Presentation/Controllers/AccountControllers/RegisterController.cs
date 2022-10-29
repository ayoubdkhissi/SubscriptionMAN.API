using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SubscriptionMAN.API.Core;
using SubscriptionMAN.API.Core.Interfaces;
using SubscriptionMAN.API.Infrastructure.Identity;
using SubscriptionMAN.API.Presentation.Utils.Requests;
using SubscriptionMAN.API.Presentation.Utils.Responses;

namespace SubscriptionMAN.API.Presentation.Controllers.AccountControllers;
public class RegisterController : Controller
{
    private readonly IValidator<RegisterRequest> _validator;
    private readonly IIdentityService _identityService;

    public RegisterController(IValidator<RegisterRequest> validator, IIdentityService identityService)
    {
        _validator = validator;
        _identityService = identityService;
    }

    [HttpPost("api/register")]
    public async Task<ActionResult<RegisterResponse>> RegisterAsync([FromBody] RegisterRequest registerRequest)
    {
        var response = new RegisterResponse();

        ValidationResult validation_result = await _validator.ValidateAsync(registerRequest);
        if(!validation_result.IsValid)
        {
            response.Errors = validation_result.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest(response);
        }


        var result = await _identityService
            .RegisterAsync(registerRequest.UserName,
            registerRequest.Email,
            registerRequest.PhoneNumber,
            registerRequest.Password);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        response.Message = $"User {registerRequest.UserName} has been registered successfully";
        return Ok(response);
    }

}
