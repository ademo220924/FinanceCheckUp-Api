namespace FinanceCheckUp.Application.Models.Requests.Transactions;

public class CheckBinCodeRequest
{
    public string BinCode { get; set; }
    public decimal Amount { get; set; }
    public bool IsRecurring { get; set; }
}