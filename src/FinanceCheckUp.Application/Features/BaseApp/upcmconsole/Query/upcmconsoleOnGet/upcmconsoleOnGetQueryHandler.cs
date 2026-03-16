using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.upcmconsole;
using FinanceCheckUp.Application.Models.Responses.upcmconsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGet;
public class upcmconsoleOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager, IMainDashManager mainDashManager) : IRequestHandler<UpcmconsoleOnGetQuery, GenericResult<upcmconsoleOnGetResponse>>
{

    public async Task<GenericResult<upcmconsoleOnGetResponse>> Handle(UpcmconsoleOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new upcmconsoleRequest
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
        return GenericResult<upcmconsoleOnGetResponse>.Success(new upcmconsoleOnGetResponse { InitialModel = responseModel });

    }
}