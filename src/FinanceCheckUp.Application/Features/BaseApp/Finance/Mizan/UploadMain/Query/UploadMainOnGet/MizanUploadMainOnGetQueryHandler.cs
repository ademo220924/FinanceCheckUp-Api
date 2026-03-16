using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMain;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMain.Query.UploadMainOnGet
{
    public class MizanUploadMainOnGetQueryHandler(
        IReportSetMainSqlOperationManager setMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager, 
        ICompanyManager companyManager, 
        ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUploadMainOnGetQuery, GenericResult<MizanUploadMainOnGetResponse>>
    {
        public Task<GenericResult<MizanUploadMainOnGetResponse>> Handle(MizanUploadMainOnGetQuery request, CancellationToken cancellationToken)
        { 
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUploadMainRequestInitialModel
            {  
                UserID = userId
            }; 
            
           responseModel.myearResult = YearResult.getValue();
           responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
           responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
           responseModel.currenCompanie = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
           responseModel.currentcompname = responseModel.currenCompanie.CompanyName;
           responseModel.curcomID = responseModel.currenCompanie.Id;
           responseModel.currentUploadM = setMainSqlOperationManager.Get_StatbyCompanyExcel(responseModel.curcomID);
           responseModel.currentUploadYear = responseModel.currentUploadM.Select(x => x.MainYear).ToList();
           responseModel.currentUploadYear.Sort();
           responseModel.CompName = responseModel.currenCompanie.CompanyName;
           responseModel.curcomCount = responseModel.mreqListCompany.Count();

            responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();


            responseModel.curcomID = companyManager.Getby_User(responseModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            return Task.FromResult(GenericResult<MizanUploadMainOnGetResponse>.Success(new MizanUploadMainOnGetResponse
            {
                InitialModel = responseModel
            }));
        }
    }
}
