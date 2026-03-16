using FinanceCheckUp.Client.QnbClient.Models.Request;

namespace FinanceCheckUp.Client.QnbClient.Models;

public class PaymentModel
{
    public int CustomerId { get; set; }

    public string OrderId { get; set; }

    public decimal OrderTotal { get; set; }

    public string PaymentMethodSystemName { get; set; }

    public string CreditCardType { get; set; }

    public string CreditCardName { get; set; }

    public string CreditCardNumber { get; set; }

    public int CreditCardExpireYear { get; set; }

    public int CreditCardExpireMonth { get; set; }

    public string CreditCardCvv2 { get; set; }

    public string PurchaseOrderNumber { get; set; }

    public int InstallmentNumber { get; set; }

    public PosData SelectedPosData { get; set; }
    public QnbPaymentType Is3D { get; set; }
    public decimal Amount { get; set; }
}