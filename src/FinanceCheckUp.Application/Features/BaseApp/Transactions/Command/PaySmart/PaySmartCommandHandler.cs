using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Application.Models.Qnb;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Client.QnbClient.Interfaces;
using FinanceCheckUp.Client.QnbClient.Models;
using FinanceCheckUp.Client.QnbClient.Models.Request;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.PaySmart;

public class PaySmartCommandHandle(
    IOptions<QNBpay> qnBpay,
    IQnbClient qnbClient,
    IAuthenticationHelperService authenticationHelperService)
    : IRequestHandler<PaySmartCommand, GenericResult<PaySmartResponse>>
{
    private readonly QNBpay _qnBpay = qnBpay.Value;
    private readonly IQnbClient _qnbClient = qnbClient ?? throw new ArgumentNullException(nameof(qnbClient));
    private readonly IAuthenticationHelperService authenticationHelperService = authenticationHelperService;

    public async Task<GenericResult<PaySmartResponse>> Handle(PaySmartCommand request, CancellationToken cancellationToken)
    {

        var paymentForm = TransactionPaymentHelper.GetSmartPaymentInfo(request.Model.PaymentModelRequest);
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

        switch (paymentForm.Is3D)
        {
            case QnbPaymentType.WhiteLabel2D:
                {
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
                        CurrencyId = "1",
                        HashKey = HashHelper.GenerateHashKey(paymentForm.Amount.ToString(), paymentForm.InstallmentNumber.ToString(), "TRY", settings.MerchantKey, paymentForm.OrderId, settings.AppSecret)
                    };

                    var baseUrl = authenticationHelperService.GetBaseUrl();
                    payRequest.ReturnUrl = baseUrl + "/Transaction/SuccessUrl";
                    payRequest.CancelUrl = baseUrl + "/Transaction/CancelUrl";
                    payRequest.Items.Add(product);

                    var createdToken = await _qnbClient.CreateToken(settings);
                    var payResponse = await _qnbClient.SmartPay(payRequest, settings, createdToken.token);
                    var result = JsonConvert.SerializeObject(payResponse);
                    return GenericResult<PaySmartResponse>.Success(new PaySmartResponse { Response=result});
                }
            case QnbPaymentType.WhiteLabel3D:
                {
                    //// 3D

                    var paymentRequest = new Smart3DPaymentRequest(settings)
                    {
                        CCNo = paymentForm.CreditCardNumber.Replace(" ", ""),
                        CCHolderName = paymentForm.CreditCardName,
                        CCV = paymentForm.CreditCardCvv2,
                        ExpiryYear = paymentForm.CreditCardExpireYear.ToString(),
                        ExpiryMonth = paymentForm.CreditCardExpireMonth.ToString(),
                        InvoiceDescription = "",
                        InvoiceId = paymentForm.OrderId,
                        PayableAmount = paymentForm.Amount,
                        Total = paymentForm.Amount,
                        InstallmentsNumber = paymentForm.InstallmentNumber,
                        CurrencyCode = "TRY",
                        CurrencyId = "1",
                        HashKey = HashHelper.GenerateHashKey(paymentForm.Amount.ToString(), paymentForm.InstallmentNumber.ToString(), "TRY", settings.MerchantKey, paymentForm.OrderId, settings.AppSecret)
                    };

                    var baseUrl = authenticationHelperService.GetBaseUrl();
                    paymentRequest.ReturnUrl = baseUrl + "/Transaction/SuccessUrl";
                    paymentRequest.CancelUrl = baseUrl + "/Transaction/CancelUrl";
                    paymentRequest.Items.Add(product);

                    var requestForm = paymentRequest.GenerateFormHtmlToRedirect(_qnBpay.BaseUrl + "/api/paySmart3D");
                    var serializedObject = JsonConvert.SerializeObject(requestForm);
                    return GenericResult<PaySmartResponse>.Success(new PaySmartResponse { Response = serializedObject });
                }
            default:
                return GenericResult<PaySmartResponse>.Success(new PaySmartResponse { Response = string.Empty });
        }
    }
}