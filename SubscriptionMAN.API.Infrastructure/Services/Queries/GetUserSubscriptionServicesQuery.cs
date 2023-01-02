using Microsoft.EntityFrameworkCore;
using SubscriptionMAN.API.Core.Constants;
using SubscriptionMAN.API.Core.Entities;
using SubscriptionMAN.API.Core.Interfaces.Queries;
using SubscriptionMAN.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Services.Queries;
public class GetUserSubscriptionServicesQuery : IGetUserSubscriptionServicesQuery
{
    private readonly AppDbContext _appBbContext;

    public GetUserSubscriptionServicesQuery(AppDbContext appBbContext)
    {
        _appBbContext = appBbContext;
    }

    public async Task<IEnumerable<SubscriptionService>> 
        GetUserSubscriptionServicesAsync(string userName,
        int pageNumber = PaginationConstants.DefaultPageNumber,
        int pageSize = PaginationConstants.DefaultPageSize)
    {
        return await _appBbContext.SubscriptionServices
            .Skip(pageSize*(pageNumber-1))
            .Take(pageSize)
            .Where(ss => ss.UserName == userName)
            .ToListAsync();
    }
}
