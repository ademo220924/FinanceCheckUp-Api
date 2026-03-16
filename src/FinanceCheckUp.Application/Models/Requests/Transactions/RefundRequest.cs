using FinanceCheckUp.Client.QnbClient.Models;

namespace FinanceCheckUp.Application.Models.Requests.Transactions;

public class RefundRequest
{
    public PaymentModelRequest PaymentModelRequest { get; set; }
}