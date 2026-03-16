using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetChartLikid;
public class FinanceDashCrmOnGetChartLikidQueryHandler(IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    IDashLikiditeRiskTrendManager dashLikiditeRiskTrendManager) : IRequestHandler<FinanceDashCrmOnGetChartLikidQuery, GenericResult<FinanceDashCrmOnGetChartLikidResponse>>
{
    public Task<GenericResult<FinanceDashCrmOnGetChartLikidResponse>> Handle(FinanceDashCrmOnGetChartLikidQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.LikiditeRiskTrendView = new DashYearlyResultChart();
        request.InitialModel.LikiditeRiskTrend = dashLikiditeRiskTrendManager.LikiditeRiskTrend21Final(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID);
        request.InitialModel.LikiditeRiskTrendView.SetResult(request.InitialModel.LikiditeRiskTrend, request.InitialModel.CurrentUser.SelectedYear);

        return Task.FromResult(GenericResult<FinanceDashCrmOnGetChartLikidResponse>.Success(new FinanceDashCrmOnGetChartLikidResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.LikiditeRiskTrendView.nresult, request.Request.options))
        }));

    }
}
