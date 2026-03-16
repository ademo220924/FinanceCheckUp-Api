using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Common.Utilities;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinancesHrtfibapr.Query.FinancesHrtfibaprOnGet;
public class MizanFinancesHrtfibaprOnGetQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanFinancesHrtfibaprOnGetQuery, GenericResult<MizanFinancesHrtfibaprOnGetResponse>>
{
 

    public Task<GenericResult<MizanFinancesHrtfibaprOnGetResponse>> Handle(MizanFinancesHrtfibaprOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
        var responseModel = new MizanFinancesHrtfibaprRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        }; 
         
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyIDMizan(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.CompNameNorm = PageHelper.ClearTurkishCharacter(responseModel.CompName);
        responseModel.myearResult = YearResult.getValue();

        dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTCheckFibaPr(responseModel.CompID);
       
        return Task.FromResult(GenericResult<MizanFinancesHrtfibaprOnGetResponse>.Success(
            new MizanFinancesHrtfibaprOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
