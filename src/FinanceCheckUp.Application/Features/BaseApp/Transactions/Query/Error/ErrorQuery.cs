using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.Error;

public class ErrorQuery : IRequest<GenericResult<ErrorViewModel>>
{
    public ErrorRequest Model { get; set; }
}