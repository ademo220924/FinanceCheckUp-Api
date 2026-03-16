using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetaila;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaila;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGet;
public class DashCrmDetailaOnGetQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    ITBLXmlManager tBLXmlManager) : IRequestHandler<DashCrmDetailaOnGetQuery, GenericResult<DashCrmDetailaOnGetResponse>>
{

    public async Task<GenericResult<DashCrmDetailaOnGetResponse>> Handle(DashCrmDetailaOnGetQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashCrmDetailaRequest
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

        return GenericResult<DashCrmDetailaOnGetResponse>.Success(new DashCrmDetailaOnGetResponse { InitialModel = responseModel });
    }
}