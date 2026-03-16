using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.upbalance;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGet;
public class upbalanceOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<upbalanceOnGetQuery, GenericResult<upbalanceOnGetResponse>>
{

    public async Task<GenericResult<upbalanceOnGetResponse>> Handle(upbalanceOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new upbalanceRequest
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
        responseModel.//currentUpload = UploadMain.Get_Data(DateTime.Now.Year, curcomID);
        YearCurrent = responseModel.CurrentUser.SelectedYear;
        responseModel.CompID = responseModel.curCompany.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        return GenericResult<upbalanceOnGetResponse>.Success(new upbalanceOnGetResponse { InitialModel = responseModel });
    }
}