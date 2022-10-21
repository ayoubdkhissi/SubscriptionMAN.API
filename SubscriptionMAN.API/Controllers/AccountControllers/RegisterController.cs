using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SubscriptionMAN.API.Core;
using SubscriptionMAN.API.Core.Interfaces;
using SubscriptionMAN.API.Infrastructure.Identity;
using SubscriptionMAN.API.Presentation.DTOs;
using SubscriptionMAN.API.Presentation.Utils.Responses;

namespace SubscriptionMAN.API.Presentation.Controllers.AccountControllers;
public class RegisterController : Controller
{
    private readonly IValidator<RegisterDto> _validator;
    private readonly IIdentityService _identityService;

    public RegisterController(IValidator<RegisterDto> validator, IIdentityService identityService)
    {
        _validator = validator;
        _identityService = identityService;
    }

    [HttpPost("api/register")]
    public async Task<ActionResult> RegisterAsync([FromBody] RegisterDto registerDTO)
    {
        var response = new RegisterResponse();

        ValidationResult validation_result = await _validator.ValidateAsync(registerDTO);
        if(!validation_result.IsValid)
        {
            response.Errors = validation_result.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest(response);
        }


        var result = await _identityService
            .RegisterAsync(registerDTO.UserName,
            registerDTO.Email,
            registerDTO.PhoneNumber,
            registerDTO.Password);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        response.Message = $"User {registerDTO.UserName} has been registered successfully";
        return Ok(response);
    }

}
