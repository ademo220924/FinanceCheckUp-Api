using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.UpBalance;
using FinanceCheckUp.Application.Models.Responses.Finance.UpBalance;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGet;
public class FinanceUpBalanceOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager, 
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceUpBalanceOnGetQuery, GenericResult<FinanceUpBalanceOnGetResponse>>
{
    public Task<GenericResult<FinanceUpBalanceOnGetResponse>> Handle(FinanceUpBalanceOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceUpBalanceRequestInitialModel
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
        //currentUpload = UploadMain.Get_Data(DateTime.Now.Year, curcomID);
        responseModel.YearCurrent = responseModel.CurrentUser.SelectedYear;
        responseModel.CompID = responseModel.curCompany.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        
        return Task.FromResult(GenericResult<FinanceUpBalanceOnGetResponse>.Success(new FinanceUpBalanceOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
