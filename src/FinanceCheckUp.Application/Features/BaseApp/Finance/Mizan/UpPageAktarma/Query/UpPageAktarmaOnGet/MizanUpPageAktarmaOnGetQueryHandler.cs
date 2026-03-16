using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpPageAktarma.Query.UpPageAktarmaOnGet
{
    public class MizanUpPageAktarmaOnGetQueryHandler(
        IHhvnUsersManager hhvnUsersManager, 
        ICompanyManager companyManager, 
        ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUpPageAktarmaOnGetQuery, GenericResult<MizanUpPageAktarmaOnGetResponse>>
    {
        public Task<GenericResult<MizanUpPageAktarmaOnGetResponse>> Handle(MizanUpPageAktarmaOnGetQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUpPageAktarmaRequestInitialModel
            {  
                UserID = userId,
                myearResult = YearResult.getValue()
            };
            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
            responseModel.CurrentCom = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
            responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
            responseModel.currentcompname = responseModel.CurrentCom.CompanyName;
            responseModel.curcomID = responseModel.CurrentCom.Id;
            responseModel.curcomCount = responseModel.mreqListCompany.Count();
            responseModel.Nacenum = 80;
            
            if (!string.IsNullOrEmpty(responseModel.CurrentCom.NaceCode) && !string.IsNullOrWhiteSpace(responseModel.CurrentCom.NaceCode) && responseModel.CurrentCom.NaceCode[..2] == "41")
            {
                responseModel.Nacenum = 15;
            }
            responseModel.CompID = responseModel.CurrentCom.Id;
            responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();
            
            return Task.FromResult(GenericResult<MizanUpPageAktarmaOnGetResponse>.Success(new MizanUpPageAktarmaOnGetResponse
            {
                InitialModel = responseModel
            }));
        }
    }
}
