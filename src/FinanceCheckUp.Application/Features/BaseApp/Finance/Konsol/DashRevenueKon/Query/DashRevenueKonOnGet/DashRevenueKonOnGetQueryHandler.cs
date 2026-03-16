using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashRevenueKon;
using FinanceCheckUp.Application.Models.Requests.Finance.Konsol.DashRevenueKon;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Konsol.DashRevenueKon.Query.DashRevenueKonOnGet;
public class DashRevenueKonOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, ICompanyManager companyManager, ITBLXmlManager tBlXmlManager) : IRequestHandler<DashRevenueKonOnGetQuery, GenericResult<DashRevenueKonOnGetResponse>>
{
    public Task<GenericResult<DashRevenueKonOnGetResponse>> Handle(DashRevenueKonOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new DashRevenueKonInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };
            
        responseModel.mreqListCompany = companiesManager.Getby_User(responseModel.UserID);
        responseModel.CompID = responseModel.mreqListCompany.FirstOrDefault(x => x.IsDefault == 1).Id;
        responseModel.CompName = responseModel.mreqListCompany.FirstOrDefault(x => x.IsDefault == 1).CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBlXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();
        responseModel.nRequestListChk = responseModel.nRequestList;
        
        return Task.FromResult(GenericResult<DashRevenueKonOnGetResponse>.Success(new DashRevenueKonOnGetResponse { InitialModel = responseModel }));
    }
}
