using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGet
{
    public class MizanUpBalanceNewOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager,  ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUpBalanceNewOnGetQuery, GenericResult<MizanUpBalanceNewOnGetResponse>>
    { 
        public Task<GenericResult<MizanUpBalanceNewOnGetResponse>> Handle(MizanUpBalanceNewOnGetQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUpBalanceNewRequestInitialModel
            {  
                UserID = userId,
                myearResult = YearResult.getValue()
            }; 

            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
            responseModel.curCompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
            responseModel.currentcompname = responseModel.curCompany.CompanyName;
            responseModel.CompName = responseModel.curCompany.CompanyName;
            responseModel.curcomID = responseModel.curCompany.Id;
            responseModel.curcomCount = responseModel.mreqListCompany.Count();
            responseModel.YearCurrent = responseModel.CurrentUser.SelectedYear;
            responseModel.CompID = responseModel.curCompany.Id;
            responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();
            
            return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetResponse>.Success(new MizanUpBalanceNewOnGetResponse
            {
                InitialModel = responseModel
            }));

        }
    }
}
