namespace FinanceCheckUp.Client.QnbClient.Models.Request;

public class CancelRequest
{
    public string? _status { get; set; }
    public string? order_no { get; set; }
    public string? invoice_id { get; set; }
    public string? status_description { get; set; }
    public string? _payment_method { get; set; }
    public string? error { get; set; }
    public string? error_code { get; set; }
}