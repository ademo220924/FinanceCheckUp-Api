using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.DashBilancoJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.DashBilancoJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashBilancoJrnl.Query.FinanceDashBilancoJrnlOnGet;
public class FinanceDashBilancoJrnlOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager,  
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceDashBilancoJrnlOnGetQuery, GenericResult<FinanceDashBilancoJrnlOnGetResponse>>
{
    public Task<GenericResult<FinanceDashBilancoJrnlOnGetResponse>> Handle(FinanceDashBilancoJrnlOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashBilancoJrnlRequestInitialModel
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

        return Task.FromResult(GenericResult<FinanceDashBilancoJrnlOnGetResponse>.Success(new FinanceDashBilancoJrnlOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
