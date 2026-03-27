using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetChartMali;
public class DashRasyoOnGetChartMaliQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    IDashOzetMaliManager dashOzetMaliManager) : IRequestHandler<DashRasyoOnGetChartMaliQuery, GenericResult<DashRasyoOnGetChartMaliResponse>>
{

    public async Task<GenericResult<DashRasyoOnGetChartMaliResponse>> Handle(DashRasyoOnGetChartMaliQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialMode.CurrentUser = hhvnUsersManager.GetRow_User(UserID);

        request.Request.InitialMode.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialMode.OzetMaliView = new DashYearlyResultChart();
        request.Request.InitialMode.OzetMali = dashOzetMaliManager.OzetMaliFinal(request.Request.InitialMode.CurrentUser.SelectedYear, request.Request.InitialMode.CompID);
        request.Request.InitialMode.OzetMaliView.SetResult(request.Request.InitialMode.OzetMali, request.Request.InitialMode.CurrentUser.SelectedYear);

                return GenericResult<DashRasyoOnGetChartMaliResponse>.Success(new DashRasyoOnGetChartMaliResponse { Response = DataSourceLoader.Load(request.Request.InitialMode.OzetMaliView.nresult, request.Request.Options) });

    }
}