namespace FinanceCheckUp.Client.QnbClient.Models.Response;

public class TokenResponse : ClientResponseModel
{
    public string token { get; set; }
    public string is_3d { get; set; }
}
