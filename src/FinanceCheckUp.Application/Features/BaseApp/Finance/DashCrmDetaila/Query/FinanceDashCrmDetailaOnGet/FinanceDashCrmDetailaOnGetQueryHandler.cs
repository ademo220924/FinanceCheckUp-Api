using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetaila;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetaila;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetaila.Query.FinanceDashCrmDetailaOnGet;
public class FinanceDashCrmDetailaOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager,  
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceDashCrmDetailaOnGetQuery, GenericResult<FinanceDashCrmDetailaOnGetResponse>>
{
    public Task<GenericResult<FinanceDashCrmDetailaOnGetResponse>> Handle(FinanceDashCrmDetailaOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashCrmDetailaRequestInitialModel
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

        return Task.FromResult(GenericResult<FinanceDashCrmDetailaOnGetResponse>.Success(new FinanceDashCrmDetailaOnGetResponse
        {
            InitialModel = responseModel
        }));

    }
}
