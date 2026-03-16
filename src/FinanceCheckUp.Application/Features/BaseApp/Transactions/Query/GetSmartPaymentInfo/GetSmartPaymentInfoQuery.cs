using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Client.QnbClient.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.GetSmartPaymentInfo;

public class GetSmartPaymentInfoQuery : IRequest<GenericResult<PaymentModel>>
{
    public GetSmartPaymentInfoRequest Model { get; set; }
}