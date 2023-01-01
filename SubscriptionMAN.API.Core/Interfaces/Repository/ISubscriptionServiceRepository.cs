using SubscriptionMAN.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Core.Interfaces.Repository;
public interface ISubscriptionServiceRepository
{

    Task<IEnumerable<SubscriptionService>> GetSubscriptionServicesAsync();
    Task<SubscriptionService> GetSubscriptionServiceAsync(int id);
    Task<bool> InsertSubscriptionServiceAsync(SubscriptionService subscriptionService);
    Task<bool> UpdateSubscriptionServiceAsync(SubscriptionService subscriptionService);
    Task<bool> DeleteSubscriptionServiceAsync(SubscriptionService subscriptionService);

}
