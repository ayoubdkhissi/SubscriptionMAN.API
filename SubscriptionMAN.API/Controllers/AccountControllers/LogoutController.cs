using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubscriptionMAN.API.Core.Interfaces;
using SubscriptionMAN.API.Presentation.Utils.Responses;
using System.Security.Claims;

namespace SubscriptionMAN.API.Presentation.Controllers.AccountControllers;
public class LogoutController : Controller
{
    private readonly IIdentityService _identityService;
    private readonly ILogger<LogoutController> _logger;

    public LogoutController(IIdentityService identityService, ILogger<LogoutController> logger)
    {
        _identityService = identityService;
        _logger = logger;
    }


    [Authorize]
    [HttpPost("api/logout")]
    public async Task<IActionResult> LogOutAsync()
    {

        return Ok();
    }
}
