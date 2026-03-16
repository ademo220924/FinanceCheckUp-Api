namespace FinanceCheckUp.Client.QnbClient.Models.Request;

public class Settings
{
    public string AppID { get => _app_id; set => _app_id = value; }
    public string AppSecret { get => _app_secret; set => _app_secret = value; }
    public string MerchantKey { get => _merchant_key; set => _merchant_key = value; }
    public string BaseUrl { get => _base_url; set => _base_url = value; }

    private string _merchant_key { get; set; }
    private string _app_id { get; set; }
    private string _app_secret { get; set; }
    private string _base_url { get; set; }
}