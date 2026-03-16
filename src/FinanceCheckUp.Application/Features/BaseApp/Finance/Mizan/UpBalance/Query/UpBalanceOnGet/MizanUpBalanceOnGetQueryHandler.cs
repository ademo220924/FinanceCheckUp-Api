using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalance;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalance.Query.UpBalanceOnGet
{
    public class MizanUpBalanceOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUpBalanceOnGetQuery, GenericResult<MizanUpBalanceOnGetResponse>>
    {
         
        public Task<GenericResult<MizanUpBalanceOnGetResponse>> Handle(MizanUpBalanceOnGetQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUpBalanceRequestInitialModel
            {  
                UserID = userId
            }; 
            
            responseModel.myearResult = YearResult.getValue();
            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
            responseModel.currentcompname = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
            responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
            responseModel.curcomID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            responseModel.curcomCount = responseModel.mreqListCompany.Count();
            responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();
            
            return Task.FromResult(GenericResult<MizanUpBalanceOnGetResponse>.Success(new MizanUpBalanceOnGetResponse
            {
                 InitialModel = responseModel
            }));
            
        }
    }
}
