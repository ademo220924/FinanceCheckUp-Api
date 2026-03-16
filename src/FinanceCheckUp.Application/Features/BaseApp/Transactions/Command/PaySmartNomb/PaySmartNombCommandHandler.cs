using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Client.QnbClient.Interfaces;
using FinanceCheckUp.Client.QnbClient.Models;
using FinanceCheckUp.Client.QnbClient.Models.Request;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System.Globalization;
using FinanceCheckUp.Application.Services.Interfaces;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.PaySmartNomb;

public class PaySmartNombCommandHandle(IOptions<QNBpay> qnBpay, IQnbClient qnbClient,IAuthenticationHelperService authenticationHelperService) : IRequestHandler<PaySmartNombCommand, GenericResult<SmartPaymentResponse>>
{
    private readonly QNBpay _qnBpay = qnBpay.Value;
    private readonly IQnbClient _qnbClient = qnbClient ?? throw new ArgumentNullException(nameof(qnbClient));

    public async Task<GenericResult<SmartPaymentResponse>> Handle(PaySmartNombCommand request, CancellationToken cancellationToken)
    {
        var paymentForm = TransactionPaymentHelper.GetSmartPaymentInfoNomb(request.Model.PaymentModelRequest);
        //var recurring = TransactionPaymentHelper.GetRecurringPaymentInfo(request.Model.PaymentModelRequest);

        var settings = new Settings
        {
            AppID = _qnBpay.AppID,
            AppSecret = _qnBpay.AppSecret,
            MerchantKey = _qnBpay.MerchantKey,
            BaseUrl = _qnBpay.BaseUrl
        };

        var product = new Item
        {
            Description = "",
            Name = "Test Product",
            Quantity = 1,
            Price = paymentForm.Amount
        };

        if (paymentForm.Is3D != QnbPaymentType.WhiteLabel2D)
            return GenericResult<SmartPaymentResponse>.Success(new SmartPaymentResponse());
        //// 2D 

        var payRequest = new SmartPaymentRequest(settings, paymentForm.SelectedPosData)
        {
            CCNo = paymentForm.CreditCardNumber.Replace(" ", ""),
            CCHolderName = paymentForm.CreditCardName,
            CCV = paymentForm.CreditCardCvv2,
            ExpiryYear = paymentForm.CreditCardExpireYear.ToString(),
            ExpiryMonth = paymentForm.CreditCardExpireMonth.ToString(),
            InvoiceDescription = "",
            InvoiceId = paymentForm.OrderId,
            Total = paymentForm.Amount,
            InstallmentsNumber = paymentForm.InstallmentNumber,
            CurrencyCode = "TRY",
            CurrencyId = "1"
        };

        var baseUrl =authenticationHelperService.GetBaseUrl();
        payRequest.ReturnUrl = baseUrl + "/Transaction/SuccessUrl";
        payRequest.CancelUrl = baseUrl + "/Transaction/CancelUrl";

        payRequest.Items.Add(product);

        //if (recurring.Item1)
        //{
        //    payRequest.IsRecurringPayment = true;
        //    payRequest.RecurringPaymentNumber = recurring.Item2;
        //    payRequest.RecurringPaymentCycle = recurring.Item3;
        //    payRequest.RecurringPaymentInterval = recurring.Item4;
        //    payRequest.RecurringWebhookKey = "yakala.co";
        //}

        payRequest.HashKey = HashHelper.GenerateHashKey(
            paymentForm.Amount.ToString(CultureInfo.InvariantCulture),
            paymentForm.InstallmentNumber.ToString(),
            "TRY",
            settings.MerchantKey,
            paymentForm.OrderId,
            settings.AppSecret);

        var createdToken = await _qnbClient.CreateToken(settings);
        var payResponse = await _qnbClient.SmartPay(payRequest, settings, createdToken.token);
        return GenericResult<SmartPaymentResponse>.Success(payResponse);

    }


}