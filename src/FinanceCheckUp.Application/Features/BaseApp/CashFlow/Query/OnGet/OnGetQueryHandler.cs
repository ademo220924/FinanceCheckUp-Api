using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.CashFlow;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.OnGet;
public class OnGetQueryHandle(
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companiesManager,
        ITBLXmlManager tBLXmlManager) : IRequestHandler<OnGetQuery, GenericResult<OnGetResponseModel>>
{
    public async Task<GenericResult<OnGetResponseModel>> Handle(OnGetQuery request, CancellationToken cancellationToken)
    {

        long userId = long.Parse(request.UserId);

        var mreqListCompany = companiesManager.Getby_User(userId);
        var compID = mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault()!.Id;
        var compName = mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault()!.CompanyName;
        hhvnUsersManager.SetYearMain(compID, userId);
        var currentUser = hhvnUsersManager.GetRow_User(userId);
        var yearCount = tBLXmlManager.GetYearByComapnyID(compID);
        var compCount = mreqListCompany.Count();
        var yearlist = tBLXmlManager.GetYearList(compID);
        foreach (var item in yearlist)
        {
            tBLXmlManager.setCashFlow(compID, item);
        }
        var myearResult = YearResult.getValue();

        return GenericResult<OnGetResponseModel>.Success(new OnGetResponseModel
        {
            CashFlowRequestInit = new CashFlowRequestModel
            {
                UserID = (int)userId,
                mreqListCompany = mreqListCompany,
                myearResult = myearResult,
                CompName = compName,
                CurrentUser = currentUser,
                YearCount = yearCount,
                CompCount = compCount,
                CompID = compID
            }
        });

    }
}
