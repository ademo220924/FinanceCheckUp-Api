using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmlt.Query.dashbilancorvnmltOnGetChartRasyo;
public class dashbilancorvnmltOnGetChartRasyoQueryHandler(ICompanyManager companyManager, IHhvnUsersManager hhvnUsersManager, IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<dashbilancorvnmltOnGetChartRasyoQuery, GenericResult<dashbilancorvnmltOnGetChartRasyoResponse>>
{

    public async Task<GenericResult<dashbilancorvnmltOnGetChartRasyoResponse>> Handle(dashbilancorvnmltOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULT(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
        request.InitialModel.ncart = new DashYearlyBilancoChart();
        request.InitialModel.ncart.SetResult(request.InitialModel.nRequestList, request.InitialModel.CurrentUser.SelectedYear);

        return GenericResult<dashbilancorvnmltOnGetChartRasyoResponse>.Success(new dashbilancorvnmltOnGetChartRasyoResponse { Result = new JsonResult(DataSourceLoader.Load(request.InitialModel.ncart.nresult, request.Request.DataSourceLoadOptions)) });
    }
}