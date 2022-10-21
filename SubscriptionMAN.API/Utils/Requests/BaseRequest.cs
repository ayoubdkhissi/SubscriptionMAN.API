namespace SubscriptionMAN.API.Presentation.Utils.Requests;

public abstract class BaseRequest
{
    protected Guid _correlationId = Guid.NewGuid();
    public Guid CorrelationId() => _correlationId;


}
