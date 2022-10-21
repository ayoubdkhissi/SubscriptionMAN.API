using SubscriptionMAN.API.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Identity.Repository;
public interface IRefreshTokenRepository
{
    Task<RefreshToken> GetByToken(string token);

    Task Create(RefreshToken refreshToken);

    /// <summary>
    /// Delete all refresh token of a given user
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task DeleteAll(string userName);
}
