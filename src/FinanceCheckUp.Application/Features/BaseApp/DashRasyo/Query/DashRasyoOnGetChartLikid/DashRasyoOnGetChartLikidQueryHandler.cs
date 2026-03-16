using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetChartLikid;
public class DashRasyoOnGetChartLikidQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    IDashLikiditeRiskTrendManager dashLikiditeRiskTrendManager) : IRequestHandler<DashRasyoOnGetChartLikidQuery, GenericResult<DashRasyoOnGetChartLikidResponse>>
{

    public async Task<GenericResult<DashRasyoOnGetChartLikidResponse>> Handle(DashRasyoOnGetChartLikidQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        request.Request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialModel.LikiditeRiskTrendView = new DashYearlyResultChart();
        request.Request.InitialModel.LikiditeRiskTrend = dashLikiditeRiskTrendManager.LikiditeRiskTrend21Final(request.Request.InitialModel.CurrentUser.SelectedYear, request.Request.InitialModel.CompID);
        request.Request.InitialModel.LikiditeRiskTrendView.SetResult(request.Request.InitialModel.LikiditeRiskTrend, request.Request.InitialModel.CurrentUser.SelectedYear);

        return GenericResult<DashRasyoOnGetChartLikidResponse>.Success(new DashRasyoOnGetChartLikidResponse { Response = new JsonResult(DataSourceLoader.Load(request.Request.InitialModel.LikiditeRiskTrendView.nresult, request.Request.Options)) });
    }
}