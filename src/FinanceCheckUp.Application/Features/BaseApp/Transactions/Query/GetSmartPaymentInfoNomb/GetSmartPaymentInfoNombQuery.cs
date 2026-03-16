using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.GetSmartPaymentInfoNomb;

public class GetSmartPaymentInfoNombQuery : IRequest<GenericResult<GetSmartPaymentInfoNombResponse>>
{
    public GetSmartPaymentInfoNombRequest Model { get; set; }
}