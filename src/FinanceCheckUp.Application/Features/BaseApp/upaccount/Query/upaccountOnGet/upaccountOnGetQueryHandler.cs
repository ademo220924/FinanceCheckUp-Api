using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.upaccount;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGet;
public class upaccountOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<upaccountOnGetQuery, GenericResult<upaccountOnGetResponse>>
{

    public async Task<GenericResult<upaccountOnGetResponse>> Handle(upaccountOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new upaccountRequest
        {
            UserID = UserID,
            myearResult = YearResult.getValue()
        };

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.slctompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.currentcompname = responseModel.slctompany.CompanyName;
        responseModel.CompName = responseModel.slctompany.CompanyName;
        responseModel.curcomID = responseModel.slctompany.Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        responseModel.YearCurrent = responseModel.CurrentUser.SelectedYear;
        responseModel.CompID = responseModel.slctompany.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        return GenericResult<upaccountOnGetResponse>.Success(new upaccountOnGetResponse { InitialModel = responseModel });
    }
}