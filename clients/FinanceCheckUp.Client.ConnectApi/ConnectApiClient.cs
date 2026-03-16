using FinanceCheckUp.Client.ConnectApi.Models.Request;
using FinanceCheckUp.Client.ConnectApi.Models.Response;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using static System.String;

namespace FinanceCheckUp.Client.ConnectApi;

public class ConnectApiClient(HttpClient httpClient) : IConnectApiClient
{
    private const string LoginUrlFormat = "Login/Login?UserName={0}&Password={1}";
    private const string EledgerUrlFormat = "ELedger/GetAllEledgerlist?CompanyPortalUser={0}&CompanyPortalPassword={1}&Identifier={2}&BranchId={3}&StartDate={4}&EndDate={5}&PermissionTargetCode=us";
    private const string UploadFileUrl = "Pdf/UploadPdf";
    private const string GetFileUrlFormat = "Pdf/DownloadPdf?File={0}";

    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<ReturnToken> GetAccount(string userName, string password, CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Clear();

        var path = Format(LoginUrlFormat, userName, password);
        var httpResponseMessage = await _httpClient.GetAsync($"{path}", HttpCompletionOption.ResponseContentRead, cancellationToken);
        httpResponseMessage.EnsureSuccessStatusCode();
        var content = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<ReturnToken>(
            content,
            options: new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }) ?? new ReturnToken();

        return result;
    }

    public async Task<ReturnMainEledger> GetEledger(string userName, string password, string endDate, string startDate, int branchId, FinansmanEntegrasyon finansmanEntegrasyon, CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        var token = await GetAccount(userName, password, cancellationToken);
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.responseMessage);
        var path = Format(EledgerUrlFormat, finansmanEntegrasyon.kulaniciKodu, finansmanEntegrasyon.password, finansmanEntegrasyon.vknTckn, branchId, startDate, endDate);
        var httpResponseMessage = await _httpClient.GetAsync($"{path}", HttpCompletionOption.ResponseContentRead, cancellationToken);
        httpResponseMessage.EnsureSuccessStatusCode();
        var content = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<ReturnMainEledger>(
            content,
            options: new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }) ?? new ReturnMainEledger();

        return result;
    }

    public async Task<string> UploadFile(string userName, string password, string filepath, CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        var token = await GetAccount(userName, password, cancellationToken);
        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "text/plain");
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.responseMessage);

        var multipartContent = new MultipartFormDataContent();
        var file = new ByteArrayContent(await File.ReadAllBytesAsync(filepath, cancellationToken));
        file.Headers.Add("Content-Type", "application/pdf");
        multipartContent.Add(file, "File", Path.GetFileName(filepath));


        var payload = new StringContent(JsonSerializer.Serialize(multipartContent, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }), Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _httpClient.PostAsync(UploadFileUrl, payload, cancellationToken);

        response.EnsureSuccessStatusCode();
        var returnString = await response.Content.ReadAsStringAsync(cancellationToken);

        return returnString;
    }

    public async Task<string> GetFile(string userName, string password, string filepath, CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        var token = await GetAccount(userName, password, cancellationToken);
        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "text/plain");
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.responseMessage);

        var path = Format(GetFileUrlFormat, filepath);
        var httpResponseMessage = await _httpClient.GetAsync($"{path}", HttpCompletionOption.ResponseContentRead, cancellationToken);
        httpResponseMessage.EnsureSuccessStatusCode();
        var returnString = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);


        return returnString;
    }


    public async Task<string> SendApi(string userName, string password, string filepath, CancellationToken cancellationToken)
    {
        ReturnToken token = await GetAccount(userName, password, cancellationToken);

        string returnString = "";
        try
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(10);
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "http://185.201.213.227/Pdf/UploadPdf"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "text/plain");
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token.responseMessage);

                    var multipartContent = new MultipartFormDataContent();
                    var file1 = new ByteArrayContent(File.ReadAllBytes(filepath));
                    file1.Headers.Add("Content-Type", "application/pdf");
                    multipartContent.Add(file1, "File", Path.GetFileName(filepath));
                    request.Content = multipartContent;

                    var response = await httpClient.SendAsync(request);
                    returnString = await response.Content.ReadAsStringAsync();
                }
            }
        }
        catch (Exception ex)
        {
            var tt = ex;
            throw;
        }


        var chk = returnString;
        return returnString;
    }
}