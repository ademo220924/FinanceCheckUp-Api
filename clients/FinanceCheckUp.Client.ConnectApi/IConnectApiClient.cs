using FinanceCheckUp.Client.ConnectApi.Models.Request;
using FinanceCheckUp.Client.ConnectApi.Models.Response;

namespace FinanceCheckUp.Client.ConnectApi;

public interface IConnectApiClient
{
    Task<ReturnToken> GetAccount(string userName, string password, CancellationToken cancellationToken);
    Task<ReturnMainEledger> GetEledger(string userName, string password, string endDate, string startDate, int branchId, FinansmanEntegrasyon npar, CancellationToken cancellationToken);
    Task<string> UploadFile(string userName, string password, string filepath, CancellationToken cancellationToken);
    Task<string> GetFile(string userName, string password, string filepath, CancellationToken cancellationToken);
}