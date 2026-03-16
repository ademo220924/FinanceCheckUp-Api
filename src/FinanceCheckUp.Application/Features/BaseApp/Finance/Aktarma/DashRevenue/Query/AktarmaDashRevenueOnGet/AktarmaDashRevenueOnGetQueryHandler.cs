using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashRevenue.Query.AktarmaDashRevenueOnGet;
public class AktarmaDashRevenueOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager,  ICompanyManager companyManager, ITBLXmlManager tBlXmlManager) 
    : IRequestHandler<AktarmaDashRevenueOnGetQuery, GenericResult<AktarmaDashRevenueOnGetResponse>>
{
    
    public Task<GenericResult<AktarmaDashRevenueOnGetResponse>> Handle(AktarmaDashRevenueOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new AktarmaDashRevenueInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };


        responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBlXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();
        responseModel.nRequestListChk = responseModel.nRequestList;

        return Task.FromResult(GenericResult<AktarmaDashRevenueOnGetResponse>.Success(new AktarmaDashRevenueOnGetResponse { InitialModel = responseModel }));
    }
}
