using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashBilancoKon;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashBilancoKon;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashBilancoKon.Query.DashBilancoKonOnGet;
public class MizanDashBilancoKonOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashBilancoKonOnGetQuery, GenericResult<MizanDashBilancoKonOnGetResponse>>
{
  
    public Task<GenericResult<MizanDashBilancoKonOnGetResponse>> Handle(MizanDashBilancoKonOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashBilancoKonRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };
   
        responseModel.CompID =responseModel. mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
            hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();

            responseModel.myearResult = YearResult.getValue();

            return Task.FromResult(GenericResult<MizanDashBilancoKonOnGetResponse>.Success(
                new MizanDashBilancoKonOnGetResponse
                {
                    InitialModel = responseModel
                }));
    }
}

