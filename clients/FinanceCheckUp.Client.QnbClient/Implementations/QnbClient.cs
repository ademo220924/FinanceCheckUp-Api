using FinanceCheckUp.Client.QnbClient.Interfaces;
using FinanceCheckUp.Client.QnbClient.Models.Request;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Exceptions;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace FinanceCheckUp.Client.QnbClient.Implementations;

public class QnbClient(HttpClient httpClient, ILogger<QnbClient> logger) : IQnbClient
{
    private const string TokenUrl = "/api/token";
    private const string GetPosUrl = "/api/getpos";
    private const string GetPayUrl = "/api/pay";
    private const string GetSmartPayUrl = "/api/paySmart2D";
    private const string GetBrandedPayUrl = "/purchase/link";
    private const string GetOrderStatusUrl = "/purchase/status";
    private const string GetRefundUrl = "/api/refund";


    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    private readonly ILogger<QnbClient> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    private void DefaultHeaderInitial(Dictionary<string, string>? headers = null)
    {
        _httpClient.DefaultRequestHeaders.Clear();

        if (headers == null)
            return;

        foreach (var header in headers)
        {
            _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }

    private static StringContent CreatePayload<TModel>(TModel model)
    {
        var payload = new StringContent(JsonSerializer.Serialize(model, options: new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }), Encoding.UTF8, MediaTypeNames.Application.Json);

        return payload;
    }

    private static FormUrlEncodedContent? CreatePayloadForUrlEncodedData(Dictionary<string, string>? formDataDictionary = null)
    {
        return formDataDictionary != null ? new FormUrlEncodedContent(formDataDictionary) : default;
    }

    public async Task<TokenResponse> CreateToken(Settings settings)
    {
        //ToDo: Burada direkt create token var ancak ilk önce get yapılmalı yoksa set yapılmalı
        // AUth işlemi yapoılmalı 2 parametre var header da tasınması gereken
        // tokenRequest.AppID = settings.
        // AppID;AppSecret = settings.AppSecret;
        //bu parametreler de appsettings de var
        // ek bir çözüm bakılıcak

        DefaultHeaderInitial();
        var tokenRequest = new TokenRequest
        {
            AppID = settings.AppID,
            AppSecret = settings.AppSecret
        };

        var resultModel = new TokenResponse();

        try
        {
            var response = await _httpClient.PostAsync(TokenUrl, CreatePayload(tokenRequest), CancellationToken.None);
            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();
            resultModel = JsonSerializer.Deserialize<TokenResponse>(contentResponse);

            resultModel ??= new TokenResponse();
            resultModel.StatusCode = (int)response.StatusCode;
            resultModel.IsSuccess = true;

            _logger.LogInformation("{MethodName} Response: {Payload}", nameof(CreateToken), contentResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "QnbClient client error (CreateToken) : {ExMessage}", ex.Message);
            resultModel ??= new TokenResponse();
            resultModel.Message = ex.Message;

            throw new ClientSideException(clientName: _httpClient.BaseAddress.ToString(), processName: TokenUrl);
        }

        return resultModel;
    }

    public async Task<GetPosResponse> GetPos(GetPosRequest request, Settings settings, string token)
    {
        request.MerchantKey = settings.MerchantKey;
        var header = new Dictionary<string, string> { { "Authorization", "Bearer " + token } };
        DefaultHeaderInitial(header);

        var resultModel = new GetPosResponse();

        try
        {
            var response = await _httpClient.PostAsync(GetPosUrl, CreatePayload(request), CancellationToken.None);
            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();
            resultModel = JsonSerializer.Deserialize<GetPosResponse>(contentResponse);

            resultModel ??= new GetPosResponse();
            resultModel.StatusCode = (int)response.StatusCode;
            resultModel.IsSuccess = true;

            _logger.LogInformation("{MethodName} Response: {Payload}", nameof(GetPos), contentResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "QnbClient client error (GetPos) : {ExMessage}", ex.Message);
            resultModel ??= new GetPosResponse();
            resultModel.Message = ex.Message;
        }

        return resultModel;
    }

    public async Task<PaymentResponse> Pay(PaymentRequest request, Settings settings, string token)
    {
        var header = new Dictionary<string, string> { { "Authorization", "Bearer " + token } };
        DefaultHeaderInitial(header);

        var resultModel = new PaymentResponse();

        try
        {
            var response = await _httpClient.PostAsync(GetPayUrl, CreatePayload(request), CancellationToken.None);
            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();
            resultModel = JsonSerializer.Deserialize<PaymentResponse>(contentResponse);

            resultModel ??= new PaymentResponse();
            resultModel.StatusCode = (int)response.StatusCode;
            resultModel.IsSuccess = true;

            _logger.LogInformation("{MethodName} Response: {Payload}", nameof(Pay), contentResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "QnbClient client error (Pay) : {ExMessage}", ex.Message);
            resultModel ??= new PaymentResponse();
            resultModel.Message = ex.Message;
        }

        return resultModel;
    }

