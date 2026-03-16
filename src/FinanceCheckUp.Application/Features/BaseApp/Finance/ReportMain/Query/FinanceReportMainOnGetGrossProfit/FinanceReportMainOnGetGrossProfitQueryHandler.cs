using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetGrossProfit;
public class FinanceReportMainOnGetGrossProfitQueryHandler(
    IReportDashManager reportDashManager,
    IHhvnUsersManager hhvnUsersManager) : IRequestHandler<FinanceReportMainOnGetGrossProfitQuery, GenericResult<FinanceReportMainOnGetGrossProfitResponse>>
{

    public Task<GenericResult<FinanceReportMainOnGetGrossProfitResponse>> Handle(FinanceReportMainOnGetGrossProfitQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
         
        if (hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        {
            var retval = reportDashManager.Get_Data_GrossProfit(request.Request.myear, request.Request.compid);
            return Task.FromResult(GenericResult<FinanceReportMainOnGetGrossProfitResponse>.Success(new FinanceReportMainOnGetGrossProfitResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(retval, request.Request.options))
            }));
        }
       
        return Task.FromResult(GenericResult<FinanceReportMainOnGetGrossProfitResponse>.Success(new FinanceReportMainOnGetGrossProfitResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options))
        }));
    }
}
