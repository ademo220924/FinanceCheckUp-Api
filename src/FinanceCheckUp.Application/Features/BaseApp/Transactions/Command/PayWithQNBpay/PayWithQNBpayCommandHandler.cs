using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Client.QnbClient.Interfaces;
using FinanceCheckUp.Client.QnbClient.Models.Request;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System.Globalization;
using FinanceCheckUp.Application.Services.Interfaces;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.PayWithQNBpay;

public class PayWithQnBpayCommandHandle(IOptions<QNBpay> qnBpay, IQnbClient qnbClient,IAuthenticationHelperService authenticationHelperService) 
    : IRequestHandler<PayWithQNBpayCommand, GenericResult<PayWithQNBpayResponse>>
{
    private readonly QNBpay _qnBpay = qnBpay.Value;
    private readonly IQnbClient _qnbClient = qnbClient ?? throw new ArgumentNullException(nameof(qnbClient));

    public async Task<GenericResult<PayWithQNBpayResponse>> Handle(PayWithQNBpayCommand request, CancellationToken cancellationToken)
    {
        var paymentForm = TransactionPaymentHelper.GetSmartPaymentInfoNomb(request.Model.PaymentModelRequest);

        decimal amount = 0;
        var orderId = "";

        if (!string.IsNullOrEmpty(paymentForm.Amount.ToString(CultureInfo.InvariantCulture)))
            amount = paymentForm.Amount;

        if (!string.IsNullOrEmpty(paymentForm.OrderId))
            orderId = paymentForm.OrderId;

        var recurring = TransactionPaymentHelper.GetRecurringPaymentInfo(request.Model.PaymentModelRequest);

        var settings = new Settings
        {
            MerchantKey = _qnBpay.MerchantKey,
            BaseUrl = _qnBpay.BaseUrl
        };

        var brandedRequest = new BrandedPaymentRequest(settings)
        {
            CurrencyCode = "TRY",
            Name = "Test",
            SurName = "test"
        };

        var invoice = new Invoice
        {
            InvoiceId = orderId,
            Total = amount,
            InvoiceDescription = "test description",
            BillingAddress1 = "address1",
            BillingAddress2 = "address2",
            BillingCity = "Istanbul",
            BillingCountry = "TURKEY",
            BillingEmail = "demo@.com.tr",
            BillingPhone = "008801777711111",
            BillingPostcode = "1111",
            BillingState = "asdasd"
        };

        var baseUrl = authenticationHelperService.GetBaseUrl();
        invoice.ReturnUrl = baseUrl + "/Transaction/SuccessUrl";
        invoice.CancelUrl = baseUrl + "/Transaction/CancelUrl";

        var product = new Item
        {
            Description = "",
            Name = "Test Product",
            Quantity = 1,
            Price = amount
        };

        invoice.Items.Add(product);

        if (recurring.Item1)
        {
            invoice.IsRecurringPayment = true;
            invoice.RecurringPaymentNumber = recurring.Item2;
            invoice.RecurringPaymentCycle = recurring.Item3;
            invoice.RecurringPaymentInterval = recurring.Item4;
            invoice.RecurringWebhookKey = "yakala.co";
        }

        brandedRequest.Invoice = invoice;

        var payResponse = await _qnbClient.BrandedPay(brandedRequest, settings);

        return payResponse.StatusCode == 100
            ? GenericResult<PayWithQNBpayResponse>.Success(new PayWithQNBpayResponse { Response = new BrandedPaymentResponse { link = payResponse.link } })
            : GenericResult<PayWithQNBpayResponse>.Fail($"Bir hata oluştu - Status Code : {payResponse.StatusCode.ToString()}");
    }
}