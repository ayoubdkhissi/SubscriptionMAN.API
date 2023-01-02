using Microsoft.EntityFrameworkCore;
using SubscriptionMAN.API.Core.Constants;
using SubscriptionMAN.API.Core.Entities;
using SubscriptionMAN.API.Core.Interfaces.Repository;
using SubscriptionMAN.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Services.Repository;
public class SubscriptionServiceRepository : ISubscriptionServiceRepository
{
    private readonly AppDbContext _appDbContext;

    public SubscriptionServiceRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

    }

    public Task<bool> DeleteSubscriptionServiceAsync(SubscriptionService subscriptionService)
    {
        throw new NotImplementedException();
    }

    public Task<SubscriptionService> GetSubscriptionServiceAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SubscriptionService>> 
        GetSubscriptionServicesAsync(int pageNumber = PaginationConstants.DefaultPageNumber,
        int PageSize = PaginationConstants.DefaultPageSize)
    {
        return await _appDbContext.SubscriptionServices
            .Skip((pageNumber - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
    }

    public async Task<bool> InsertSubscriptionServiceAsync(SubscriptionService subscriptionService)
    {
        try
        {

            await _appDbContext.SubscriptionServices.AddAsync(subscriptionService);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Task<bool> UpdateSubscriptionServiceAsync(SubscriptionService subscriptionService)
    {
        throw new NotImplementedException();
    }
}
