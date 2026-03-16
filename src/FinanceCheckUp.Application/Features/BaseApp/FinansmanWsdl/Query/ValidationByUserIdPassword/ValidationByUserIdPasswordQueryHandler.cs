using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Client.Wsdl;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationByUserIdPassword;

public class ValidationByUserIdPasswordQueryHandle(IFinansmanClient finansmanClient, IOptions<SoapHelperSettings> soapHelperSettings) : IRequestHandler<ValidationByUserIdPasswordQuery, FinansmanEntegrasyonResponse>
{
    private readonly IFinansmanClient _finansmanClient = finansmanClient ?? throw new ArgumentNullException(nameof(finansmanClient));
    private readonly SoapHelperSettings _soapHelperSettings = soapHelperSettings.Value;


    public async Task<FinansmanEntegrasyonResponse> Handle(ValidationByUserIdPasswordQuery request, CancellationToken cancellationToken)
    {
        var input = request.FinansmanEntegrasyonRequest.FinansmanEntegrasyon;

        try
        {
            var result = await _finansmanClient.UserValidationByUserIdPasswordAsync(_soapHelperSettings.UserName,
                                                                               _soapHelperSettings.Password,
                                                                               input.kulaniciKodu,
                                                                               input.password,
                                                                               input.vknTckn,
                                                                               cancellationToken);

            //if (result != null)
            //{
            //     return new FinansmanEntegrasyonResponse { Result = new JsonResult(result.@return.responseCode + "_" + StringUtilities.UppercaseWords(result.@return.responseMessage)) };
            //}
            return new FinansmanEntegrasyonResponse { Result = new JsonResult(result) };

        }
        catch (Exception ex)
        {
            return new FinansmanEntegrasyonResponse { Result = new JsonResult(ex.Message) };
        }
    }
}