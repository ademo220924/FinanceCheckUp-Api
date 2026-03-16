using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashCrm;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGet;
public class DashCrmOnGetQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    ITBLXmlManager tBLXmlManager) : IRequestHandler<DashCrmOnGetQuery, GenericResult<DashCrmOnGetResponse>>
{

    public async Task<GenericResult<DashCrmOnGetResponse>> Handle(DashCrmOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashCrmRequest
        {
            UserID = UserID,
            myearResult = YearResult.getValue(),
            RasyoAnalizView = new DashYearlyResultChart(),
            OzetMaliView = new DashYearlyResultChart(),
            LikiditeRiskTrendView = new DashYearlyResultChart(),
            mreqListCompany = companyManager.Getby_User(UserID)
        };

        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        return GenericResult<DashCrmOnGetResponse>.Success(new DashCrmOnGetResponse { InitialModel = responseModel });
    }
}