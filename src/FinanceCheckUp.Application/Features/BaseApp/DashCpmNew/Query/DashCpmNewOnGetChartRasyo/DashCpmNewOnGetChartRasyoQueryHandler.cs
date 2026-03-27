using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGetChartRasyo;
public class DashCpmNewOnGetChartRasyoQueryHandler(
     IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager,
    IRasyoAnalizMainManager rasyoAnalizMainManager) : IRequestHandler<DashCpmNewOnGetChartRasyoQuery, GenericResult<DashCpmNewOnGetChartRasyoResponse>>
{

    public async Task<GenericResult<DashCpmNewOnGetChartRasyoResponse>> Handle(DashCpmNewOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        request.Request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialModel.RasyoAnalizViewCrm = new DashYearlyResultChartCRM();
        request.Request.InitialModel.RasyoAnalizCRM = rasyoAnalizMainManager.CRMAnalizTOTAL102(request.Request.InitialModel.CurrentUser.SelectedYear, request.Request.InitialModel.CompID);
        request.Request.InitialModel.RasyoAnalizViewCrm.SetResult(request.Request.InitialModel.RasyoAnalizCRM, request.Request.InitialModel.CurrentUser.SelectedYear);
                return GenericResult<DashCpmNewOnGetChartRasyoResponse>.Success(new DashCpmNewOnGetChartRasyoResponse { Response = DataSourceLoader.Load(request.Request.InitialModel.RasyoAnalizViewCrm.nresult.OrderByDescending(z => z.Value), request.Request.Options) });
    }
}