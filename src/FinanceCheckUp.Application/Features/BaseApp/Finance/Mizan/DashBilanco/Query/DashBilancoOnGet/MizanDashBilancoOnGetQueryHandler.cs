using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilanco;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Common.Utilities;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilanco.Query.DashBilancoOnGet;
public class MizanDashBilancoOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashBilancoOnGetQuery, GenericResult<MizanDashBilancoOnGetResponse>>
{

    public Task<GenericResult<MizanDashBilancoOnGetResponse>> Handle(MizanDashBilancoOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashBilancoRequestInitialModel
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

        responseModel.CompNameNorm = PageHelper.ClearTurkishCharacter(responseModel.CompName);
        responseModel.nRequestListChk = responseModel.nRequestList;
        
        return Task.FromResult(GenericResult<MizanDashBilancoOnGetResponse>.Success(
            new MizanDashBilancoOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
