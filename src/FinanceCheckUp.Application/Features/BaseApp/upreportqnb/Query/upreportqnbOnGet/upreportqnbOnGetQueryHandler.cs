using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.upreportqnb;
using FinanceCheckUp.Application.Models.Responses.upreportqnb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGet;
public class upreportqnbOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager,
    ITBLXmlManager tBLXmlManager,
    INaceCodeManager naceCodeManager,
    ICompanyQnbReportManager companyQnbReportManager) : IRequestHandler<upreportqnbOnGetQuery, GenericResult<upreportqnbOnGetResponse>>
{

    public async Task<GenericResult<upreportqnbOnGetResponse>> Handle(upreportqnbOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new upreportqnbRequest
        {
            UserID = UserID,
            myearResult = YearResult.getValue()
        };


        responseModel.cNaceCodeUpload = naceCodeManager.Get_NaceCode();
        responseModel.YearCurrent = 2021;

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.curCompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.currentcompname = responseModel.curCompany.CompanyName;
        responseModel.YearCurrent = responseModel.CurrentUser.SelectedYear;
        responseModel.curcomID = responseModel.curCompany.Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        responseModel.CompID = responseModel.curCompany.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.reportList = companyQnbReportManager.Get_CompanyReportList(responseModel.curcomID).OrderByDescending(x => x.Id);

        return GenericResult<upreportqnbOnGetResponse>.Success(new upreportqnbOnGetResponse { InitialModel = responseModel });
    }
}