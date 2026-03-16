using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.CashFlow;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.CashFlow;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.CashFlow.Query.CashFlowOnGet;
public class MizanCashFlowOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanCashFlowOnGetQuery, GenericResult<MizanCashFlowOnGetResponse>>
{
     
    public Task<GenericResult<MizanCashFlowOnGetResponse>> Handle(MizanCashFlowOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanCashFlowRequestInitialModel
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
        var Yearlist = tBLXmlManager.GetYearList(responseModel.CompID);
        foreach (var item in Yearlist)
        {
            tBLXmlManager.setCashFlow(responseModel.CompID, item);
        }
        responseModel.myearResult = YearResult.getValue();
        
        

        return Task.FromResult(GenericResult<MizanCashFlowOnGetResponse>.Success(new MizanCashFlowOnGetResponse { InitialModel = responseModel }));
    }
}
