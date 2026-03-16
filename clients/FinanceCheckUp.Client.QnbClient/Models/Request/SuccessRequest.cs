namespace FinanceCheckUp.Client.QnbClient.Models.Request;

public class SuccessRequest
{
    public string? _status { get; set; }
    public string? order_no { get; set; }
    public string? invoice_id { get; set; }
    public string? status_description { get; set; }
    public string? _payment_method { get; set; }
}