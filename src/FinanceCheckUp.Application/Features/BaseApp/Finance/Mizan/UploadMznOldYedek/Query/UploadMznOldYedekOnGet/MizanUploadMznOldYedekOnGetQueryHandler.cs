using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznOldYedek.Query.UploadMznOldYedekOnGet
{
    public class MizanUploadMznOldYedekOnGetQueryHandler(
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager, 
        ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUploadMznOldYedekOnGetQuery, GenericResult<MizanUploadMznOldYedekOnGetResponse>>
    {
        public Task<GenericResult<MizanUploadMznOldYedekOnGetResponse>> Handle(MizanUploadMznOldYedekOnGetQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUploadMznOldYedekRequestInitialModel
            {  
                UserID = userId,
                myearResult = YearResult.getValue()
            };

            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
            responseModel.CurrentCom = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
            responseModel.currentcompname = responseModel.CurrentCom.CompanyName;
            responseModel.CompName = responseModel.CurrentCom.CompanyName;
            responseModel.curcomID = responseModel.CurrentCom.Id;
            responseModel.curcomCount = responseModel.mreqListCompany.Count();
            responseModel.Nacenum = 80;
            if (!string.IsNullOrEmpty(responseModel.CurrentCom.NaceCode) && !string.IsNullOrWhiteSpace(responseModel.CurrentCom.NaceCode) && responseModel.CurrentCom.NaceCode.Substring(0, 2) == "41")
            {
                responseModel.Nacenum = 15;
            }
            responseModel.CompID = responseModel.CurrentCom.Id;
            responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();
            
            return Task.FromResult(GenericResult<MizanUploadMznOldYedekOnGetResponse>.Success(new MizanUploadMznOldYedekOnGetResponse
            {
                InitialModel = responseModel
            }));

        }
    }
}
