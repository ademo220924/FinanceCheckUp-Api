using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaild;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaild.Query.DashCrmDetaildOnGetChartRasyo;
public class DashCrmDetaildOnGetChartRasyoQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    IRasyoAnalizMainManager rasyoAnalizMainManager) : IRequestHandler<DashCrmDetaildOnGetChartRasyoQuery, GenericResult<DashCrmDetaildOnGetChartRasyoResponse>>
{

    public async Task<GenericResult<DashCrmDetaildOnGetChartRasyoResponse>> Handle(DashCrmDetaildOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        request.Request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialModel.RasyoAnalizViewCrm = new DashYearlyResultChartCRM();
        request.Request.InitialModel.RasyoAnalizCRM = rasyoAnalizMainManager.CRMAnalizTOTAL320T(request.Request.InitialModel.CurrentUser.SelectedYear, request.Request.InitialModel.CompID);
        request.Request.InitialModel.RasyoAnalizViewCrm.SetResult(request.Request.InitialModel.RasyoAnalizCRM, request.Request.InitialModel.CurrentUser.SelectedYear);

                return GenericResult<DashCrmDetaildOnGetChartRasyoResponse>.Success(new DashCrmDetaildOnGetChartRasyoResponse { Response = DataSourceLoader.Load(request.Request.InitialModel.RasyoAnalizViewCrm.nresult.OrderByDescending(z => z.Value), request.Request.Options) });
    }
}