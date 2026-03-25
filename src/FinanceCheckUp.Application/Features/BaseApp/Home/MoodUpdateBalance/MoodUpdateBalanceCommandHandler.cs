using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateBalance;

public class MoodUpdateBalanceCommandHandler(IReportSetMainSqlOperationManager reportSetMainSqlOperationManager)
    : IRequestHandler<MoodUpdateBalanceCommand, GenericResult<MoodUpdateBalanceResponse>>
{
    public Task<GenericResult<MoodUpdateBalanceResponse>> Handle(MoodUpdateBalanceCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUpdateBalanceRequest.PageIndex;
        try
        {
            reportSetMainSqlOperationManager.Set_ReportSet(pageIndex.year, pageIndex.companyid);
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MoodUpdateBalanceResponse>.Success(
                new MoodUpdateBalanceResponse { ResultText = new JsonResult("nok_" + ex.ToString()) }));
        }

        return Task.FromResult(GenericResult<MoodUpdateBalanceResponse>.Success(
            new MoodUpdateBalanceResponse { ResultText = new JsonResult("ok") }));
    }
}
