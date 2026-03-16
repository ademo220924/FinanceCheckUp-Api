using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashRevenueJrnl;
using FinanceCheckUp.Application.Models.Responses.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGet;
public class DashRevenueJrnlOnGetQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    ITBLXmlManager tBLXmlManager) : IRequestHandler<DashRevenueJrnlOnGetQuery, GenericResult<DashRevenueJrnlOnGetResponse>>
{

    public async Task<GenericResult<DashRevenueJrnlOnGetResponse>> Handle(DashRevenueJrnlOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashRevenueJrnlRequest
        {
            UserID = UserID,
            mreqListCompany = companyManager.Getby_User(UserID)
        };




        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        responseModel.myearResult = YearResult.getValue();


        responseModel.nRequestListChk = responseModel.nRequestList;
        return GenericResult<DashRevenueJrnlOnGetResponse>.Success(new DashRevenueJrnlOnGetResponse { InitialModel = responseModel });
    }
}