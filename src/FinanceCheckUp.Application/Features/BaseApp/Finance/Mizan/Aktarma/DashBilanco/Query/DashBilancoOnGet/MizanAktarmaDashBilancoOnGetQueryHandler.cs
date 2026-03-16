using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashBilanco.Query.DashBilancoOnGet;

public class MizanAktarmaDashBilancoOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanAktarmaDashBilancoOnGetQuery, GenericResult<MizanAktarmaDashBilancoOnGetResponse>>
{

    public Task<GenericResult<MizanAktarmaDashBilancoOnGetResponse>> Handle(MizanAktarmaDashBilancoOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanAktarmaDashBilancoRequestInitialModel
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
        
        return Task.FromResult(GenericResult<MizanAktarmaDashBilancoOnGetResponse>.Success(
            new MizanAktarmaDashBilancoOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}