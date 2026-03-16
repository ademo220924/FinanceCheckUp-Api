using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Requests.Finance.Konsol.DashBilancoKon;
using FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashBilancoKon;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Konsol.DashBilancoKon.Query.DashBilancoKonOnGet;
public class DashBilancoKonOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, ICompanyManager companyManager, ITBLXmlManager tBlXmlManager) 
    : IRequestHandler<DashBilancoKonOnGetQuery, GenericResult<DashBilancoKonOnGetResponse>>
{
  
    public Task<GenericResult<DashBilancoKonOnGetResponse>> Handle(DashBilancoKonOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new DashBilancoKonInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };

            
        responseModel.mreqListCompany = companiesManager.Getby_User(responseModel.UserID);

        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
            hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.YearCount = tBlXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();

            responseModel.myearResult = YearResult.getValue();
            return Task.FromResult(GenericResult<DashBilancoKonOnGetResponse>.Success(
                new DashBilancoKonOnGetResponse { InitialModel = responseModel }));

    }
}

