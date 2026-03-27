using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetChartRasyob;
public class FinanceDashCrmOnGetChartRasyobQueryHandler(IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    IRasyoAnalizMainManager rasyoAnalizMainManager) : IRequestHandler<FinanceDashCrmOnGetChartRasyobQuery, GenericResult<FinanceDashCrmOnGetChartRasyobResponse>>
{
    public Task<GenericResult<FinanceDashCrmOnGetChartRasyobResponse>> Handle(FinanceDashCrmOnGetChartRasyobQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.RasyoAnalizViewCrm = new DashYearlyResultChartCRM();
        request.InitialModel.RasyoAnalizCRM = rasyoAnalizMainManager.CRMAnalizTOTAL120(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID);
        request.InitialModel.RasyoAnalizViewCrm.SetResult(request.InitialModel.RasyoAnalizCRM, request.InitialModel.CurrentUser.SelectedYear);

                return Task.FromResult(GenericResult<FinanceDashCrmOnGetChartRasyobResponse>.Success(new FinanceDashCrmOnGetChartRasyobResponse
        {
            Response = DataSourceLoader.Load(request.InitialModel.RasyoAnalizViewCrm.nresult.OrderByDescending(z => z.Value), request.Request.options)
        }));

    }
}
