using FinanceCheckUp.Client.QnbClient.Models;

namespace FinanceCheckUp.Application.Models.Requests.Transactions;

public class PaySmartNombRequest
{
    public PaymentModelRequest PaymentModelRequest { get; set; }
}