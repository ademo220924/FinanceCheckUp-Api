using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateKonsolMizan;

public class MoodUpdateKonsolMizanCommandHandler(IReportSetMainSqlOperationManager reportSetMainSqlOperationManager)
    : IRequestHandler<MoodUpdateKonsolMizanCommand, GenericResult<MoodUpdateKonsolMizanResponse>>
{
    public Task<GenericResult<MoodUpdateKonsolMizanResponse>> Handle(MoodUpdateKonsolMizanCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUpdateKonsolMizanRequest.PageIndex;
        try
        {
            reportSetMainSqlOperationManager.Set_ReportSetKonM(pageIndex.year, pageIndex.companyid);
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MoodUpdateKonsolMizanResponse>.Success(
                new MoodUpdateKonsolMizanResponse { ResultText = new JsonResult("nok_" + ex.ToString()) }));
        }

        return Task.FromResult(GenericResult<MoodUpdateKonsolMizanResponse>.Success(
            new MoodUpdateKonsolMizanResponse { ResultText = new JsonResult("ok") }));
    }
}
