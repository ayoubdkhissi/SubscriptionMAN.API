using Microsoft.EntityFrameworkCore;
using SubscriptionMAN.API.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Identity.Repository;
public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly IdentityUserDbContext _identityDbContext;

    public RefreshTokenRepository(IdentityUserDbContext identityDbContext)
    {
        this._identityDbContext = identityDbContext;
    }

    public async Task Create(RefreshToken refreshToken)
    {
        _identityDbContext.RefreshTokens.Add(refreshToken);
        await _identityDbContext.SaveChangesAsync();
    }



    public async Task DeleteAll(string userName)
    {
        IEnumerable<RefreshToken> refreshTokens = await _identityDbContext.RefreshTokens
                .Where(t => t.UserName == userName)
                .ToListAsync();

        _identityDbContext.RefreshTokens.RemoveRange(refreshTokens);
        await _identityDbContext.SaveChangesAsync();
    }

    public async Task<RefreshToken> GetByToken(string token)
    {
        return await _identityDbContext.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);

    }
}
