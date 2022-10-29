using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Core.Entities;
public class Subscription : BaseEntity
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public double Amount { get; set; }

    public int SubscriptionServiceId { get; set; }
    public SubscriptionService SubscriptionService { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }
}
