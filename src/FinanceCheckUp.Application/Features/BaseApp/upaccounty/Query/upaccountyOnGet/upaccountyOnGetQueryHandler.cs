using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.upaccounty;
using FinanceCheckUp.Application.Models.Responses.upaccounty;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGet;
public class upaccountyOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager, IMainDashManager mainDashManager) : IRequestHandler<upaccountyOnGetQuery, GenericResult<upaccountyOnGetResponse>>
{

    public async Task<GenericResult<upaccountyOnGetResponse>> Handle(upaccountyOnGetQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new upaccountyRequest
        {
            UserID = UserID,
            myearResult = YearResult.getValue()
        };

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.currentcompname = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.curcomID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.currentUploadError = mainDashManager.Get_DatabyError(responseModel.CurrentUser.SelectedYear, responseModel.curcomID);
        responseModel.TotalRowCount = responseModel.currentUploadError.Sum(x => x.TRowCount) > 0 ? responseModel.currentUploadError.Sum(x => x.TRowCount).ToString("N0") : "0";
        responseModel.TotalErrorCount = responseModel.currentUploadError.Sum(x => x.TRowCount) > 0 ? responseModel.currentUploadError.Sum(x => x.TErrorRowCount).ToString("N0") : "0";
        return GenericResult<upaccountyOnGetResponse>.Success(new upaccountyOnGetResponse { InitialModel = responseModel });

    }
}