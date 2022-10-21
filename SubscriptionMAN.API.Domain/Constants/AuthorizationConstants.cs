using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Core.Constants;
public static class AuthorizationConstants
{
    public const string AUTH_KEY = "AuthKeyOfDoomThatMustBeAMinimumNumberOfBytes";

    // TODO: Don't use this in production
    public const string DEFAULT_PASSWORD = "Pass@word1";

    // TODO: Change this to an environment variable
    public const string JWT_SECRET_KEY = "this-key-must-be-minimum-32-bit-long";

    public const string Issuer = "SubscriptionMAN_Issuer";

    public const string Audience = "SubscriptionMAN_Audience";

    // This value is in minutes
    public const int TokenLifeTime = 5;

    // this is representing 6 months
    public const int RefreshTokenLifeTime = 259200;
}
