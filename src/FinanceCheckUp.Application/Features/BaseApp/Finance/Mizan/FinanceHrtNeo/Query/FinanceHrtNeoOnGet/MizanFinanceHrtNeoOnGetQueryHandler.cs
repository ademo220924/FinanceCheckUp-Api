using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtNeo;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtNeo;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtNeo.Query.FinanceHrtNeoOnGet;
public class MizanFinanceHrtNeoOnGetQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanFinanceHrtNeoOnGetQuery, GenericResult<MizanFinanceHrtNeoOnGetResponse>>
{
    
    public Task<GenericResult<MizanFinanceHrtNeoOnGetResponse>> Handle(MizanFinanceHrtNeoOnGetQuery request, CancellationToken cancellationToken)
    {
        
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanFinanceHrtNeoRequestInitialModel
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

        dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTCheck(responseModel.CompID); 
        
        
        return Task.FromResult(GenericResult<MizanFinanceHrtNeoOnGetResponse>.Success(
            new MizanFinanceHrtNeoOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
