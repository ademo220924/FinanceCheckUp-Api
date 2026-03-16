using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Client.QnbClient.Interfaces;
using FinanceCheckUp.Client.QnbClient.Models.Request;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.CheckBinCode;

public class CheckBinCodeQueryHandle(IOptions<QNBpay> qnBpay, IQnbClient qnbClient) : IRequestHandler<CheckBinCodeQuery, GenericResult<CheckBinCodeResponse>>
{
    private readonly QNBpay _qnBpay = qnBpay.Value;
    private readonly IQnbClient _qnbClient = qnbClient ?? throw new ArgumentNullException(nameof(qnbClient));


    public async Task<GenericResult<CheckBinCodeResponse>> Handle(CheckBinCodeQuery request, CancellationToken cancellationToken)
    {
        var checkBinCodeResponse = new CheckBinCodeResponse();

        if (request.Model.BinCode.Length < 6)
            return GenericResult<CheckBinCodeResponse>.Success(checkBinCodeResponse);

        var settings = new Settings
        {
            MerchantKey = _qnBpay.MerchantKey,
            BaseUrl = _qnBpay.BaseUrl,
            AppSecret = _qnBpay.AppSecret,
            AppID = _qnBpay.AppID
        };

        var posRequest = new GetPosRequest
        {
            CreditCardNo = request.Model.BinCode,
            Amount = request.Model.Amount,
            CurrencyCode = "TRY",
            //posRequest.CurrencyCode = "EUR";
            IsRecurring = request.Model.IsRecurring
        };

        var createdToken = await _qnbClient.CreateToken(settings);
        var posResponse = await _qnbClient.GetPos(posRequest, settings, createdToken.token);

        //GEÇİCİ

        for (var i = 0; i < posResponse.Data.Count; i++)
        {
            posResponse.Data[i].amount_to_be_paid += i * 0.1M;
        }

        checkBinCodeResponse.PosResponse = posResponse;
        checkBinCodeResponse.is_3d = createdToken.is_3d;
        return GenericResult<CheckBinCodeResponse>.Success(checkBinCodeResponse);
    }
}