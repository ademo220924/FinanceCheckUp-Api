using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Client.QnbClient.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.GetPaymentInfo;

public class GetPaymentInfoQuery : IRequest<GenericResult<PaymentModel>>
{
    public GetPaymentInfoRequest Model { get; set; }
}