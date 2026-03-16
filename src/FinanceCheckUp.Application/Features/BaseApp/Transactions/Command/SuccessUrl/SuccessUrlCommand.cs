using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.SuccessUrl;

public class SuccessUrlCommand : IRequest<GenericResult<SuccessUrlResponse>>
{
    public SuccessUrlRequest Model { get; set; }
}