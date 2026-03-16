using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMain.Query.ReportMainOnGetEbitMarjin;
public class MizanReportMainOnGetEbitMarjinQueryHandler(
    IReportDashMizanManager reportDashMizanManager,
    IHhvnUsersManager hhvnUsersManager) : IRequestHandler<MizanReportMainOnGetEbitMarjinQuery, GenericResult<MizanReportMainOnGetEbitMarjinResponse>>
{
    

    public Task<GenericResult<MizanReportMainOnGetEbitMarjinResponse>> Handle(MizanReportMainOnGetEbitMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        { 
            return Task.FromResult(GenericResult<MizanReportMainOnGetEbitMarjinResponse>.Success(new MizanReportMainOnGetEbitMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(new List<YearlyReportDashMizan>(), request.Request.options))
            }));
        }

        var retval = reportDashMizanManager.Get_Data_EbitMarjin(request.Request.compid).OrderBy(x => x.Year);
         
        return Task.FromResult(GenericResult<MizanReportMainOnGetEbitMarjinResponse>.Success(new MizanReportMainOnGetEbitMarjinResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(retval, request.Request.options))
        }));
    }
}
