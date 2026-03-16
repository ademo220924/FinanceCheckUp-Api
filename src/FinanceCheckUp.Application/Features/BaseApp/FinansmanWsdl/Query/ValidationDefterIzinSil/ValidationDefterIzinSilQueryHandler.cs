using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Client.Wsdl;
using FinanceCheckUp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationDefterIzinSil;

public class ValidationDefterIzinSilQueryHandler(IFinansmanClient finansmanClient, IOptions<SoapHelperSettings> soapHelperSettings, ITBLAAQnbSignLogManager tBLAAQnbSignLogManager) : IRequestHandler<ValidationDefterIzinSilQuery, FinansmanEntegrasyonResponse>
{
    private readonly IFinansmanClient _finansmanClient = finansmanClient ?? throw new ArgumentNullException(nameof(finansmanClient));
    private readonly SoapHelperSettings _soapHelperSettings = soapHelperSettings.Value;

    public async Task<FinansmanEntegrasyonResponse> Handle(ValidationDefterIzinSilQuery request, CancellationToken cancellationToken)
    {
        var input = request.FinansmanEntegrasyonRequest.FinansmanEntegrasyon;


        TblaaqnbSignLog chk = tBLAAQnbSignLogManager.Get_TBLAAQnbSignLogRow(Convert.ToInt64(input.rowide));

        if (chk.CompanyEntegratorId == 3 || chk.CompanyEntegratorId == 4)
        {
            long usride = Convert.ToInt64(input.ide);
            long compide = Convert.ToInt64(input.comide);
            long rwide = Convert.ToInt64(input.rowide);


            chk.IsDeclined = 1;
            chk.DeclinedDate = DateTime.Now;
            chk.DeclinedUserId = usride;
            tBLAAQnbSignLogManager.Update_TBLAAQnbSignLog(chk);
            return new FinansmanEntegrasyonResponse { Result = new JsonResult("Ýzin Ýçin Verilen Kayýt Silindi") };
        }

        try
        {
            var result = await _finansmanClient.DefterIzinSilAsync(
                                                                    _soapHelperSettings.UserName,
                                                                    _soapHelperSettings.Password,
                                                                     input.qnbUserId,
                                                                     cancellationToken);

            if (result != null)
            {
                long usride = Convert.ToInt64(input.ide);
                long compide = Convert.ToInt64(input.comide);
                long rwide = Convert.ToInt64(input.rowide);


                chk.IsDeclined = 1;
                chk.DeclinedDate = DateTime.Now;
                chk.DeclinedUserId = usride;
                tBLAAQnbSignLogManager.Update_TBLAAQnbSignLog(chk);
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