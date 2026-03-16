using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGetChartMali;
public class DashCpmNewOnGetChartMaliQueryHandler(
     IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager,
    IDashOzetMaliManager dashOzetMaliManager) : IRequestHandler<DashCpmNewOnGetChartMaliQuery, GenericResult<DashCpmNewOnGetChartMaliResponse>>
{

    public async Task<GenericResult<DashCpmNewOnGetChartMaliResponse>> Handle(DashCpmNewOnGetChartMaliQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        request.Request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialModel.OzetMaliView = new DashYearlyResultChart();
        request.Request.InitialModel.OzetMali = dashOzetMaliManager.OzetMaliFinal(request.Request.InitialModel.CurrentUser.SelectedYear, request.Request.InitialModel.CompID);
        request.Request.InitialModel.OzetMaliView.SetResult(request.Request.InitialModel.OzetMali, request.Request.InitialModel.CurrentUser.SelectedYear);
        return GenericResult<DashCpmNewOnGetChartMaliResponse>.Success(new DashCpmNewOnGetChartMaliResponse { Response = new JsonResult(DataSourceLoader.Load(request.Request.InitialModel.OzetMaliView.nresult, request.Request.Options)) });
    }
}