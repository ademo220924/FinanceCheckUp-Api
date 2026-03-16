using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarma;

public class MoodUpdatesAktarmaCommandHandle(IReportSetMainSqlOperationManager reportSetMainSqlOperationManager) : IRequestHandler<MoodUpdatesAktarmaCommand, GenericResult<MoodUpdatesAktarmaResponse>>
{
    public async Task<GenericResult<MoodUpdatesAktarmaResponse>> Handle(MoodUpdatesAktarmaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            reportSetMainSqlOperationManager.StartCompanyAktarma(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            return GenericResult<MoodUpdatesAktarmaResponse>.Success(new MoodUpdatesAktarmaResponse() { ResultText = new JsonResult("ok") });
        }
        catch (Exception ex)
        {
            return GenericResult<MoodUpdatesAktarmaResponse>.Fail("nok " + ex.ToString());
        }
    }
}