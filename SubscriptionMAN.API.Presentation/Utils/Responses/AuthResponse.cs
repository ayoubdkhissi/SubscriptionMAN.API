namespace SubscriptionMAN.API.Presentation.Utils.Responses;

public class AuthResponse
{
    public bool IsSuccess { get; set; } = false;
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;


    public AuthResponse()
    {
    }


    

}
