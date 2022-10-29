using Microsoft.AspNetCore.Mvc;
using SubscriptionMAN.API.Core.Interfaces;
using SubscriptionMAN.API.Infrastructure.Identity.Models;
using SubscriptionMAN.API.Infrastructure.Identity.Repository;
using SubscriptionMAN.API.Infrastructure.Services;
using SubscriptionMAN.API.Presentation.Utils.Requests;
using SubscriptionMAN.API.Presentation.Utils.Responses;

namespace SubscriptionMAN.API.Presentation.Controllers.AccountControllers;
public class RefrechTokenController : Controller
{

    private readonly IRefreshTokenValidator _refreshTokenValidator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public RefrechTokenController(IRefreshTokenValidator refreshTokenValidator,
        IRefreshTokenRepository refreshTokenRepository,
        ITokenGenerator tokenGenerator)
    {
        _refreshTokenValidator = refreshTokenValidator;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost("api/refresh")]
    public async Task<ActionResult<AuthResponse>> Refresh([FromBody] RefreshTokenRequest refreshTokenRequest)
    {
        bool validation_result = _refreshTokenValidator.validate(refreshTokenRequest.RefreshToken);

        if (!validation_result)
        {
            return BadRequest(new ErrorResponse 
            { 
                Errors = new List<string>() { "invalid refresh token" } 
            });
        }

        RefreshToken refreshToken = await _refreshTokenRepository
            .GetByToken(refreshTokenRequest.RefreshToken);
        
        if(refreshToken == null)
        {
            return NotFound(new ErrorResponse
            {
                Errors = new List<string>() { "invalid refresh token" }
            });
        }

        // Generate new token:
        string new_token = _tokenGenerator.GenerateToken(refreshToken.UserName);
        var response = new AuthResponse();

        response.IsSuccess = true;
        response.Token = new_token;
        response.Username = refreshToken.UserName;
        response.RefreshToken = refreshToken.Token;
        
        return Ok(response);
    }
}
