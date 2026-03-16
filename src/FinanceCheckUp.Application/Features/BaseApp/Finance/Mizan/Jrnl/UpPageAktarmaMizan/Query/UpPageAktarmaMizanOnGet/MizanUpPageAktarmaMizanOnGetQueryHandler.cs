using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaMizan.Query.UpPageAktarmaMizanOnGet;

public class MizanUpPageAktarmaMizanOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager,  ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUpPageAktarmaMizanOnGetQuery, GenericResult<MizanUpPageAktarmaMizanOnGetResponse>>
{
    
    public Task<GenericResult<MizanUpPageAktarmaMizanOnGetResponse>> Handle(MizanUpPageAktarmaMizanOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
        var responseModel = new MizanUpPageAktarmaMizanRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        }; 
        
        
        responseModel.myearResult = YearResult.getValue();



        
        responseModel. CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel. CurrentCom = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel. CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel. currentcompname = responseModel.CurrentCom.CompanyName;
        responseModel. curcomID = responseModel.CurrentCom.Id;
        responseModel. curcomCount = responseModel.mreqListCompany.Count();
        //currentUpload = UploadMain.Get_Data(DateTime.Now.Year, curcomID);
        responseModel.Nacenum = 80;
        if (!string.IsNullOrEmpty(responseModel.CurrentCom.NaceCode) && !string.IsNullOrWhiteSpace(responseModel.CurrentCom.NaceCode) && responseModel.CurrentCom.NaceCode.Substring(0, 2) == "41")
        {
            responseModel.Nacenum = 15;
        }
        responseModel.CompID = responseModel.CurrentCom.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        
        return Task.FromResult(GenericResult<MizanUpPageAktarmaMizanOnGetResponse>.Success(
            new MizanUpPageAktarmaMizanOnGetResponse
            { 
                InitialModel =responseModel
            }));
    }
}


