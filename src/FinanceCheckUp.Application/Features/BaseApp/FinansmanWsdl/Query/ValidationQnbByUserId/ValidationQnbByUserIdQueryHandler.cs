using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Client.Wsdl;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationQnbByUserId;

public class ValidationQnbByUserIdQueryHandle(IFinansmanClient finansmanClient, IOptions<SoapHelperSettings> soapHelperSettings) : IRequestHandler<ValidationQnbByUserIdQuery, FinansmanEntegrasyonResponse>
{
    private readonly IFinansmanClient _finansmanClient = finansmanClient ?? throw new ArgumentNullException(nameof(finansmanClient));
    private readonly SoapHelperSettings _soapHelperSettings = soapHelperSettings.Value;

    public async Task<FinansmanEntegrasyonResponse> Handle(ValidationQnbByUserIdQuery request, CancellationToken cancellationToken)
    {
        var input = request.FinansmanEntegrasyonRequest.FinansmanEntegrasyon;

        try
        {
            var result = await _finansmanClient.UserValidationByQnbUserIdAsync(_soapHelperSettings.UserName,
                                                                               _soapHelperSettings.Password,
                                                                               input.qnbUserId,
                                                                               input.vknTckn,
                                                                               cancellationToken);

            return new FinansmanEntegrasyonResponse { Result = new JsonResult(result) };
            // return new FinansmanEntegrasyonResponse { Result = new JsonResult(result.@return.responseCode + "_" + CommonUtilities.UppercaseWords(result.@return.responseMessage)) };
        }
        catch (Exception ex)
        {
            return new FinansmanEntegrasyonResponse { Result = new JsonResult(ex.Message) };
        }
    }
}