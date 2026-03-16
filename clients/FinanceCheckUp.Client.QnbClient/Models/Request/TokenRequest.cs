namespace FinanceCheckUp.Client.QnbClient.Models.Request;

public class TokenRequest
{
    public string AppID { private get; set; }
    public string AppSecret { private get; set; }
    internal string MerchantKey { private get; set; }

    public string app_id => this.AppID;
    public string app_secret { get { return this.AppSecret; } }
}