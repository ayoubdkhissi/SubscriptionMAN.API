using SubscriptionMAN.API.Core.Common;

namespace SubscriptionMAN.API.Presentation.Utils.Responses;

public class RegisterResponse
{
    public bool Success => !Errors.Any();
    public string Message { get; set; }

    public ICollection<string> Errors { get; set; }

    public RegisterResponse()
    {
        Errors = new List<string>();
        Message = "";
    }
}
