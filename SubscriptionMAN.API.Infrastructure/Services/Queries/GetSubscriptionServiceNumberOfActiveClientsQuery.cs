using Microsoft.EntityFrameworkCore;
using SubscriptionMAN.API.Core.Interfaces.Queries;
using SubscriptionMAN.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Services.Queries;
public class GetSubscriptionServiceNumberOfActiveClientsQuery : IGetSubscriptionServiceNumberOfActiveClientsQuery
{

    private readonly AppDbContext _appDbContext;

    public GetSubscriptionServiceNumberOfActiveClientsQuery(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> GetSubscriptionServiceNumberOfActiveClientsAsync(int subscriptionServiceId)
    {
        return await _appDbContext.Subscriptions
            .Where(s => s.SubscriptionServiceId == subscriptionServiceId && s.EndDate > DateTime.Now)
            .CountAsync();
    }
}
