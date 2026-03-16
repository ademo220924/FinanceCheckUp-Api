using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartLikid;
public class DashCrmOnGetChartLikidQueryHandler(
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager,
    IDashLikiditeRiskTrendManager dashLikiditeRiskTrendManager) : IRequestHandler<DashCrmOnGetChartLikidQuery, GenericResult<DashCrmOnGetChartLikidResponse>>
{

    public async Task<GenericResult<DashCrmOnGetChartLikidResponse>> Handle(DashCrmOnGetChartLikidQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        request.Request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialModel.LikiditeRiskTrendView = new DashYearlyResultChart();
        request.Request.InitialModel.LikiditeRiskTrend = dashLikiditeRiskTrendManager.LikiditeRiskTrend21Final(request.Request.InitialModel.CurrentUser.SelectedYear, request.Request.InitialModel.CompID);
        request.Request.InitialModel.LikiditeRiskTrendView.SetResult(request.Request.InitialModel.LikiditeRiskTrend, request.Request.InitialModel.CurrentUser.SelectedYear);
        return GenericResult<DashCrmOnGetChartLikidResponse>.Success(new DashCrmOnGetChartLikidResponse { Response = new JsonResult(DataSourceLoader.Load(request.Request.InitialModel.LikiditeRiskTrendView.nresult, request.Request.Options)) });
    }
}