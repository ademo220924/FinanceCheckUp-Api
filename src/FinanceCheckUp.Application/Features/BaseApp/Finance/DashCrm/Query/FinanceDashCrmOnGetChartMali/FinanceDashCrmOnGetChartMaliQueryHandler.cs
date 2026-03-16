using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetChartMali;
public class FinanceDashCrmOnGetChartMaliQueryHandler(IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    IDashOzetMaliManager dashOzetMaliManager) : IRequestHandler<FinanceDashCrmOnGetChartMaliQuery, GenericResult<FinanceDashCrmOnGetChartMaliResponse>>
{
    public Task<GenericResult<FinanceDashCrmOnGetChartMaliResponse>> Handle(FinanceDashCrmOnGetChartMaliQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.OzetMaliView = new DashYearlyResultChart();
        request.InitialModel.OzetMali = dashOzetMaliManager.OzetMaliFinal(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID);
        request.InitialModel.OzetMaliView.SetResult(request.InitialModel.OzetMali, request.InitialModel.CurrentUser.SelectedYear);

        return Task.FromResult(GenericResult<FinanceDashCrmOnGetChartMaliResponse>.Success(new FinanceDashCrmOnGetChartMaliResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.OzetMaliView.nresult, request.Request.options))
        }));

    }
}
