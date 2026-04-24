using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMain.Query.ReportMainOnGetWorkingCapital;
public class MizanReportMainOnGetWorkingCapitalQueryHandler(IReportDashMizanManager reportDashMizanManager,IHhvnUsersManager hhvnUsersManager) : IRequestHandler<MizanReportMainOnGetWorkingCapitalQuery, GenericResult<MizanReportMainOnGetWorkingCapitalResponse>>
{

    public Task<GenericResult<MizanReportMainOnGetWorkingCapitalResponse>> Handle(MizanReportMainOnGetWorkingCapitalQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        { 
            
            return Task.FromResult(GenericResult<MizanReportMainOnGetWorkingCapitalResponse>.Success(new MizanReportMainOnGetWorkingCapitalResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportDashMizan>(), request.Request.options)
            }));
        }

        IEnumerable<YearlyReportDashMizan> chk = reportDashMizanManager.Get_Data_WorkingCapital(request.Request.compid).OrderBy(x => x.Year);
        
        return Task.FromResult(GenericResult<MizanReportMainOnGetWorkingCapitalResponse>.Success(new MizanReportMainOnGetWorkingCapitalResponse
        {
            Response = DataSourceLoader.Load(chk, request.Request.options)
        }));
    }
}
