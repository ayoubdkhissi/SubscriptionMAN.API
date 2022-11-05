using SubscriptionMAN.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Core.Interfaces.Repository;
public interface ISubscriptionServiceRepository
{

    IEnumerable<SubscriptionService> GetSubscriptionServices();
    Task<SubscriptionService> GetSubscriptionService(int id);
    void InsertSubscriptionService(SubscriptionService subscriptionService);
    void UpdateSubscriptionService(SubscriptionService subscriptionService);
    void save();

}
