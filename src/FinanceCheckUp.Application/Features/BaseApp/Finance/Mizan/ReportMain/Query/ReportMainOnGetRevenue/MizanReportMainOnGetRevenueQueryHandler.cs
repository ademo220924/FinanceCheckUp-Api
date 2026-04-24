using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMain.Query.ReportMainOnGetRevenue;
public class MizanReportMainOnGetRevenueQueryHandler(IReportDashMizanManager reportDashMizanManager,IHhvnUsersManager hhvnUsersManager) : IRequestHandler<MizanReportMainOnGetRevenueQuery, GenericResult<MizanReportMainOnGetRevenueResponse>>
{

    public Task<GenericResult<MizanReportMainOnGetRevenueResponse>> Handle(MizanReportMainOnGetRevenueQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        { 
            return Task.FromResult(GenericResult<MizanReportMainOnGetRevenueResponse>.Success(new MizanReportMainOnGetRevenueResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportDashMizan>(), request.Request.options)
            }));
        }

        var retval = reportDashMizanManager.Get_Data_Revenue(request.Request.compid).OrderBy(x => x.Year);
         
        return Task.FromResult(GenericResult<MizanReportMainOnGetRevenueResponse>.Success(new MizanReportMainOnGetRevenueResponse
        {
            Response = DataSourceLoader.Load(retval, request.Request.options)
        }));
    }
}
