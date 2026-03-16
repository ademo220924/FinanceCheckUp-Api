using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRevenue;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRevenue.Query.DashRevenueOnGet;
public class MizanDashRevenueOnGetQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashRevenueOnGetQuery, GenericResult<MizanDashRevenueOnGetResponse>>
{
    public Task<GenericResult<MizanDashRevenueOnGetResponse>> Handle(MizanDashRevenueOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashRevenueRequestInitialMopdel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };

        responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);

         responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
         responseModel.CompName =responseModel. mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        responseModel.myearResult = YearResult.getValue();

        responseModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULTMultiMain(responseModel.CompID);
        

        responseModel.CompNameNorm = PageHelper.ClearTurkishCharacter(responseModel.CompName);

        responseModel.nRequestListChk = responseModel.nRequestList;

        
        return Task.FromResult(GenericResult<MizanDashRevenueOnGetResponse>.Success(
            new MizanDashRevenueOnGetResponse
            {
                InitialModel = responseModel
            }));
        
    }
}
