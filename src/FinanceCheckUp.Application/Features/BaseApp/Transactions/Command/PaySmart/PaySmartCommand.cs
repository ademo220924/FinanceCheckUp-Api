using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.PaySmart;

public class PaySmartCommand : IRequest<GenericResult<PaySmartResponse>>
{
    public PaySmartRequest Model { get; set; }
}