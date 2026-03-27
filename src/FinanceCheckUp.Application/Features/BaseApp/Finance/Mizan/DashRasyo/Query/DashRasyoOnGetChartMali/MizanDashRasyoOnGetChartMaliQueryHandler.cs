using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRasyo.Query.DashRasyoOnGetChartMali;
public class MizanDashRasyoOnGetChartMaliQueryHandler(IDashOzetMaliMizanManager dashOzetMaliMizanManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager) : IRequestHandler<MizanDashRasyoOnGetChartMaliQuery, GenericResult<MizanDashRasyoOnGetChartMaliResponse>>
{
    public Task<GenericResult<MizanDashRasyoOnGetChartMaliResponse>> Handle(MizanDashRasyoOnGetChartMaliQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashRasyoRequestInitialModel
        {
            UserID = userId
        }; 
        
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.CompID = companyManager.Getby_User(responseModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.OzetMaliView = new DashYearlyResultMizan();
        responseModel.OzetMali = dashOzetMaliMizanManager.OzetMaliFinal(responseModel.CompID);

                return Task.FromResult(GenericResult<MizanDashRasyoOnGetChartMaliResponse>.Success(
            new MizanDashRasyoOnGetChartMaliResponse
            {
                Response = DataSourceLoader.Load(responseModel.OzetMali, request.Request.options)
            }));
    }
}
