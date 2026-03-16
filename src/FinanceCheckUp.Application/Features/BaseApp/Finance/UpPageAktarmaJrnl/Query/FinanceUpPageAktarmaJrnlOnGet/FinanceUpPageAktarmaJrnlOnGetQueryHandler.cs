using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaJrnl.Query.FinanceUpPageAktarmaJrnlOnGet;

public class FinanceUpPageAktarmaJrnlOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager,
    ITBLXmlManager tBLXmlManager)
    : IRequestHandler<FinanceUpPageAktarmaJrnlOnGetQuery, GenericResult<FinanceUpPageAktarmaJrnlOnGetResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaJrnlOnGetResponse>> Handle(FinanceUpPageAktarmaJrnlOnGetQuery request,
        CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceUpPageAktarmaJrnlRequestInitialModel
        {
            UserID = userId,
            myearResult = YearResult.getValue(),
            mDcResult = DebitCreditResult.getValue()
        };

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
        responseModel.CurrentCom = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.currentcompname = responseModel.CurrentCom.CompanyName;
        responseModel.curcomID = responseModel.CurrentCom.Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        responseModel.Nacenum = 80;
        if (!string.IsNullOrEmpty(responseModel.CurrentCom.NaceCode) &&
            !string.IsNullOrWhiteSpace(responseModel.CurrentCom.NaceCode) &&
            responseModel.CurrentCom.NaceCode.Substring(0, 2) == "41")
        {
            responseModel.Nacenum = 15;
        }

        responseModel.CompID = responseModel.CurrentCom.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        return Task.FromResult(GenericResult<FinanceUpPageAktarmaJrnlOnGetResponse>.Success(
            new FinanceUpPageAktarmaJrnlOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}