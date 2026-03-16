using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpReportMain.Query.UpReportMainOnGet
{
    public class MizanUpReportMainOnGetQueryHandler(
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager, 
        ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUpReportMainOnGetQuery, GenericResult<MizanUpReportMainOnGetResponse>>
    {
        
        public Task<GenericResult<MizanUpReportMainOnGetResponse>> Handle(MizanUpReportMainOnGetQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUpReportMainRequestInitialModel
            {  
                UserID = userId,
                myearResult = YearResult.getValue()
            };

            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
            responseModel.curCompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
            responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
            responseModel.currentcompname = responseModel.curCompany.CompanyName;
            responseModel.curcomID = responseModel.curCompany.Id;
            responseModel.curcomCount = responseModel.mreqListCompany.Count(); 
            responseModel.CompID = responseModel.curCompany.Id;
            responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();
            
            return Task.FromResult(GenericResult<MizanUpReportMainOnGetResponse>.Success(new MizanUpReportMainOnGetResponse
            {
                InitialModel = responseModel
            }));
        }
    }
}
