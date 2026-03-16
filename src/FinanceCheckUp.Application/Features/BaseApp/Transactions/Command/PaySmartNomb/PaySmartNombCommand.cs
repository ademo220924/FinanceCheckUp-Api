using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.PaySmartNomb;

public class PaySmartNombCommand : IRequest<GenericResult<SmartPaymentResponse>>
{
    public PaySmartNombRequest Model { get; set; }
}