using FinanceCheckUp.Client.QnbClient.Models.Request;
using FinanceCheckUp.Client.QnbClient.Models.Response;

namespace FinanceCheckUp.Client.QnbClient.Interfaces;

public interface IQnbClient
{
    Task<TokenResponse> CreateToken(Settings settings);
    Task<GetPosResponse> GetPos(GetPosRequest request, Settings settings, string token);
    Task<PaymentResponse> Pay(PaymentRequest request, Settings settings, string token);
    Task<SmartPaymentResponse> SmartPay(SmartPaymentRequest request, Settings settings, string token);
    Task<BrandedPaymentResponse> BrandedPay(BrandedPaymentRequest request, Settings settings);
    Task<GetOrderStatusResponse> GetOrderStatus(GetOrderStatusRequest request, Settings settings);
    Task<RefundResponse> Refund(RefundRequest request, Settings settings, string token);
}