using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashBilanco.Query.AktarmaDashBilancoOnGet;
public class AktarmaDashBilancoOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companiesManager,
    ICompanyManager companyManager,
    ITBLXmlManager tBlXmlManager) : IRequestHandler<AktarmaDashBilancoOnGetQuery, GenericResult<AktarmaDashBilancoOnGetResponse>>
{
    

    public Task<GenericResult<AktarmaDashBilancoOnGetResponse>> Handle(AktarmaDashBilancoOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new AktarmaDashBilancoInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };



        // var UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        responseModel.mreqListCompany = companiesManager.Getby_User(userId);
        //var mreqListCompany = Companies.Getby_User(UserID);

        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault()!.Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;




        hhvnUsersManager.SetYearMain(responseModel.CompID, userId);
        // HhvnUsers.SetYearMain(CompID, UserID);




        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        responseModel.YearCount = tBlXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.ToList().Count;
        var yearCountAktarma = companiesManager.GetCompanyAktarma(responseModel.CompID);
        responseModel.myearResult = YearResult.getValue().Where(x => yearCountAktarma.Contains(x.MYear));

        var selectedYear = responseModel.myearResult.Count() > 0 ? responseModel.myearResult.ToList()[0].MYear : 0;
        responseModel.SelectedYear = selectedYear;
        
        
        
        return Task.FromResult(GenericResult<AktarmaDashBilancoOnGetResponse>.Success(new AktarmaDashBilancoOnGetResponse { InitialModel = responseModel }));



    }

   
}
