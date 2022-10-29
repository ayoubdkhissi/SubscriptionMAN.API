using SubscriptionMAN.API.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Core.Interfaces;
public interface ITokenGenerator
{
    string GenerateToken(string userName, int lifeTimeInMinutes = AuthorizationConstants.TokenLifeTime);

}
