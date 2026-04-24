using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRasyo.Query.DashRasyoOnGetChartRasyoa;
public class MizanDashRasyoOnGetChartRasyoaQueryHandler(IRasyoAnalizMainMizanManager rasyoAnalizMainMizanManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager) : IRequestHandler<MizanDashRasyoOnGetChartRasyoaQuery, GenericResult<MizanDashRasyoOnGetChartRasyoaResponse>>
{

    public Task<GenericResult<MizanDashRasyoOnGetChartRasyoaResponse>> Handle(MizanDashRasyoOnGetChartRasyoaQuery request, CancellationToken cancellationToken)
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

        return Task.FromResult(GenericResult<MizanDashRasyoOnGetChartRasyoaResponse>.Success(
            new MizanDashRasyoOnGetChartRasyoaResponse
            {
                Response = DataSourceLoader.Load(responseModel.RasyoAnaliz.Where(x => x.TypeID == 2), request.Request.options)
            }));
    }
}
