using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Client.QnbClient.Interfaces;
using FinanceCheckUp.Client.QnbClient.Models.Request;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.BrandedSuccessUrl;

public class BrandedSuccessUrlCommandHandle(IOptions<QNBpay> qnBpay, IQnbClient qnbClient) : IRequestHandler<BrandedSuccessUrlCommand, GenericResult<BrandedSuccessUrlResponse>>
{
    private readonly QNBpay _qnBpay = qnBpay.Value;
    private readonly IQnbClient _qnbClient = qnbClient ?? throw new ArgumentNullException(nameof(qnbClient));


    public async Task<GenericResult<BrandedSuccessUrlResponse>> Handle(BrandedSuccessUrlCommand request, CancellationToken cancellationToken)
    {
        var invoiceId = request.Model.invoice_id;

        var settings = new Settings
        {
            MerchantKey = _qnBpay.MerchantKey,
            BaseUrl = _qnBpay.BaseUrl
        };


        var orderStatusRequest = new GetOrderStatusRequest(settings)
        {
            InvoiceId = invoiceId
        };

        var payResponse = await _qnbClient.GetOrderStatus(orderStatusRequest, settings);

        var fullQuery = $"transaction status :{payResponse.transaction_status} message :{payResponse.Message} recurring_id :{payResponse.recurring_id} recurring_status :{payResponse.recurring_id}";

        return GenericResult<BrandedSuccessUrlResponse>.Success(new BrandedSuccessUrlResponse { Url = fullQuery });
    }
}