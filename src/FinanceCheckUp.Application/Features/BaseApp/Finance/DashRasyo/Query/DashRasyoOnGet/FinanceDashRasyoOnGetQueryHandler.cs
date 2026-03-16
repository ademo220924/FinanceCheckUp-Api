using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRasyo.Query.DashRasyoOnGet;
public class FinanceDashRasyoOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceDashRasyoOnGetQuery, GenericResult<FinanceDashRasyoOnGetResponse>>
{
    public Task<GenericResult<FinanceDashRasyoOnGetResponse>> Handle(FinanceDashRasyoOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashRasyoRequestInitialModel
        {
            UserID = userId
        };
        responseModel.myearResult = YearResult.getValue();
        responseModel.RasyoAnalizView = new DashYearlyResultChart();
        responseModel.OzetMaliView = new DashYearlyResultChart();
        responseModel.LikiditeRiskTrendView = new DashYearlyResultChart();
        responseModel.mreqListCompany = companiesManager.Getby_User(userId);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, userId);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        return Task.FromResult(GenericResult<FinanceDashRasyoOnGetResponse>.Success(new FinanceDashRasyoOnGetResponse
        {
            InitialModel = responseModel
        }));

    }
}
