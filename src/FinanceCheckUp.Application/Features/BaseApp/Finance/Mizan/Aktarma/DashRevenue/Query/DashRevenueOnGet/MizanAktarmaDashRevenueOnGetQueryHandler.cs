using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashRevenue;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashRevenue;
using FinanceCheckUp.Application.Models;


namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashRevenue.Query.DashRevenueOnGet;

public class MizanAktarmaDashRevenueOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBlXmlManager) : IRequestHandler<MizanAktarmaDashRevenueOnGetQuery, GenericResult<MizanAktarmaDashRevenueOnGetResponse>>
{
    
    public Task<GenericResult<MizanAktarmaDashRevenueOnGetResponse>> Handle(MizanAktarmaDashRevenueOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanAktarmaDashRevenueRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };
 
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBlXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();
        responseModel.nRequestListChk = responseModel.nRequestList;
        
        return Task.FromResult(GenericResult<MizanAktarmaDashRevenueOnGetResponse>.Success(
            new MizanAktarmaDashRevenueOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
