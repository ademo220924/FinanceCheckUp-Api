using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRasyo.Query.DashRasyoOnGetChartLikid;
public class MizanDashRasyoOnGetChartLikidQueryHandler(IDashLikiditeRiskTrendMizanManager dashLikiditeRiskTrendMizanManager,IHhvnUsersManager hhvnUsersManager,  ICompanyManager companyManager) : IRequestHandler<MizanDashRasyoOnGetChartLikidQuery, GenericResult<MizanDashRasyoOnGetChartLikidResponse>>
{
  
    public Task<GenericResult<MizanDashRasyoOnGetChartLikidResponse>> Handle(MizanDashRasyoOnGetChartLikidQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashRasyoRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        }; 
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.CompID = companyManager.Getby_User(responseModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.LikiditeRiskTrendView = new DashYearlyResultMizan();
        responseModel.LikiditeRiskTrend = dashLikiditeRiskTrendMizanManager.LikiditeRiskTrend21Final(responseModel.CompID);

                return Task.FromResult(GenericResult<MizanDashRasyoOnGetChartLikidResponse>.Success(
            new MizanDashRasyoOnGetChartLikidResponse
            {
                Response = DataSourceLoader.Load(responseModel.LikiditeRiskTrend, request.Request.options)
            })); 
    }
}