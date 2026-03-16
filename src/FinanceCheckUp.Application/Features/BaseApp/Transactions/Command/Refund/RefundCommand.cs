using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.Refund;

public class RefundCommand : IRequest<GenericResult<RefundResponse>>
{
    public RefundRequest Model { get; set; }
}