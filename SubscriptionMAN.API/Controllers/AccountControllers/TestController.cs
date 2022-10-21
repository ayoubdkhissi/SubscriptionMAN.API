using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SubscriptionMAN.API.Core.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Principal;
using System.Text;

namespace SubscriptionMAN.API.Presentation.Controllers.AccountControllers;

public class TestController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public TestController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    [HttpGet("api/test")]
    [Authorize]
    public IActionResult Test()
    {

        string s1 = "Dns hostname: " + Dns.GetHostName();
        string s2 = "\nMachine Name: " + Environment.MachineName;

        return Ok(s1 + s2);
    }

}
