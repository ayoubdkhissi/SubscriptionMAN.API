namespace SubscriptionMAN.API.Presentation.Utils.Responses;

public class SubscriptionServiceForListingDTO
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int TotalNumberOfClients { get; set; }

    public int NumberOfActiveClients { get; set; }
}
