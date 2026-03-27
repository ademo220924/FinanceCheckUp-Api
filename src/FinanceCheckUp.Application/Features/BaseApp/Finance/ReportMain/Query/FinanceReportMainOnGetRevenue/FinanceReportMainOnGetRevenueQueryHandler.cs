using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetRevenue;
public class FinanceReportMainOnGetRevenueQueryHandler(
    IReportDashManager reportDashManager,
    IHhvnUsersManager hhvnUsersManager) : IRequestHandler<FinanceReportMainOnGetRevenueQuery, GenericResult<FinanceReportMainOnGetRevenueResponse>>
{

    public Task<GenericResult<FinanceReportMainOnGetRevenueResponse>> Handle(FinanceReportMainOnGetRevenueQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
         
        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        { 
                        return Task.FromResult(GenericResult<FinanceReportMainOnGetRevenueResponse>.Success(new FinanceReportMainOnGetRevenueResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
            }));
        }

        var retval = reportDashManager.Get_Data_Revenue(request.Request.myear, request.Request.compid);
     
                return Task.FromResult(GenericResult<FinanceReportMainOnGetRevenueResponse>.Success(new FinanceReportMainOnGetRevenueResponse
        {
            Response = DataSourceLoader.Load(retval, request.Request.options)
        }));
    }
}
