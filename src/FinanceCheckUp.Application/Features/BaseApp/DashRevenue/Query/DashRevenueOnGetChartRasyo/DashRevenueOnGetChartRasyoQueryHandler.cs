using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGetChartRasyo;
public class DashRevenueOnGetChartRasyoQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    IDashBilancoManager dashBilancoManager) : IRequestHandler<DashRevenueOnGetChartRasyoQuery, GenericResult<DashRevenueOnGetChartRasyoResponse>>
{

    public async Task<GenericResult<DashRevenueOnGetChartRasyoResponse>> Handle(DashRevenueOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {



        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);

        request.Request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialModel.ncart = new DashYearlyRevenueChart();
        request.Request.InitialModel.nRequestList = dashBilancoManager.Get_MAINRESULT(request.Request.InitialModel.CurrentUser.SelectedYear, request.Request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
        request.Request.InitialModel.ncart.SetResult(request.Request.InitialModel.nRequestList, request.Request.InitialModel.CurrentUser.SelectedYear);



                return GenericResult<DashRevenueOnGetChartRasyoResponse>.Success(new DashRevenueOnGetChartRasyoResponse { Response = DataSourceLoader.Load(request.Request.InitialModel.ncart.nresult, request.Request.Options) });
    }
}