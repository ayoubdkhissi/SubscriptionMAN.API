using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Core.Entities;
public class Client : BaseEntity
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public ICollection<Subscription> Subscriptions { get; set; }

    public Client()
    {
        Subscriptions = new List<Subscription>();
    }
}
