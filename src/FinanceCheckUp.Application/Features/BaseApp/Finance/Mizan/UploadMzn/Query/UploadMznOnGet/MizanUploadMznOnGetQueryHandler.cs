using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzn;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzn.Query.UploadMznOnGet
{
    public class MizanUploadMznOnGetQueryHandler(
        IReportSetMainSqlOperationManager setMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager,  
        ICompanyManager companyManager, 
        ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUploadMznOnGetQuery, GenericResult<MizanUploadMznOnGetResponse>>
    {
       
        public Task<GenericResult<MizanUploadMznOnGetResponse>> Handle(MizanUploadMznOnGetQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUploadMznRequestInitialModel
            {  
                UserID = userId,
                myearResult = YearResult.getValue()
            };

            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
            responseModel.currenCompanie = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
            responseModel.currentcompname = responseModel.currenCompanie.CompanyName;
            responseModel.curcomID = responseModel.currenCompanie.Id;
            responseModel.currentUploadM = setMainSqlOperationManager.Get_StatbyCompanyExcel(responseModel.curcomID);
            responseModel.currentUploadYear = responseModel.currentUploadM.Select(x => x.MainYear).ToList();
            responseModel.CompName = responseModel.currenCompanie.CompanyName;
            responseModel.curcomCount = responseModel.mreqListCompany.Count();
            responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();
            responseModel.curcomID = companyManager.Getby_User(responseModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            
            return Task.FromResult(GenericResult<MizanUploadMznOnGetResponse>.Success(new MizanUploadMznOnGetResponse
            {
                InitialModel = responseModel
            }));
        }
    }
}
