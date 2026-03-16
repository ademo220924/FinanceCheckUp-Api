using FinanceCheckUp.Client.QnbClient.Models;

namespace FinanceCheckUp.Application.Models.Requests.Transactions;

public class PayWithQNBpayRequest
{
    public PaymentModelRequest PaymentModelRequest { get; set; }
}