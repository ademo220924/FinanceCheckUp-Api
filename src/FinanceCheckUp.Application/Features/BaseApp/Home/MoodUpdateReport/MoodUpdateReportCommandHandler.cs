using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateReport;

public class MoodUpdateReportCommandHandler(IMainDashManager mainDashManager, IErrorCheckMainManager errorCheckMainManager)
    : IRequestHandler<MoodUpdateReportCommand, GenericResult<MoodUpdateReportResponse>>
{
    public Task<GenericResult<MoodUpdateReportResponse>> Handle(MoodUpdateReportCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUpdateReportRequest.PageIndex;
        try
        {
            int csvId = mainDashManager.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);
            errorCheckMainManager.Set_ReportSet(csvId);
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MoodUpdateReportResponse>.Success(
                new MoodUpdateReportResponse { ResultText = new JsonResult("nok_" + ex.ToString()) }));
        }

        return Task.FromResult(GenericResult<MoodUpdateReportResponse>.Success(
            new MoodUpdateReportResponse { ResultText = new JsonResult("ok") }));
    }
}
