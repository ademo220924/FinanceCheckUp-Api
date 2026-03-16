using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetail;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetail;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetail.Query.DashCrmDetailOnGet;
public class FinanceDashCrmDetailOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager,  
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceDashCrmDetailOnGetQuery, GenericResult<FinanceDashCrmDetailOnGetResponse>>
{
    public Task<GenericResult<FinanceDashCrmDetailOnGetResponse>> Handle(FinanceDashCrmDetailOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashCrmDetailRequestInitialModel
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

        return Task.FromResult(GenericResult<FinanceDashCrmDetailOnGetResponse>.Success(new FinanceDashCrmDetailOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
