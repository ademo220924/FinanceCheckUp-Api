using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRasyo.Query.DashRasyoOnGet;
public class MizanDashRasyoOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager,  ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashRasyoOnGetQuery, GenericResult<MizanDashRasyoOnGetResponse>>
{

    public Task<GenericResult<MizanDashRasyoOnGetResponse>> Handle(MizanDashRasyoOnGetQuery request, CancellationToken cancellationToken)
    {
        
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashRasyoRequestInitialModel
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
        
        return Task.FromResult(GenericResult<MizanDashRasyoOnGetResponse>.Success(
            new MizanDashRasyoOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
