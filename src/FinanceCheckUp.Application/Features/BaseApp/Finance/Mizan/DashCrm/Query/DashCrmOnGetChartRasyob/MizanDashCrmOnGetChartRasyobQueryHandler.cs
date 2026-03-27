using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashCrm;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashCrm;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashCrm.Query.DashCrmOnGetChartRasyob;
public class MizanDashCrmOnGetChartRasyobQueryHandler(IRasyoAnalizMainManager rasyoAnalizMainManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashCrmOnGetChartRasyobQuery, GenericResult<MizanDashCrmOnGetChartRasyobResponse>>
{
 

    public Task<GenericResult<MizanDashCrmOnGetChartRasyobResponse>> Handle(MizanDashCrmOnGetChartRasyobQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.CompID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.RasyoAnalizViewCrm = new DashYearlyResultChartCRM();
        request.InitialModel.RasyoAnalizCRM = rasyoAnalizMainManager.CRMAnalizTOTAL120Mizan(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID);
        request.InitialModel.RasyoAnalizViewCrm.SetResult(request.InitialModel.RasyoAnalizCRM, request.InitialModel.CurrentUser.SelectedYear);
 
                return Task.FromResult(GenericResult<MizanDashCrmOnGetChartRasyobResponse>.Success(
            new MizanDashCrmOnGetChartRasyobResponse
            {
                Response = DataSourceLoader.Load(request.InitialModel.RasyoAnalizViewCrm.nresult.OrderByDescending(z => z.Value), request.Request.options),
                InitialModel = request.InitialModel
            }));
    }
}
