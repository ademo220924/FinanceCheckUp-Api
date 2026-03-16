using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetailc;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetailc.Query.DashCrmDetailcOnGetChartRasyo;
public class FinanceDashCrmDetailcOnGetChartRasyoQueryHandler(IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    IRasyoAnalizMainManager rasyoAnalizMainManager) : IRequestHandler<FinanceDashCrmDetailcOnGetChartRasyoQuery, GenericResult<FinanceDashCrmDetailcOnGetChartRasyoResponse>>
{
    public Task<GenericResult<FinanceDashCrmDetailcOnGetChartRasyoResponse>> Handle(FinanceDashCrmDetailcOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.RasyoAnalizViewCrm = new DashYearlyResultChartCRM();
        request.InitialModel.RasyoAnalizCRM = rasyoAnalizMainManager.CRMAnalizTOTAL101T(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID);
        request.InitialModel.RasyoAnalizViewCrm.SetResult(request.InitialModel.RasyoAnalizCRM, request.InitialModel.CurrentUser.SelectedYear);

        return Task.FromResult(GenericResult<FinanceDashCrmDetailcOnGetChartRasyoResponse>.Success(new FinanceDashCrmDetailcOnGetChartRasyoResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.RasyoAnalizViewCrm.nresult.OrderByDescending(z => z.Value), request.Request.options))
        }));

    }
}
