using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetWorkingCapital;
public class FinanceReportMainOnGetWorkingCapitalQueryHandler(
    IReportDashManager reportDashManager,
    IHhvnUsersManager hhvnUsersManager) : IRequestHandler<FinanceReportMainOnGetWorkingCapitalQuery, GenericResult<FinanceReportMainOnGetWorkingCapitalResponse>>
{
     
    public Task<GenericResult<FinanceReportMainOnGetWorkingCapitalResponse>> Handle(FinanceReportMainOnGetWorkingCapitalQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;

        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        {
                          return Task.FromResult(GenericResult<FinanceReportMainOnGetWorkingCapitalResponse>.Success(new FinanceReportMainOnGetWorkingCapitalResponse
            {
                InitialModel = request.InitialModel,
                Response= DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
            }));
        } 

        var chk = reportDashManager.Get_Data_WorkingCapital(request.Request.myear, request.Request.compid);
        var lastmont = reportDashManager.Get_LastMonthYear(request.Request.myear, request.Request.compid);
        request.InitialModel.dashWorkingCapital = DashYearlyResultChart.SetResultMain(chk, request.Request.myear);

  
                return Task.FromResult(GenericResult<FinanceReportMainOnGetWorkingCapitalResponse>.Success(new FinanceReportMainOnGetWorkingCapitalResponse
        {
            InitialModel = request.InitialModel,
            Response= DataSourceLoader.Load(request.InitialModel.dashWorkingCapital, request.Request.options)
        }));
    }
}
