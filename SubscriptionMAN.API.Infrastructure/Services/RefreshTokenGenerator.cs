using SubscriptionMAN.API.Core.Constants;
using SubscriptionMAN.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Services;
public class RefreshTokenGenerator : IRefershTokenGenerator
{
    private readonly ITokenGenerator _tokenGenerator;

    public RefreshTokenGenerator(ITokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    public string GenerateRefreshToken(string userName)
    {
        return _tokenGenerator.GenerateToken(userName, AuthorizationConstants.RefreshTokenLifeTime);
    }
}
