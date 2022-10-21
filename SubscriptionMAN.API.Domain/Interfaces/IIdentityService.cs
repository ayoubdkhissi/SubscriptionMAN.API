using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionMAN.API.Core.Common;

namespace SubscriptionMAN.API.Core.Interfaces;
public interface IIdentityService
{
    Task<Result> RegisterAsync(string userName, string email, string phoneNumber, string password);

    Task<Result> AuthenticateAsync(string userName, string password);
}
