using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetChartRasyo;
public class DashRasyoOnGetChartRasyoQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    IRasyoAnalizMainManager rasyoAnalizMainManager) : IRequestHandler<DashRasyoOnGetChartRasyoQuery, GenericResult<DashRasyoOnGetChartRasyoResponse>>
{

    public async Task<GenericResult<DashRasyoOnGetChartRasyoResponse>> Handle(DashRasyoOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        request.Request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialModel.RasyoAnalizView = new DashYearlyResultChart();
        request.Request.InitialModel.RasyoAnaliz = rasyoAnalizMainManager.RasyoAnalizTOTALFinal(request.Request.InitialModel.CurrentUser.SelectedYear, request.Request.InitialModel.CompID);
        request.Request.InitialModel.RasyoAnalizView.SetResult(request.Request.InitialModel.RasyoAnaliz, request.Request.InitialModel.CurrentUser.SelectedYear);

        return GenericResult<DashRasyoOnGetChartRasyoResponse>.Success(new DashRasyoOnGetChartRasyoResponse { Response = new JsonResult(DataSourceLoader.Load(request.Request.InitialModel.RasyoAnalizView.nresult.Where(x => x.TypeID == 1), request.Request.Options)) });
    }
}