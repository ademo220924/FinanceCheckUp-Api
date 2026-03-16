using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.CashFlow;
using FinanceCheckUp.Application.Models.Requests.Finance.CashFlow;
using MediatR;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.CashFlow.Query.FinanceCashFlowOnGet;

public class FinanceCashFlowOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceCashFlowOnGetQuery, GenericResult<FinanceCashFlowOnGetResponse>>
{
    public Task<GenericResult<FinanceCashFlowOnGetResponse>> Handle(FinanceCashFlowOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceCashFlowRequestInitialModel
        {
            UserID = userId
        };

        responseModel.mreqListCompany = companiesManager.Getby_User(responseModel.UserID);
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

        return Task.FromResult(GenericResult<FinanceCashFlowOnGetResponse>.Success(new FinanceCashFlowOnGetResponse
        {
            InitialModel = responseModel,
        }));
    }
}