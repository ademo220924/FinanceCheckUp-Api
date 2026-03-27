using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGetChartRasyo;
public class dashbilancomltOnGetChartRasyoQueryHandler(ICompanyManager companyManager, IHhvnUsersManager hhvnUsersManager, IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<dashbilancomltOnGetChartRasyoQuery, GenericResult<dashbilancomltOnGetChartRasyoResponse>>
{

    public async Task<GenericResult<dashbilancomltOnGetChartRasyoResponse>> Handle(dashbilancomltOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULT(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
        request.InitialModel.ncart = new DashYearlyBilancoChart();
        request.InitialModel.ncart.SetResult(request.InitialModel.nRequestList, request.InitialModel.CurrentUser.SelectedYear);

                return GenericResult<dashbilancomltOnGetChartRasyoResponse>.Success(new dashbilancomltOnGetChartRasyoResponse { Result = DataSourceLoader.Load(request.InitialModel.ncart.nresult, request.Request.DataSourceLoadOptions) });
    }
}