using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGet;

public class MizanUpPageAktarmaJrnlOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUpPageAktarmaJrnlOnGetQuery, GenericResult<MizanUpPageAktarmaJrnlOnGetResponse>>
{
   
    public Task<GenericResult<MizanUpPageAktarmaJrnlOnGetResponse>> Handle(MizanUpPageAktarmaJrnlOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
        var responseModel = new MizanUpPageAktarmaJrnlRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        }; 
        
        
        responseModel.myearResult = YearResult.getValue();
        responseModel.mDcResult = DebitCreditResult.getValue();
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID); 
        responseModel.CurrentCom = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.currentcompname = responseModel.CurrentCom.CompanyName;
        responseModel.curcomID = responseModel.CurrentCom.Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        //currentUpload = UploadMain.Get_Data(DateTime.Now.Year, curcomID);
        responseModel.Nacenum = 80;
        if (!string.IsNullOrEmpty(responseModel.CurrentCom.NaceCode) && !string.IsNullOrWhiteSpace(responseModel.CurrentCom.NaceCode) && responseModel.CurrentCom.NaceCode.Substring(0, 2) == "41")
        {
            responseModel.Nacenum = 15;
        }
        responseModel.CompID = responseModel.CurrentCom.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        
        return Task.FromResult(GenericResult<MizanUpPageAktarmaJrnlOnGetResponse>.Success(
            new MizanUpPageAktarmaJrnlOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}

