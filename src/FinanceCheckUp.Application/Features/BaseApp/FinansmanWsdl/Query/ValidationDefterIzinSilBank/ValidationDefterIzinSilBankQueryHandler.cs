using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationDefterIzinSilBank;

public class ValidationDefterIzinSilBankQueryHandler(ITBLAAQnbSignLogManager tBLAAQnbSignLogManager) : IRequestHandler<ValidationDefterIzinSilBankQuery, FinansmanEntegrasyonResponse>
{
    public async Task<FinansmanEntegrasyonResponse> Handle(ValidationDefterIzinSilBankQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var input = request.FinansmanEntegrasyonRequest.FinansmanEntegrasyon;

            long usride = Convert.ToInt64(input.ide);
            long compide = Convert.ToInt64(input.comide);
            long rwide = Convert.ToInt64(input.rowide);

            TblaaqnbSignLog nlog = tBLAAQnbSignLogManager.Get_TBLAAQnbSignLogRow(rwide);
            nlog.DeclinedDateBank = DateTime.Now;
            nlog.IsDeclinedBank = 1;
            nlog.IsDeclined = 1;
            nlog.DeclinedUserIdbank = usride;
            tBLAAQnbSignLogManager.Update_TBLAAQnbSignLog(nlog);

            return new FinansmanEntegrasyonResponse { Result = new JsonResult("OK") };
        }
        catch (Exception ex)
        {
            return new FinansmanEntegrasyonResponse { Result = new JsonResult(ex.Message) };

        }
    }
}