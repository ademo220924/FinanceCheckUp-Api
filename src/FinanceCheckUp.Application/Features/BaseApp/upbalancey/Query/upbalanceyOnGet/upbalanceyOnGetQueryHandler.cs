using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.upbalancey;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGet;
public class upbalanceyOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager, IMainDashManager mainDashManager) : IRequestHandler<upbalanceyOnGetQuery, GenericResult<upbalanceyOnGetResponse>>
{

    public async Task<GenericResult<upbalanceyOnGetResponse>> Handle(upbalanceyOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new upbalanceyRequest
        {
            UserID = UserID,
            myearResult = YearResult.getValue()
        };


        responseModel.myearResult = YearResult.getValue();
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.curCompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.currentcompname = responseModel.curCompany.CompanyName;
        responseModel.CompName = responseModel.curCompany.CompanyName;
        responseModel.curcomID = responseModel.curCompany.Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        responseModel.CompID = responseModel.curCompany.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        return GenericResult<upbalanceyOnGetResponse>.Success(new upbalanceyOnGetResponse { InitialModel = responseModel });
    }
}