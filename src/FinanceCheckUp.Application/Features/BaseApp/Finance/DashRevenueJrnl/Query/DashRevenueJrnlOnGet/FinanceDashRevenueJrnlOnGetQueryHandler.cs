using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.DashRevenueJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRevenueJrnl.Query.DashRevenueJrnlOnGet;
public class FinanceDashRevenueJrnlOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceDashRevenueJrnlOnGetQuery, GenericResult<FinanceDashRevenueJrnlOnGetResponse>>
{
    public Task<GenericResult<FinanceDashRevenueJrnlOnGetResponse>> Handle(FinanceDashRevenueJrnlOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashRevenueJrnlRequestInitialModel
        {
            UserID = userId
        };
        responseModel.mreqListCompany = companiesManager.Getby_User(userId);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, userId);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();
        responseModel.nRequestListChk = responseModel.nRequestList;

        return Task.FromResult(GenericResult<FinanceDashRevenueJrnlOnGetResponse>.Success(new FinanceDashRevenueJrnlOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
