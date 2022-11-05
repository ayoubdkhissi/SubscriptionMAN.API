using Microsoft.EntityFrameworkCore;
using SubscriptionMAN.API.Core.Entities;
using SubscriptionMAN.API.Core.Interfaces.Repository;
using SubscriptionMAN.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public async Task<SubscriptionService> GetSubscriptionService(int id)
    {
        return await _appDbContext.SubscriptionServices.FirstOrDefaultAsync(ss => ss.Id == id);
    }

    public IEnumerable<SubscriptionService> GetSubscriptionServices()
    {
        return _appDbContext.SubscriptionServices;
    }

    public void InsertSubscriptionService(SubscriptionService subscriptionService)
    {
        _appDbContext.SubscriptionServices.Add(subscriptionService);
    }


    public void UpdateSubscriptionService(SubscriptionService subscriptionService)
    {
        _appDbContext.Entry(subscriptionService).State = EntityState.Modified;
    }

    public void save()
    {
        _appDbContext.SaveChangesAsync();
    }



}
