using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtHor;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtHor;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGet;
public class FinanceFinanceHrtHorOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    ITBLXmlManager tBLXmlManager, 
    IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtHorOnGetQuery, GenericResult<FinanceFinanceHrtHorOnGetResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtHorOnGetResponse>> Handle(FinanceFinanceHrtHorOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceFinanceHrtHorRequestInitialModel
        {
            UserID = userId
        };
        var mreqListCompany = companiesManager.Getby_User(userId);
        var CompID = mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var CompName = mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(CompID, userId);
        var CurrentUser = hhvnUsersManager.GetRow_User(userId);
        var YearCount = tBLXmlManager.GetYearByComapnyID(CompID);
        var CompCount = mreqListCompany.Count();
        var myearResult = YearResult.getValue();
        dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTCheck(CompID);

        return Task.FromResult(GenericResult<FinanceFinanceHrtHorOnGetResponse>.Success(new FinanceFinanceHrtHorOnGetResponse
        {
            InitialModel = responseModel
        }));

    }
}
