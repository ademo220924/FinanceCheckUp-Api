using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.SuccessUrl;

public class SuccessUrlCommandHandler : IRequestHandler<SuccessUrlCommand, GenericResult<SuccessUrlResponse>>
{
    public Task<GenericResult<SuccessUrlResponse>> Handle(SuccessUrlCommand request, CancellationToken cancellationToken)
    {
        var status = request.Model._status;
        var orderNo = request.Model.order_no;
        var invoiceİd = request.Model.invoice_id;
        var statusDescription = request.Model.status_description;
        var paymentMethod = request.Model._payment_method;

        var fullQuery = " invoice_id : " + invoiceİd + "_status :" + status + "order_no :" + orderNo + "status_description :" + statusDescription + "_payment_method :" + paymentMethod;

        return Task.FromResult(GenericResult<SuccessUrlResponse>.Success(new SuccessUrlResponse { Url = fullQuery }));
    }
}