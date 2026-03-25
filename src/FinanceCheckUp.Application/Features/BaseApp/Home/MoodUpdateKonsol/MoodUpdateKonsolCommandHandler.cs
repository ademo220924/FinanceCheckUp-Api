using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateKonsol;

public class MoodUpdateKonsolCommandHandler(IReportSetMainSqlOperationManager reportSetMainSqlOperationManager)
    : IRequestHandler<MoodUpdateKonsolCommand, GenericResult<MoodUpdateKonsolResponse>>
{
    public Task<GenericResult<MoodUpdateKonsolResponse>> Handle(MoodUpdateKonsolCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUpdateKonsolRequest.PageIndex;
        try
        {
            reportSetMainSqlOperationManager.Set_ReportSetKon(pageIndex.year, pageIndex.companyid);
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MoodUpdateKonsolResponse>.Success(
                new MoodUpdateKonsolResponse { ResultText = new JsonResult("nok_" + ex.ToString()) }));
        }

        return Task.FromResult(GenericResult<MoodUpdateKonsolResponse>.Success(
            new MoodUpdateKonsolResponse { ResultText = new JsonResult("ok") }));
    }
}
