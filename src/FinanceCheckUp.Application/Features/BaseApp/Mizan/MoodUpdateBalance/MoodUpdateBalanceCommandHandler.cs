using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdateBalance;
public class MoodUpdateBalanceCommandHandle(IDashBilancoSetMizanManager dashBilancoSetMizanManager) : IRequestHandler<MoodUpdateBalanceCommand, GenericResult<MoodUpdateBalanceResponse>>
{
    public async Task<GenericResult<MoodUpdateBalanceResponse>> Handle(MoodUpdateBalanceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            dashBilancoSetMizanManager.Set_ReportSetMizanKayit(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            return GenericResult<MoodUpdateBalanceResponse>.Success(new MoodUpdateBalanceResponse() { ResultText = new JsonResult("ok") });
        }
        catch (Exception ex)
        {
            return GenericResult<MoodUpdateBalanceResponse>.Fail("nok " + ex.ToString());
        }
    }
}