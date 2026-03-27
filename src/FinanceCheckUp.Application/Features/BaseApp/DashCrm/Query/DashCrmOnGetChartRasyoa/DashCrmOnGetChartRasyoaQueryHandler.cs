using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartRasyoa;
public class DashCrmOnGetChartRasyoaQueryHandler(
     IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager,
    IRasyoAnalizMainManager rasyoAnalizMainManager) : IRequestHandler<DashCrmOnGetChartRasyoaQuery, GenericResult<DashCrmOnGetChartRasyoaResponse>>
{

    public async Task<GenericResult<DashCrmOnGetChartRasyoaResponse>> Handle(DashCrmOnGetChartRasyoaQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt64(request.UserId);
        request.Request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);

        request.Request.InitialModel.CompID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.Request.InitialModel.RasyoAnalizViewCrm = new DashYearlyResultChartCRM();
        request.Request.InitialModel.RasyoAnalizCRM = rasyoAnalizMainManager.CRMAnalizTOTAL103(request.Request.InitialModel.CurrentUser.SelectedYear, request.Request.InitialModel.CompID);
        request.Request.InitialModel.RasyoAnalizViewCrm.SetResult(request.Request.InitialModel.RasyoAnalizCRM, request.Request.InitialModel.CurrentUser.SelectedYear);

                return GenericResult<DashCrmOnGetChartRasyoaResponse>.Success(new DashCrmOnGetChartRasyoaResponse { Response = DataSourceLoader.Load(request.Request.InitialModel.RasyoAnalizViewCrm.nresult.OrderByDescending(z => z.Value), request.Request.Options) });
    }
}