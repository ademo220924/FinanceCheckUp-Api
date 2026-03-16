namespace FinanceCheckUp.Client.ConnectApi.Models.Response;

public class ReturnMainEledger
{
    public bool success { get; set; }
    public string message { get; set; }
    public object payload { get; set; }
    public object transactionId { get; set; }
}