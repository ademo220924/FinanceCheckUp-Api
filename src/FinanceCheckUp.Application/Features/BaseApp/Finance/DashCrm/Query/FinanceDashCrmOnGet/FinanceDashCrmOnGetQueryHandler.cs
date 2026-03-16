using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrm;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGet;
public class FinanceDashCrmOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager,  
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceDashCrmOnGetQuery, GenericResult<FinanceDashCrmOnGetResponse>>
{
    public Task<GenericResult<FinanceDashCrmOnGetResponse>> Handle(FinanceDashCrmOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashCrmRequestInitialModel
        {
            UserID = userId
        };

        responseModel.myearResult = YearResult.getValue();
        responseModel.RasyoAnalizView = new DashYearlyResultChart();
        responseModel.OzetMaliView = new DashYearlyResultChart();
        responseModel.LikiditeRiskTrendView = new DashYearlyResultChart();
        responseModel.mreqListCompany = companiesManager.Getby_User(responseModel.UserID);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        return Task.FromResult(GenericResult<FinanceDashCrmOnGetResponse>.Success(new FinanceDashCrmOnGetResponse
        {
            InitialModel = responseModel,
        }));
    }
}
