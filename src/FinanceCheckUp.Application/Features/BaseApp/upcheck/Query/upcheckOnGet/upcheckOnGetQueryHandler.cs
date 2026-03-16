using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.upcheck;
using FinanceCheckUp.Application.Models.Responses.upcheck;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGet;
public class upcheckOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager, IMainDashManager mainDashManager) : IRequestHandler<upcheckOnGetQuery, GenericResult<upcheckOnGetResponse>>
{

    public async Task<GenericResult<upcheckOnGetResponse>> Handle(upcheckOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new upcheckRequest
        {
            UserID = UserID,
            myearResult = YearResult.getValue()
        };

        responseModel.myearResult = YearResult.getValue();
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.currentcompname = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.curcomID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.YearCurrent = responseModel.CurrentUser.SelectedYear;
        return GenericResult<upcheckOnGetResponse>.Success(new upcheckOnGetResponse { InitialModel = responseModel });
    }
}