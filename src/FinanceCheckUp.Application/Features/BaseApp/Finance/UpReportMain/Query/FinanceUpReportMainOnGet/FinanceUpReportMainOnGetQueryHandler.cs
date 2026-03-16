using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.UpReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpReportMain.Query.FinanceUpReportMainOnGet;

public class FinanceUpReportMainOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager,
    ITBLXmlManager tBLXmlManager)
    : IRequestHandler<FinanceUpReportMainOnGetQuery, GenericResult<FinanceUpReportMainOnGetResponse>>
{
    public Task<GenericResult<FinanceUpReportMainOnGetResponse>> Handle(FinanceUpReportMainOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceUpReportMainRequestInitialModel
        {
            UserID = userId,
            myearResult = YearResult.getValue()
        };

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
        responseModel.curCompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.currentcompname = responseModel.curCompany.CompanyName;
        responseModel.curcomID = responseModel.curCompany.Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        responseModel.CompID = responseModel.curCompany.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.YearCurrent = responseModel.CurrentUser.SelectedYear;
        
        return Task.FromResult(GenericResult<FinanceUpReportMainOnGetResponse>.Success(
            new FinanceUpReportMainOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}