using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGet;
public class DashRasyoOnGetQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    ITBLXmlManager tBLXmlManager) : IRequestHandler<DashRasyoOnGetQuery, GenericResult<DashRasyoOnGetResponse>>
{

    public async Task<GenericResult<DashRasyoOnGetResponse>> Handle(DashRasyoOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashRasyoRequest
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

        return GenericResult<DashRasyoOnGetResponse>.Success(new DashRasyoOnGetResponse { InitialModel = responseModel });
    }
}