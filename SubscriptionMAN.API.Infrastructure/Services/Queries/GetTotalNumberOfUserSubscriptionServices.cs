using Microsoft.EntityFrameworkCore;
using SubscriptionMAN.API.Core.Interfaces.Queries;
using SubscriptionMAN.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Services.Queries;
public class GetTotalNumberOfUserSubscriptionServices : IGetTotalNumberOfUserSubscriptionServices
{
    private readonly AppDbContext _appDbContext;

    public GetTotalNumberOfUserSubscriptionServices(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Task<int> GetTotalNumberOfUserSubscriptionServicesAsync(string userName)
    {
        return _appDbContext.SubscriptionServices
            .Where(s => s.UserName == userName)
            .CountAsync();
    }
}
