using FinanceCheckUp.Client.QnbClient.Models;

namespace FinanceCheckUp.Application.Models.Requests.Transactions;

public class PaySmartRequest
{
    public PaymentModelRequest PaymentModelRequest { get; set; }
}