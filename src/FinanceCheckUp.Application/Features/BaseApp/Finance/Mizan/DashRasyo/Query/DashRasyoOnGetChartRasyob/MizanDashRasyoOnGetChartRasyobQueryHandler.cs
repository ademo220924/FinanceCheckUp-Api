using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRasyo.Query.DashRasyoOnGetChartRasyob;
public class MizanDashRasyoOnGetChartRasyobQueryHandler(IRasyoAnalizMainMizanManager rasyoAnalizMainMizanManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager) : IRequestHandler<MizanDashRasyoOnGetChartRasyobQuery, GenericResult<MizanDashRasyoOnGetChartRasyobResponse>>
{
  
    public Task<GenericResult<MizanDashRasyoOnGetChartRasyobResponse>> Handle(MizanDashRasyoOnGetChartRasyobQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashRasyoRequestInitialModel
        {
            UserID = userId
        }; 
        
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.CompID = companiesManager.Getby_User(responseModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.RasyoAnalizView = new DashYearlyResultMizan();
        responseModel.RasyoAnaliz = rasyoAnalizMainMizanManager.RasyoAnalizTOTALFinal(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
                
        return Task.FromResult(GenericResult<MizanDashRasyoOnGetChartRasyobResponse>.Success(
            new MizanDashRasyoOnGetChartRasyobResponse
            {
                Response = DataSourceLoader.Load(responseModel.RasyoAnaliz.Where(x => x.TypeID == 3), request.Request.options)
            }));
    }
}
