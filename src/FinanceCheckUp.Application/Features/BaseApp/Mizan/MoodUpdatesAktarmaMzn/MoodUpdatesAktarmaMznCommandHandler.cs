using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaMzn;

public class MoodUpdatesAktarmaMznCommandHandle(IReportSetMainSqlOperationManager reportSetMainSqlOperationManager) : IRequestHandler<MoodUpdatesAktarmaMznCommand, GenericResult<MoodUpdatesAktarmaMznResponse>>
{
    public async Task<GenericResult<MoodUpdatesAktarmaMznResponse>> Handle(MoodUpdatesAktarmaMznCommand request, CancellationToken cancellationToken)
    {
        try
        {
            reportSetMainSqlOperationManager.StartCompanyAktarmaMizan(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            return GenericResult<MoodUpdatesAktarmaMznResponse>.Success(new MoodUpdatesAktarmaMznResponse() { ResultText = new JsonResult("ok") });
        }
        catch (Exception ex)
        {
            return GenericResult<MoodUpdatesAktarmaMznResponse>.Fail("nok " + ex.ToString());
        }
    }
}