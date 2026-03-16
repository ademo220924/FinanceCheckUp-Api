using FinanceCheckUp.Client.QnbClient.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.GetPaymentInfo;

public class GetPaymentInfoQueryHandler : IRequestHandler<GetPaymentInfoQuery, GenericResult<PaymentModel>>
{
    public async Task<GenericResult<PaymentModel>> Handle(GetPaymentInfoQuery request, CancellationToken cancellationToken)
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


        if (request.Model.SelectedPosData != null)
        {
            var posData = request.Model.SelectedPosData;

            paymentInfo.SelectedPosData = request.Model.SelectedPosData;
        }


        if (!string.IsNullOrEmpty(request.Model.Is3D))
        {
            paymentInfo.Is3D = (QnbPaymentType)(Int32.TryParse(request.Model.Is3D, out int is3D) ? is3D : 0);
        }

        return GenericResult<PaymentModel>.Success(paymentInfo);
    }
}