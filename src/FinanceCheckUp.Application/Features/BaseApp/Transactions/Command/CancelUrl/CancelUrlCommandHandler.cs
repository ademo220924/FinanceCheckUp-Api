using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.CancelUrl;

public class CancelUrlCommandHandler : IRequestHandler<CancelUrlCommand, GenericResult<CancelUrlResponse>>
{
    public Task<GenericResult<CancelUrlResponse>> Handle(CancelUrlCommand request, CancellationToken cancellationToken)
    {
        var status = request.Model._status;
        var orderNo = request.Model.order_no;
        var invoiceİd = request.Model.invoice_id;
        var statusDescription = request.Model.status_description;
        var paymentMethod = request.Model._payment_method;
        var error = request.Model.error;
        var errorCode = request.Model.error_code;


        string fullQuery = "error_code : " + errorCode + " invoice_id : " + invoiceİd + " error : " + error
                           + "_status :" + status + "order_no :" + orderNo + "status_description :" + statusDescription
                           + "_payment_method :" + paymentMethod;

        return Task.FromResult(GenericResult<CancelUrlResponse>.Success(new CancelUrlResponse { Url = fullQuery }));
    }
}