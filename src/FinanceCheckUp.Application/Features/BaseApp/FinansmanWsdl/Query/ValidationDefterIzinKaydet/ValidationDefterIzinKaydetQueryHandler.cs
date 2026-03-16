using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Client.Wsdl;
using FinanceCheckUp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationDefterIzinKaydet;

public class ValidationDefterIzinKaydetQueryHandle
    (
    IFinansmanClient finansmanClient,
    IOptions<SoapHelperSettings> soapHelperSettings,
    ITBLAAQnbSignLogManager tBLAAQnbSignLogManager
    ) : IRequestHandler<ValidationDefterIzinKaydetQuery, FinansmanEntegrasyonResponse>
{
    private readonly IFinansmanClient _finansmanClient = finansmanClient ?? throw new ArgumentNullException(nameof(finansmanClient));
    private readonly SoapHelperSettings _soapHelperSettings = soapHelperSettings.Value;

    public async Task<FinansmanEntegrasyonResponse> Handle(ValidationDefterIzinKaydetQuery request, CancellationToken cancellationToken)
    {
        var input = request.FinansmanEntegrasyonRequest.FinansmanEntegrasyon;

        long comide = Convert.ToInt64(input.comide);
        long ide = Convert.ToInt64(input.ide);

        try
        {
            var result = await _finansmanClient.IzinKaydetAsync(_soapHelperSettings.UserName,
                                                                 _soapHelperSettings.Password,
                                                                   input.vknTckn,
                                                                   input.hedefkaynak,
                                                                   cancellationToken);


            var chkke = new TblaaqnbSignLog(ide, comide, 1, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), 0, null, null, 0, null, null, 1);
            tBLAAQnbSignLogManager.Save_TBLAAQnbSignLog(chkke);

            if (result != null)
            {
                return new FinansmanEntegrasyonResponse { Result = new JsonResult(result) };
                //return new FinansmanEntegrasyonResponse { Result = new JsonResult(result.@return.responseCode + "_" + CommonUtilities.UppercaseWords(result.@return.responseMessage)) };
            }
            return new FinansmanEntegrasyonResponse { Result = new JsonResult(result) };

        }
        catch (Exception ex)
        {
            return new FinansmanEntegrasyonResponse { Result = new JsonResult(ex.Message) };
        }
    }
}