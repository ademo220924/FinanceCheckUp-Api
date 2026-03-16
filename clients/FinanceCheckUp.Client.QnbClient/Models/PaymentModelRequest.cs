using FinanceCheckUp.Client.QnbClient.Models.Request;

namespace FinanceCheckUp.Client.QnbClient.Models;

public class PaymentModelRequest
{
    public string? is_recurring_payment { get; set; }
    public string? recurring_payment_number { get; set; }
    public string? recurring_payment_cycle { get; set; }
    public string? recurring_payment_interval { get; set; }
    public string CreditCardType { get; set; }
    public string CardholderName { get; set; }
    public string? CardNumber { get; set; }
    public string? ExpireMonth { get; set; }
    public string? ExpireYear { get; set; }
    public string? Amount { get; set; }
    public string? OrderId { get; set; }
    public string CardCode { get; set; }
    public string? Is3D { get; set; }
    public string? Installment { get; set; }
    public PosData SelectedPosData { get; set; }
}