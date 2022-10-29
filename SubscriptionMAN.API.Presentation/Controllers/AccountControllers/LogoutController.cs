using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubscriptionMAN.API.Core.Interfaces;
using SubscriptionMAN.API.Infrastructure.Identity.Repository;
using SubscriptionMAN.API.Presentation.Utils.Requests;
using SubscriptionMAN.API.Presentation.Utils.Responses;
using System.Security.Claims;

namespace SubscriptionMAN.API.Presentation.Controllers.AccountControllers;
public class LogoutController : Controller
{
    private readonly IIdentityService _identityService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ILogger<LogoutController> _logger;

    public LogoutController(IIdentityService identityService, 
        ILogger<LogoutController> logger, 
        IRefreshTokenRepository refreshTokenRepository)
    {
        _identityService = identityService;
        _logger = logger;
        _refreshTokenRepository = refreshTokenRepository;
    }


    [Authorize]
    [HttpPost("api/logout")]
    public async Task<IActionResult> LogOutAsync()
    {

        if (User.Identity == null)
            return BadRequest("user is null");
        string username = User.Identity.Name;
        await _refreshTokenRepository.DeleteAll(username);

        return Ok(new LogoutResponse 
        { 
            IsSuccess = true, Message = "User Has Successfully logged out" 
        });

    }
}
