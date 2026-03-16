using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.CheckBinCode;

public class CheckBinCodeQuery : IRequest<GenericResult<CheckBinCodeResponse>>
{
    public CheckBinCodeRequest Model { get; set; }
}