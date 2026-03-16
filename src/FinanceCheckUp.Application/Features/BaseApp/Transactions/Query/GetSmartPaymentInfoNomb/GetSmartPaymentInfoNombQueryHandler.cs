using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Client.QnbClient.Models;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.GetSmartPaymentInfoNomb;

public class GetSmartPaymentInfoNombQueryHandler : IRequestHandler<GetSmartPaymentInfoNombQuery, GenericResult<GetSmartPaymentInfoNombResponse>>
{
    public Task<GenericResult<GetSmartPaymentInfoNombResponse>> Handle(GetSmartPaymentInfoNombQuery request, CancellationToken cancellationToken)
    {
        var paymentInfo = TransactionPaymentHelper.GetSmartPaymentInfoNomb(new PaymentModelRequest()
        {
            CreditCardType = request.Model.CreditCardType,
            CardholderName = request.Model.CardholderName,
            CardNumber = request.Model.CardNumber,
            ExpireMonth = request.Model.ExpireMonth,
            ExpireYear = request.Model.ExpireYear,
            Amount = request.Model.Amount,
            OrderId = request.Model.OrderId,
            CardCode = request.Model.CardCode,
            Is3D = request.Model.Is3D,
            Installment = request.Model.Installment
        });

        return Task.FromResult(GenericResult<GetSmartPaymentInfoNombResponse>.Success(new GetSmartPaymentInfoNombResponse()
        {
            PaymentModel = paymentInfo
        }));
    }
}