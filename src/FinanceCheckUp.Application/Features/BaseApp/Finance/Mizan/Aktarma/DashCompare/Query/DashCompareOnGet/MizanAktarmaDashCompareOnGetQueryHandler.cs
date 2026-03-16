using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashCompare;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashCompare;
using FinanceCheckUp.Application.Models;


namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashCompare.Query.DashCompareOnGet;

public class MizanAktarmaDashCompareOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanAktarmaDashCompareOnGetQuery, GenericResult<MizanAktarmaDashCompareOnGetResponse>>
{
    public Task<GenericResult<MizanAktarmaDashCompareOnGetResponse>> Handle(MizanAktarmaDashCompareOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanAktarmaDashCompareRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };

        responseModel.nnyear = request.Request.nyear;
        responseModel.nMonth = request.Request.nmonth;
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();
        
        return Task.FromResult(GenericResult<MizanAktarmaDashCompareOnGetResponse>.Success(
            new MizanAktarmaDashCompareOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}