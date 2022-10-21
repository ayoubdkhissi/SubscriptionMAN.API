using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SubscriptionMAN.API.Core.Constants;
using SubscriptionMAN.API.Core.Interfaces;
using SubscriptionMAN.API.Infrastructure.Identity.Models;
using SubscriptionMAN.API.Infrastructure.Identity.Repository;
using SubscriptionMAN.API.Presentation.Utils.Requests;
using SubscriptionMAN.API.Presentation.Utils.Responses;

namespace SubscriptionMAN.API.Presentation.Controllers.AccountControllers;
public class AuthController : Controller
{
    private readonly IIdentityService _identityService;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IRefershTokenGenerator _refershTokenGenerator;
    private readonly ILogger<AuthController> _logger;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthController(SignInManager<ApplicationUser> signInManager,
        ITokenGenerator tokenGenerator,
        ILogger<AuthController> logger,
        IIdentityService identityService,
        IRefershTokenGenerator refershTokenGenerator,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _tokenGenerator = tokenGenerator;
        _logger = logger;
        _identityService = identityService;
        _refershTokenGenerator = refershTokenGenerator;
        _refreshTokenRepository = refreshTokenRepository;
    }

    [HttpPost("api/authenticate")]
    public async Task<ActionResult<AuthResponse>> AuthenticateAsync([FromBody] AuthRequest authRequest)
    {
        _logger.LogInformation("Authentication Attempt by user : {info}", 
            new { UserName = authRequest.Username });

        var response = new AuthResponse();

        var auth_result = await _identityService
            .AuthenticateAsync(authRequest.Username, authRequest.Password);

        response.Result = auth_result.Success;
        response.Username = authRequest.Username;
        

        if(auth_result.Success)
        {
            response.Token = _tokenGenerator
                .GenerateToken(authRequest.Username);
            response.RefreshToken = _refershTokenGenerator.GenerateRefreshToken(authRequest.Username);

            // Removing old refresh token
            await _refreshTokenRepository.DeleteAll(authRequest.Username);
            // Storing the refresh token in the database
            await _refreshTokenRepository.Create(new RefreshToken 
            { 
                Token = response.RefreshToken,
                UserName = authRequest.Username
            });
        }
        return response;
    }

}
