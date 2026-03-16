using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashCrm;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashCrm.Query.DashCrmOnGet;
public class MizanDashCrmOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) 
    : IRequestHandler<MizanDashCrmOnGetQuery, GenericResult<MizanDashCrmOnGetResponse>>
{
    
    public Task<GenericResult<MizanDashCrmOnGetResponse>> Handle(MizanDashCrmOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashCrmRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };

        
        responseModel.myearResult = YearResult.getValue();
        responseModel.RasyoAnalizView = new DashYearlyResultChart();
        responseModel.OzetMaliView = new DashYearlyResultChart();
        responseModel.LikiditeRiskTrendView = new DashYearlyResultChart();
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        
        return Task.FromResult(GenericResult<MizanDashCrmOnGetResponse>.Success(
            new MizanDashCrmOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
