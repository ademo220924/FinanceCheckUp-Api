using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetailc;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetailc;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetailc.Query.DashCrmDetailcOnGet;
public class FinanceDashCrmDetailcOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceDashCrmDetailcOnGetQuery, GenericResult<FinanceDashCrmDetailcOnGetResponse>>
{
    public Task<GenericResult<FinanceDashCrmDetailcOnGetResponse>> Handle(FinanceDashCrmDetailcOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashCrmDetailcRequestInitialModel
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

        return Task.FromResult(GenericResult<FinanceDashCrmDetailcOnGetResponse>.Success(new FinanceDashCrmDetailcOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
