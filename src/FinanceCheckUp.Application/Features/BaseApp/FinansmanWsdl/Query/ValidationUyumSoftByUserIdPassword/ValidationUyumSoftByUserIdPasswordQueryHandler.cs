using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Client.ConnectApi;
using FinanceCheckUp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationUyumSoftByUserIdPassword;

public class ValidationUyumSoftByUserIdPasswordQueryHandle
    (
    IConnectApiClient connectApiClient,
    IOptions<AuthenticationSettings> authenticationSettings,
    ITBLAAQnbSignLogManager tBLAAQnbSignLogManager
    ) : IRequestHandler<ValidationUyumSoftByUserIdPasswordQuery, FinansmanEntegrasyonResponse>
{
    private readonly IConnectApiClient _connectApiClient = connectApiClient ?? throw new ArgumentNullException(nameof(connectApiClient));
    private readonly AuthenticationSettings _authenticationSettings = authenticationSettings.Value;

    public async Task<FinansmanEntegrasyonResponse> Handle(ValidationUyumSoftByUserIdPasswordQuery request, CancellationToken cancellationToken)
    {
        try
        {
            long ide1 = 0;
            long comide1 = 0;

            ide1 = Convert.ToInt64(request.FinansmanEntegrasyonRequest.FinansmanEntegrasyon.ide);
            comide1 = Convert.ToInt64(request.FinansmanEntegrasyonRequest.FinansmanEntegrasyon.comide);

            var response = await _connectApiClient.GetEledger(
           _authenticationSettings.UserName,
           _authenticationSettings.Password,
           request.EndDate,
           request.StartDate,
           request.BranchId,
           request.FinansmanEntegrasyonRequest.FinansmanEntegrasyon,
           cancellationToken);

            var chkke = new TblaaqnbSignLog(ide1, comide1, 4, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), 0, null, null, 0, null, null, 1);
            tBLAAQnbSignLogManager.Save_TBLAAQnbSignLog(chkke);
            var hh = response;

            return new FinansmanEntegrasyonResponse { Result = new JsonResult(response) };

        }
        catch (Exception ex)
        {
            return new FinansmanEntegrasyonResponse { Result = new JsonResult(ex.Message) };
        }
    }
}