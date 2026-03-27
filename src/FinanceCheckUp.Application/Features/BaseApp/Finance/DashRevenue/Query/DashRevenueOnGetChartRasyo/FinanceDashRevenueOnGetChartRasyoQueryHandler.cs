using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRevenue.Query.DashRevenueOnGetChartRasyo;
public class FinanceDashRevenueOnGetChartRasyoQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    IDashBilancoManager dashBilancoManager) : IRequestHandler<FinanceDashRevenueOnGetChartRasyoQuery, GenericResult<FinanceDashRevenueOnGetChartRasyoResponse>>
{
    public Task<GenericResult<FinanceDashRevenueOnGetChartRasyoResponse>> Handle(FinanceDashRevenueOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.ncart = new DashYearlyRevenueChart();
        request.InitialModel.nRequestList = dashBilancoManager.Get_MAINRESULT(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
        request.InitialModel.ncart.SetResult(request.InitialModel.nRequestList, request.InitialModel.CurrentUser.SelectedYear);

                return Task.FromResult(GenericResult<FinanceDashRevenueOnGetChartRasyoResponse>.Success(new FinanceDashRevenueOnGetChartRasyoResponse
        {
            Response = DataSourceLoader.Load(request.InitialModel.ncart.nresult, request.Request.options)
        }));

    }
}
