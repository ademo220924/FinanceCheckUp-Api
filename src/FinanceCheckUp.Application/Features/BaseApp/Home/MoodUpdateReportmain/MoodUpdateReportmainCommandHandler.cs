using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateReportmain;

public class MoodUpdateReportmainCommandHandler(IReportSetMainSqlOperationManager reportSetMainSqlOperationManager)
    : IRequestHandler<MoodUpdateReportmainCommand, GenericResult<MoodUpdateReportmainResponse>>
{
    public Task<GenericResult<MoodUpdateReportmainResponse>> Handle(MoodUpdateReportmainCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUpdateReportmainRequest.PageIndex;
        try
        {
            reportSetMainSqlOperationManager.Set_ReportSetMain(pageIndex.year, pageIndex.companyid);
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MoodUpdateReportmainResponse>.Success(
                new MoodUpdateReportmainResponse { ResultText = new JsonResult("nok_" + ex.ToString()) }));
        }

        return Task.FromResult(GenericResult<MoodUpdateReportmainResponse>.Success(
            new MoodUpdateReportmainResponse { ResultText = new JsonResult("ok") }));
    }
}
