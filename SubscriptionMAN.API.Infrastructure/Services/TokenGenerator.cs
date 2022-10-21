using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SubscriptionMAN.API.Core.Constants;
using SubscriptionMAN.API.Core.Interfaces;
using SubscriptionMAN.API.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Services;
public class TokenGenerator : ITokenGenerator
{
    private readonly UserManager<ApplicationUser> _userManager;

    public TokenGenerator(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public string GenerateToken(string userName, int lifeTimeInMinutes)
    {

        var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(AuthorizationConstants.JWT_SECRET_KEY));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



        var claims = new List<Claim> 
        { 
            new Claim(ClaimTypes.Name, userName),
        };


        var jwtSecurityToken = new JwtSecurityToken(
                AuthorizationConstants.Issuer,
                AuthorizationConstants.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(lifeTimeInMinutes),
                signingCredentials
                );

        var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return tokenToReturn;
    }
}
