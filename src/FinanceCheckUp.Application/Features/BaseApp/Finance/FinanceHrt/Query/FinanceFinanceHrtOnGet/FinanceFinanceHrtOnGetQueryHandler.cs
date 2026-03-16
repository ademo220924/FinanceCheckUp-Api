using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrt;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrt.Query.FinanceFinanceHrtOnGet;
public class FinanceFinanceHrtOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    ITBLXmlManager tBLXmlManager, 
    IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtOnGetQuery, GenericResult<FinanceFinanceHrtOnGetResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtOnGetResponse>> Handle(FinanceFinanceHrtOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceFinanceHrtRequestInitialModel
        {
            UserID = userId
        };

        responseModel.mreqListCompany = companiesManager.Getby_User(userId);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, userId);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();
        dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTCheck(responseModel.CompID);

        return Task.FromResult(GenericResult<FinanceFinanceHrtOnGetResponse>.Success(new FinanceFinanceHrtOnGetResponse
        {
            InitialModel = responseModel
        }));

    }
}
