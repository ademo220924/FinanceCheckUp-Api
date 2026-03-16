using FinanceCheckUp.Client.QnbClient.Models;

namespace FinanceCheckUp.Application.Common.Utilities;

public static class TransactionPaymentHelper
{
    public static PaymentModel GetSmartPaymentInfoNomb(PaymentModelRequest request)
    {
        var paymentInfo = new PaymentModel
        {
            CreditCardType = request.CreditCardType,
            CreditCardName = request.CardholderName
        };

        if (!string.IsNullOrEmpty(request.CardNumber))
            paymentInfo.CreditCardNumber = request.CardNumber;

        if (!string.IsNullOrEmpty(request.ExpireMonth))
            paymentInfo.CreditCardExpireMonth = int.Parse(request.ExpireMonth);

        if (!string.IsNullOrEmpty(request.ExpireYear))
            paymentInfo.CreditCardExpireYear = int.Parse(request.ExpireYear);

        if (!string.IsNullOrEmpty(request.Amount))
            paymentInfo.Amount = decimal.Parse(request.Amount);

        if (!string.IsNullOrEmpty(request.Amount))
            paymentInfo.Amount = decimal.Parse(request.Amount);

        if (!string.IsNullOrEmpty(request.OrderId))
            paymentInfo.OrderId = request.OrderId;

        paymentInfo.CreditCardCvv2 = request.CardCode[..3];
        var paymentType = QnbPaymentType.WhiteLabel2D;
        if (!string.IsNullOrEmpty(request.Is3D))
            if (request.Is3D == "on") paymentType = QnbPaymentType.WhiteLabel3D;


        paymentInfo.Is3D = paymentType;
        paymentInfo.InstallmentNumber = 1;
        if (!string.IsNullOrEmpty(request.Installment))
            paymentInfo.InstallmentNumber = int.Parse(request.Installment.Replace("\"", ""));

        return paymentInfo;
    }

    public static (bool, int, string, int) GetRecurringPaymentInfo(PaymentModelRequest request)
    {
        var is_recurring_payment = false;
        var recurring_payment_number = 0;
        var recurring_payment_cycle = "";
        var recurring_payment_interval = 0;

        if (!string.IsNullOrEmpty(request.is_recurring_payment))
            is_recurring_payment = request.is_recurring_payment == "on";

        if (!string.IsNullOrEmpty(request.recurring_payment_number))
            Int32.TryParse(request.recurring_payment_number, out recurring_payment_number);

        if (!string.IsNullOrEmpty(request.recurring_payment_cycle))
            recurring_payment_cycle = request.recurring_payment_cycle;

        if (!string.IsNullOrEmpty(request.recurring_payment_interval))
            Int32.TryParse(request.recurring_payment_interval, out recurring_payment_interval);

        return (is_recurring_payment, recurring_payment_number, recurring_payment_cycle, recurring_payment_interval);
    }

    public static PaymentModel GetSmartPaymentInfo(PaymentModelRequest request)
    {
        return GetSmartPaymentInfoNomb(request);
    }
}