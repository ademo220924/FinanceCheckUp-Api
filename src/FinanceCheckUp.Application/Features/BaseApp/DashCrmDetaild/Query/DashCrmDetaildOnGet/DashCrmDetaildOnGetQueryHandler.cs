using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetaild;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaild;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaild.Query.DashCrmDetaildOnGet;
public class DashCrmDetaildOnGetQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    ITBLXmlManager tBLXmlManager) : IRequestHandler<DashCrmDetaildOnGetQuery, GenericResult<DashCrmDetaildOnGetResponse>>
{

    public async Task<GenericResult<DashCrmDetaildOnGetResponse>> Handle(DashCrmDetaildOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashCrmDetaildRequest
        {
            UserID = UserID,
            mreqListCompany = companyManager.Getby_User(UserID)
        };

        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();

        return GenericResult<DashCrmDetaildOnGetResponse>.Success(new DashCrmDetaildOnGetResponse { InitialModel = responseModel });

    }
}