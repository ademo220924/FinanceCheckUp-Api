namespace FinanceCheckUp.Client.QnbClient.Models.Request;

public class GetOrderStatusRequest
{
    public Settings _settings { get; set; }

    public string InvoiceId { private get; set; }

    public string invoice_id { get { return this.InvoiceId; } }

    public GetOrderStatusRequest(Settings settings)
    {
        this._settings = settings;
    }

}