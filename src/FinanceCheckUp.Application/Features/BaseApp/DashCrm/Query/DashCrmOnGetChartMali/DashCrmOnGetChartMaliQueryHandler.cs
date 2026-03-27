using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartMali;
public class DashCrmOnGetChartMaliQueryHandler(
     IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager,
    IDashOzetMaliManager dashOzetMaliManager) : IRequestHandler<DashCrmOnGetChartMaliQuery, GenericResult<DashCrmOnGetChartMaliResponse>>
{

    public async Task<GenericResult<DashCrmOnGetChartMaliResponse>> Handle(DashCrmOnGetChartMaliQuery request, CancellationToken cancellationToken)
    {


        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        request.Request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialModel.OzetMaliView = new DashYearlyResultChart();
        request.Request.InitialModel.OzetMali = dashOzetMaliManager.OzetMaliFinal(request.Request.InitialModel.CurrentUser.SelectedYear, request.Request.InitialModel.CompID);
        request.Request.InitialModel.OzetMaliView.SetResult(request.Request.InitialModel.OzetMali, request.Request.InitialModel.CurrentUser.SelectedYear);

                return GenericResult<DashCrmOnGetChartMaliResponse>.Success(new DashCrmOnGetChartMaliResponse { Response = DataSourceLoader.Load(request.Request.InitialModel.OzetMaliView.nresult, request.Request.Options) });
    }
}