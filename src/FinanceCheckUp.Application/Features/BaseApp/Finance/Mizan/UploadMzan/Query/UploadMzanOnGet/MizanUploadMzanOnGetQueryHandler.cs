using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzan.Query.UploadMzanOnGet
{
    public class MizanUploadMzanOnGetQueryHandler(
        IReportSetMainSqlOperationManager setMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager, 
        ICompanyManager companyManager, 
        ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUploadMzanOnGetQuery, GenericResult<MizanUploadMzanOnGetResponse>>
    {
        
        public Task<GenericResult<MizanUploadMzanOnGetResponse>> Handle(MizanUploadMzanOnGetQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUploadMzanRequestInitialModel
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
            responseModel.currentUploadYear.Sort();
            responseModel.CompName = responseModel.currenCompanie.CompanyName;
            responseModel.curcomCount = responseModel.mreqListCompany.Count(); 
            responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();
            responseModel.curcomID = companyManager.Getby_User(responseModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            
            return Task.FromResult(GenericResult<MizanUploadMzanOnGetResponse>.Success(new MizanUploadMzanOnGetResponse
            {
                InitialModel = responseModel
            }));

        }
    }
}
