using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Client.QnbClient.Interfaces;
using FinanceCheckUp.Client.QnbClient.Models.Request;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.Refund;

public class RefundCommandHandle(IOptions<QNBpay> qnBpay, IQnbClient qnbClient) : IRequestHandler<RefundCommand, GenericResult<RefundResponse>>
{
    private readonly QNBpay _qnBpay = qnBpay.Value;
    private readonly IQnbClient _qnbClient = qnbClient ?? throw new ArgumentNullException(nameof(qnbClient));

    public async Task<GenericResult<RefundResponse>> Handle(RefundCommand request, CancellationToken cancellationToken)
    {
        var paymentForm = TransactionPaymentHelper.GetSmartPaymentInfoNomb(request.Model.PaymentModelRequest);

        decimal amount = 0;
        var orderId = "";

        if (!string.IsNullOrEmpty(paymentForm.Amount.ToString(CultureInfo.InvariantCulture)))
            amount = paymentForm.Amount;

        if (!string.IsNullOrEmpty(paymentForm.OrderId))
            orderId = paymentForm.OrderId;

        var settings = new Settings
        {
            MerchantKey = _qnBpay.MerchantKey,
            BaseUrl = _qnBpay.BaseUrl,
            AppSecret = _qnBpay.AppSecret,
            AppID = _qnBpay.AppID
        };

        var refundRequest = new RefundRequest(settings)
        {
            InvoiceId = orderId,
            Amount = amount
        };

        var createdToken = await _qnbClient.CreateToken(settings);
        var payResponse = await _qnbClient.Refund(refundRequest, settings, createdToken.token);
        return GenericResult<RefundResponse>.Success(payResponse);
    }
}