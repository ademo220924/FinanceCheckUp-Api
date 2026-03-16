using FinanceCheckUp.Application.Models.Requests.Transactions;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.BrandedCancelUrl;

public class BrandedCancelUrlCommand : IRequest<GenericResult<BrandedCancelUrlResponse>>
{
    public BrandedCancelUrlRequest Model { get; set; }
}