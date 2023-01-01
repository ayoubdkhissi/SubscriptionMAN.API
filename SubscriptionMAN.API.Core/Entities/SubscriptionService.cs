using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Core.Entities;
public class SubscriptionService : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<Subscription> Subscriptions { get; set; }


    public string UserName { get; private set; }

    public SubscriptionService(string userName)
    {
        UserName = userName;
        Subscriptions = new List<Subscription>();
    }
}
