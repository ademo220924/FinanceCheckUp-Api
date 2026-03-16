using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMain.Query.ReportMainOnGetDonemselKarZarar;
public class MizanReportMainOnGetDonemselKarZararQueryHandler(
    IReportDashMizanManager reportDashMizanManager,
    IHhvnUsersManager hhvnUsersManager) : IRequestHandler<MizanReportMainOnGetDonemselKarZararQuery, GenericResult<MizanReportMainOnGetDonemselKarZararResponse>>
{
    

    public Task<GenericResult<MizanReportMainOnGetDonemselKarZararResponse>> Handle(MizanReportMainOnGetDonemselKarZararQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        {
            return Task.FromResult(GenericResult<MizanReportMainOnGetDonemselKarZararResponse>.Success(new MizanReportMainOnGetDonemselKarZararResponse
            {
                Response =new JsonResult(DataSourceLoader.Load(new List<YearlyReportDashMizan>(),request.Request.options))
            }));
        }

        var retval = reportDashMizanManager.Get_Data_DonemselKarzarar(request.Request.compid).OrderBy(x => x.Year);
        return Task.FromResult(GenericResult<MizanReportMainOnGetDonemselKarZararResponse>.Success(new MizanReportMainOnGetDonemselKarZararResponse
        {
            Response =new JsonResult(DataSourceLoader.Load(retval, request.Request.options))
        }));
    }
}
