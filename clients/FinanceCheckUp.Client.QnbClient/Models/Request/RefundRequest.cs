namespace FinanceCheckUp.Client.QnbClient.Models.Request;

public class RefundRequest
{
    public string AppID { private get; set; }
    public string AppSecret { private get; set; }
    public string MerchantKey { private get; set; }

    public decimal Amount { private get; set; }
    public string InvoiceId { private get; set; }

    public string app_id => this.AppID;
    public string app_secret => this.AppSecret;
    public string merchant_key => this.MerchantKey;
    public string amount => Amount.ToString("0.00").Replace(",", ".");
    public string invoice_id => this.InvoiceId;

    public RefundRequest(Settings settings)
    {

        this.AppID = settings.AppID;
        this.AppSecret = settings.AppSecret;
        this.MerchantKey = settings.MerchantKey;

    }
}