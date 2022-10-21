using System.ComponentModel.DataAnnotations;

namespace SubscriptionMAN.API.Presentation.Utils.Requests;

public class RefreshTokenRequest
{
    public string RefreshToken { get; set; } = string.Empty;
}