    public async Task<SmartPaymentResponse> SmartPay(SmartPaymentRequest request, Settings settings, string token)
    {
        var header = new Dictionary<string, string> { { "Authorization", "Bearer " + token } };
        DefaultHeaderInitial(header);

        var resultModel = new SmartPaymentResponse();

        try
        {
            var response = await _httpClient.PostAsync(GetSmartPayUrl, CreatePayload(request), CancellationToken.None);
            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();
            resultModel = JsonSerializer.Deserialize<SmartPaymentResponse>(contentResponse);

            resultModel ??= new SmartPaymentResponse();
            resultModel.StatusCode = (int)response.StatusCode;
            resultModel.IsSuccess = true;

            _logger.LogInformation("{MethodName} Response: {Payload}", nameof(SmartPay), contentResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "QnbClient client error (SmartPay) : {ExMessage}", ex.Message);
            resultModel ??= new SmartPaymentResponse();
            resultModel.Message = ex.Message;
        }

        return resultModel;
    }

    public async Task<BrandedPaymentResponse> BrandedPay(BrandedPaymentRequest request, Settings settings)
    {
        var formData = new Dictionary<string, string>
        {
            { "currency_code", request.currency_code },
            { "invoice", JsonSerializer.Serialize(request.invoice).Trim() },
            { "merchant_key", request._settings.MerchantKey },
            { "name", request.name },
            { "surname", request.surname }
        };
        DefaultHeaderInitial(null);

        var resultModel = new BrandedPaymentResponse();

        try
        {
            var response = await _httpClient.PostAsync(GetBrandedPayUrl, CreatePayloadForUrlEncodedData(formData), CancellationToken.None);
            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();
            resultModel = JsonSerializer.Deserialize<BrandedPaymentResponse>(contentResponse);

            resultModel ??= new BrandedPaymentResponse();
            resultModel.StatusCode = (int)response.StatusCode;
            resultModel.IsSuccess = true;

            _logger.LogInformation("{MethodName} Response: {Payload}", nameof(BrandedPay), contentResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "QnbClient client error (BrandedPay) : {ExMessage}", ex.Message);
            resultModel ??= new BrandedPaymentResponse();
            resultModel.Message = ex.Message;
        }

        return resultModel;
    }

    public async Task<GetOrderStatusResponse> GetOrderStatus(GetOrderStatusRequest request, Settings settings)
    {
        var formData = new Dictionary<string, string>
        {
            { "merchant_key", request._settings.MerchantKey },
            { "invoice_id", request.invoice_id }
        };
        DefaultHeaderInitial();

        var resultModel = new GetOrderStatusResponse();

        try
        {
            var response = await _httpClient.PostAsync(GetOrderStatusUrl, CreatePayloadForUrlEncodedData(formData), CancellationToken.None);
            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();
            resultModel = JsonSerializer.Deserialize<GetOrderStatusResponse>(contentResponse);

            resultModel ??= new GetOrderStatusResponse();
            resultModel.StatusCode = (int)response.StatusCode;
            resultModel.IsSuccess = true;

            _logger.LogInformation("{MethodName} Response: {Payload}", nameof(GetOrderStatus), contentResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "QnbClient client error (GetOrderStatus) : {ExMessage}", ex.Message);
            resultModel ??= new GetOrderStatusResponse();
            resultModel.Message = ex.Message;
        }

        return resultModel;
    }

    public async Task<RefundResponse> Refund(RefundRequest request, Settings settings, string token)
    {
        var header = new Dictionary<string, string> { { "Authorization", "Bearer " + token } };

        DefaultHeaderInitial(header);

        var resultModel = new RefundResponse();

        try
        {
            var response = await _httpClient.PostAsync(GetRefundUrl, CreatePayload(request), CancellationToken.None);
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
                return resultModel;

            var contentResponse = await response.Content.ReadAsStringAsync();
            resultModel = JsonSerializer.Deserialize<RefundResponse>(contentResponse);

            resultModel ??= new RefundResponse();
            resultModel.StatusCode = (int)response.StatusCode;
            resultModel.IsSuccess = true;

            _logger.LogInformation("{MethodName} Response: {Payload}", nameof(Refund), contentResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "QnbClient client error (Refund) : {ExMessage}", ex.Message);
            resultModel ??= new RefundResponse();
            resultModel.Message = ex.Message;
        }

        return resultModel;
    }
}

