using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMain.Query.ReportMainOnGetGrossProfit;
public class MizanReportMainOnGetGrossProfitQueryHandler( 
    IReportDashMizanManager reportDashMizanManager,
    IHhvnUsersManager hhvnUsersManager) : IRequestHandler<MizanReportMainOnGetGrossProfitQuery, GenericResult<MizanReportMainOnGetGrossProfitResponse>>
{

    public Task<GenericResult<MizanReportMainOnGetGrossProfitResponse>> Handle(MizanReportMainOnGetGrossProfitQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        {
            var retval = reportDashMizanManager.Get_Data_GrossProfit(request.Request.compid).OrderBy(x => x.Year);
           
                        return Task.FromResult(GenericResult<MizanReportMainOnGetGrossProfitResponse>.Success(new MizanReportMainOnGetGrossProfitResponse
            {
                Response = DataSourceLoader.Load(retval, request.Request.options)
            }));
        } 
        
                return Task.FromResult(GenericResult<MizanReportMainOnGetGrossProfitResponse>.Success(new MizanReportMainOnGetGrossProfitResponse
        {
            Response = DataSourceLoader.Load(new List<YearlyReportDashMizan>(), request.Request.options)
        }));
    }
}
