using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SubscriptionMAN.API.Core.Constants;
using SubscriptionMAN.API.Core.Interfaces;
using SubscriptionMAN.API.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Services;
public class RefreshTokenValidator : IRefreshTokenValidator
{
    public bool validate(string RefreshToken)
    {
        TokenValidationParameters validationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthorizationConstants.JWT_SECRET_KEY)),
            ValidIssuer = AuthorizationConstants.Issuer,
            ValidAudience = AuthorizationConstants.Audience,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            tokenHandler.ValidateToken(RefreshToken, validationParameters, out SecurityToken validatedToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
