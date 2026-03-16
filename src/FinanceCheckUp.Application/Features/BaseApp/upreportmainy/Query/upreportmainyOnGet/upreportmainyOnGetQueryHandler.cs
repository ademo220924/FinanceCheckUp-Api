using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.upreportmainy;
using FinanceCheckUp.Application.Models.Responses.upreportmainy;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportmainy.Query.upreportmainyOnGet;
public class upreportmainyOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager, IMainDashManager mainDashManager, IUploadMainManager uploadMainManager) : IRequestHandler<upreportmainyOnGetQuery, GenericResult<upreportmainyOnGetResponse>>
{

    public async Task<GenericResult<upreportmainyOnGetResponse>> Handle(upreportmainyOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new upreportmainyRequest
        {
            UserID = UserID,
            myearResult = YearResult.getValue()
        };


        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.curCompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.currentcompname = responseModel.curCompany.CompanyName;
        responseModel.curcomID = responseModel.curCompany.Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        //currentUpload = UploadMain.Get_Data(DateTime.Now.Year, curcomID);

        responseModel.CompID = responseModel.curCompany.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        return GenericResult<upreportmainyOnGetResponse>.Success(new upreportmainyOnGetResponse { InitialModel = responseModel });
    }
}