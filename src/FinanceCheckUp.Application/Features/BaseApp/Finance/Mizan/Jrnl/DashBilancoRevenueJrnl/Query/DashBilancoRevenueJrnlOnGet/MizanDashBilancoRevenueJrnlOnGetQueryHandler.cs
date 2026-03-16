using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl.Query.DashBilancoRevenueJrnlOnGet;
public class MizanDashBilancoRevenueJrnlOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashBilancoRevenueJrnlOnGetQuery, GenericResult<MizanDashBilancoRevenueJrnlOnGetResponse>>
{
   
    public Task<GenericResult<MizanDashBilancoRevenueJrnlOnGetResponse>> Handle(MizanDashBilancoRevenueJrnlOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
        var responseModel = new MizanDashBilancoRevenueJrnlRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        }; 

        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        responseModel.myearResult = YearResult.getValue(); 
        responseModel.nRequestListChk = responseModel.nRequestList;
         
        return Task.FromResult(GenericResult<MizanDashBilancoRevenueJrnlOnGetResponse>.Success(
            new MizanDashBilancoRevenueJrnlOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
