using Microsoft.AspNetCore.Mvc;
using SubscriptionMAN.API.Core.Entities;
using SubscriptionMAN.API.Core.Interfaces.Repository;

namespace SubscriptionMAN.API.Presentation.Controllers;
public class SubscriptionServiceController : Controller
{
    private ISubscriptionServiceRepository _subscriptionServiceRepository;

    public SubscriptionServiceController(ISubscriptionServiceRepository subscriptionServiceRepository)
    {
        _subscriptionServiceRepository = subscriptionServiceRepository;
    }


    [HttpGet("api/subscriptionServices")]
    public ActionResult<IEnumerable<SubscriptionService>> GetSubscriptionServices()
    {
        var subscription_services = _subscriptionServiceRepository.GetSubscriptionServices();

        var result = subscription_services.ToList();
        return  Ok(result);
    }
}
