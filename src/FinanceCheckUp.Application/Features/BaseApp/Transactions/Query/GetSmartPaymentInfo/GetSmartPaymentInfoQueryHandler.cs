using FinanceCheckUp.Client.QnbClient.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.GetSmartPaymentInfo;

public class GetSmartPaymentInfoQueryHandler : IRequestHandler<GetSmartPaymentInfoQuery, GenericResult<PaymentModel>>
{
    public async Task<GenericResult<PaymentModel>> Handle(GetSmartPaymentInfoQuery request, CancellationToken cancellationToken)
    {
        var paymentInfo = new PaymentModel();

        if (!string.IsNullOrEmpty(request.Model.CreditCardType))
        {
            paymentInfo.CreditCardType = request.Model.CreditCardType;
        }
        if (!string.IsNullOrEmpty(request.Model.CardholderName))
        {
            paymentInfo.CreditCardName = request.Model.CardholderName;
        }


        if (!string.IsNullOrEmpty(request.Model.CardNumber))
        {
            paymentInfo.CreditCardNumber = request.Model.CardNumber;
        }
        if (!string.IsNullOrEmpty(request.Model.ExpireMonth))
        {
            paymentInfo.CreditCardExpireMonth = int.Parse(request.Model.ExpireMonth);
        }
        if (!string.IsNullOrEmpty(request.Model.ExpireYear))
        {
            paymentInfo.CreditCardExpireYear = int.Parse(request.Model.ExpireYear);
        }

        if (!string.IsNullOrEmpty(request.Model.Amount))
        {
            paymentInfo.Amount = decimal.Parse(request.Model.Amount);
        }

        if (!string.IsNullOrEmpty(request.Model.OrderId))
        {
            paymentInfo.OrderId = request.Model.OrderId;
        }

        if (!string.IsNullOrEmpty(request.Model.CardCode))
        {
            paymentInfo.CreditCardCvv2 = request.Model.CardCode;
        }


        QnbPaymentType paymentType = QnbPaymentType.WhiteLabel2D;
        if (!string.IsNullOrEmpty(request.Model.Is3D))
        {
            if (request.Model.Is3D == "on")
                paymentType = QnbPaymentType.WhiteLabel3D;
        }
        paymentInfo.Is3D = paymentType;

        if (request.Model.SelectedPosData != null)
        {
            var posData = request.Model.SelectedPosData;

            paymentInfo.SelectedPosData = request.Model.SelectedPosData;
        }

        paymentInfo.InstallmentNumber = 1;
        if (!string.IsNullOrEmpty(request.Model.Installment))
        {
            paymentInfo.InstallmentNumber = int.Parse(request.Model.Installment.ToString().Replace("\"", ""));
        }

        return GenericResult<PaymentModel>.Success(paymentInfo);
    }
}