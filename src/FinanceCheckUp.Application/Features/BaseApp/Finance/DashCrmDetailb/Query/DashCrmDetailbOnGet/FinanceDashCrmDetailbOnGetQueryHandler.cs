using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetailb;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetailb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetailb.Query.DashCrmDetailbOnGet;
public class FinanceDashCrmDetailbOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager,  
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceDashCrmDetailbOnGetQuery, GenericResult<FinanceDashCrmDetailbOnGetResponse>>
{
    public Task<GenericResult<FinanceDashCrmDetailbOnGetResponse>> Handle(FinanceDashCrmDetailbOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashCrmDetailbRequestInitialModel
        {
            UserID = (int)userId
        };

        responseModel.mreqListCompany = companiesManager.Getby_User(userId);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, userId);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();

        return Task.FromResult(GenericResult<FinanceDashCrmDetailbOnGetResponse>.Success(new FinanceDashCrmDetailbOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
