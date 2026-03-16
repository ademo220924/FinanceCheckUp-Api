using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetEbitMarjin;
public class FinanceReportMainOnGetEbitMarjinQueryHandler(
    IReportDashManager reportDashManager,
    IHhvnUsersManager hhvnUsersManager) : IRequestHandler<FinanceReportMainOnGetEbitMarjinQuery, GenericResult<FinanceReportMainOnGetEbitMarjinResponse>>
{

    public Task<GenericResult<FinanceReportMainOnGetEbitMarjinResponse>> Handle(FinanceReportMainOnGetEbitMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
         
        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        { 
            return Task.FromResult(GenericResult<FinanceReportMainOnGetEbitMarjinResponse>.Success(new FinanceReportMainOnGetEbitMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options))
            }));
        }

        var retval = reportDashManager.Get_Data_EbitMarjin(request.Request.myear, request.Request.compid);
        
        return Task.FromResult(GenericResult<FinanceReportMainOnGetEbitMarjinResponse>.Success(new FinanceReportMainOnGetEbitMarjinResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(retval, request.Request.options))
        }));
    }
}
