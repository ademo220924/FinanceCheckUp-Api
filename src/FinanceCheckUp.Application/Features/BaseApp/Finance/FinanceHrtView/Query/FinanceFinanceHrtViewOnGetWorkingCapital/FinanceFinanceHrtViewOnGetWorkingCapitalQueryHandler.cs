using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtView.Query.FinanceFinanceHrtViewOnGetWorkingCapital;
public class FinanceFinanceHrtViewOnGetWorkingCapitalQueryHandler(IHhvnUsersManager hhvnUsersManager, IReportDashManager reportDashManager) : IRequestHandler<FinanceFinanceHrtViewOnGetWorkingCapitalQuery, GenericResult<FinanceFinanceHrtViewOnGetWorkingCapitalResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtViewOnGetWorkingCapitalResponse>> Handle(FinanceFinanceHrtViewOnGetWorkingCapitalQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.InitialModel.CompID, (int)userId))
        {
                        return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetWorkingCapitalResponse>.Success(new FinanceFinanceHrtViewOnGetWorkingCapitalResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
            }));
        }

        DashYearlyResultWorkingCapital chk = reportDashManager.Get_Data_WorkingCapital(request.Request.myear, request.InitialModel.CompID);
        int lastmont = reportDashManager.Get_LastMonthYear(request.Request.myear, request.InitialModel.CompID);
        request.InitialModel.dashWorkingCapital = DashYearlyResultChart.SetResultMain(chk, request.Request.myear);

                return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetWorkingCapitalResponse>.Success(new FinanceFinanceHrtViewOnGetWorkingCapitalResponse
        {
            Response = DataSourceLoader.Load(request.InitialModel.dashWorkingCapital, request.Request.options)
        }));

    }
}
