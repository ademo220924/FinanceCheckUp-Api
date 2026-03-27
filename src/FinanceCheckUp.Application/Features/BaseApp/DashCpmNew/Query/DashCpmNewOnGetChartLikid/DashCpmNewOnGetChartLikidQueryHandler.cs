using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGetChartLikid;

public class DashCpmNewOnGetChartLikidQueryHandler(
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager,
    IDashLikiditeRiskTrendManager dashLikiditeRiskTrendManager) : IRequestHandler<DashCpmNewOnGetChartLikidQuery, GenericResult<DashCpmNewOnGetChartLikidResponse>>
{

    public async Task<GenericResult<DashCpmNewOnGetChartLikidResponse>> Handle(DashCpmNewOnGetChartLikidQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        request.Request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialModel.LikiditeRiskTrendView = new DashYearlyResultChart();
        request.Request.InitialModel.LikiditeRiskTrend = dashLikiditeRiskTrendManager.LikiditeRiskTrend21Final(request.Request.InitialModel.CurrentUser.SelectedYear, request.Request.InitialModel.CompID);
        request.Request.InitialModel.LikiditeRiskTrendView.SetResult(request.Request.InitialModel.LikiditeRiskTrend, request.Request.InitialModel.CurrentUser.SelectedYear);
                return GenericResult<DashCpmNewOnGetChartLikidResponse>.Success(new DashCpmNewOnGetChartLikidResponse { Response = DataSourceLoader.Load(request.Request.InitialModel.LikiditeRiskTrendView.nresult, request.Request.Options) });
    }
}