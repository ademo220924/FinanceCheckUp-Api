namespace FinanceCheckUp.Client.QnbClient.Models.Response;

public class RefundResponse : ClientResponseModel
{
    public string order_no { get; set; }
    public string invoice_id { get; set; }
    public string ref_no { get; set; }
}