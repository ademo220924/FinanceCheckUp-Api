using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.BrandedCancelUrl;

public class BrandedCancelUrlCommandHandler : IRequestHandler<BrandedCancelUrlCommand, GenericResult<BrandedCancelUrlResponse>>
{
    public Task<GenericResult<BrandedCancelUrlResponse>> Handle(BrandedCancelUrlCommand request, CancellationToken cancellationToken)
    {
        var status = request.Model.status;
        var message = request.Model.success_message;
        var link = request.Model.link;
        var fullQuery = $"status :{status} message :{message} link :{link}";

        return Task.FromResult(GenericResult<BrandedCancelUrlResponse>.Success(new BrandedCancelUrlResponse { Url = fullQuery }));
    }
}