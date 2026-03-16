using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.BrandedSuccessUrl;

public class BrandedSuccessUrlCommand : IRequest<GenericResult<BrandedSuccessUrlResponse>>
{
    public BrandedSuccessUrlRequest Model { get; set; }
}