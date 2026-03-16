using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetailc;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailc;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailc.Query.DashCrmDetailcOnGet;
public class DashCrmDetailcOnGetQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    ITBLXmlManager tBLXmlManager) : IRequestHandler<DashCrmDetailcOnGetQuery, GenericResult<DashCrmDetailcOnGetResponse>>
{

    public async Task<GenericResult<DashCrmDetailcOnGetResponse>> Handle(DashCrmDetailcOnGetQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashCrmDetailcRequest
        {
            UserID = UserID,
            mreqListCompany = companyManager.Getby_User(UserID)
        };

        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        responseModel.myearResult = YearResult.getValue();
        return GenericResult<DashCrmDetailcOnGetResponse>.Success(new DashCrmDetailcOnGetResponse { InitialModel = responseModel });

    }
}