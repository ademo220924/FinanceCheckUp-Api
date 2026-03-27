using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRasyo.Query.DashRasyoOnGetChartRasyob;
public class FinanceDashRasyoOnGetChartRasyobQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    IRasyoAnalizMainManager rasyoAnalizMainManager) : IRequestHandler<FinanceDashRasyoOnGetChartRasyobQuery, GenericResult<FinanceDashRasyoOnGetChartRasyobResponse>>
{
    public Task<GenericResult<FinanceDashRasyoOnGetChartRasyobResponse>> Handle(FinanceDashRasyoOnGetChartRasyobQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.RasyoAnalizView = new DashYearlyResultChart();
        request.InitialModel.RasyoAnaliz = rasyoAnalizMainManager.RasyoAnalizTOTALFinal(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID);
        request.InitialModel.RasyoAnalizView.SetResult(request.InitialModel.RasyoAnaliz, request.InitialModel.CurrentUser.SelectedYear);

                return Task.FromResult(GenericResult<FinanceDashRasyoOnGetChartRasyobResponse>.Success(new FinanceDashRasyoOnGetChartRasyobResponse
        {
            Response = DataSourceLoader.Load(request.InitialModel.RasyoAnalizView.nresult.Where(x => x.TypeID == 3), request.Request.options)
        }));

    }
}