using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtFiba;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtFiba;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtFiba.Query.FinanceHrtFibaOnGet;
public class MizanFinanceHrtFibaOnGetQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager,   ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanFinanceHrtFibaOnGetQuery, GenericResult<MizanFinanceHrtFibaOnGetResponse>>
{
    
    public Task<GenericResult<MizanFinanceHrtFibaOnGetResponse>> Handle(MizanFinanceHrtFibaOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanFinanceHrtFibaRequestInitialModel
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

        dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTCheckFiba(responseModel.CompID); 
        
        return Task.FromResult(GenericResult<MizanFinanceHrtFibaOnGetResponse>.Success(
            new MizanFinanceHrtFibaOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}

