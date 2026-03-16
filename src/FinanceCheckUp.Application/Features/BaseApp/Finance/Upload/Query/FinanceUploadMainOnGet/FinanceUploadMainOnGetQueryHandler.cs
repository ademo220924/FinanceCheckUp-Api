using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Upload;
using FinanceCheckUp.Application.Models.Responses.Finance.Upload;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Upload.Query.FinanceUploadMainOnGet;
public class FinanceUploadMainOnGetQueryHandler(
    IMainDashManager mainDashManager,
    IUploadMainManager uploadMainManager,
    IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceUploadMainOnGetQuery, GenericResult<FinanceUploadMainOnGetResponse>>
{
    public Task<GenericResult<FinanceUploadMainOnGetResponse>> Handle(FinanceUploadMainOnGetQuery request, CancellationToken cancellationToken)
    { 
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceUploadMainRequestInitialModel
        {  
            UserID = userId,
            myearResult = YearResult.getValue(),
            mmonthResult = YearResult.getValuemonth(),
            mSourceResult = SourceResult.getValue()
        };


        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        if (responseModel.CurrentUser.Id != 9)
        {
            responseModel.mSourceResult = SourceResult.getValueNom();
        }
        responseModel.mreqListCompany = companyManager.Getby_User((int)responseModel.UserID);
        responseModel.currenCompanie = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.currentcompname = responseModel.currenCompanie.CompanyName;
        responseModel.curcomID = responseModel.currenCompanie.Id;
        responseModel.CompName = responseModel.currenCompanie.CompanyName;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
         
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();


        responseModel.curcomID = companyManager.Getby_User(responseModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        int chkErrormonthIDChk = mainDashManager.Get_DatabyError(responseModel.CurrentUser.SelectedYear, responseModel.curcomID).Count();
        List<int> chkErrormonthID = mainDashManager.Get_DatabyError(responseModel.CurrentUser.SelectedYear, responseModel.curcomID).Where(x => x.TRowCount == 0).Select(x => x.MainMonth).ToList();
        responseModel.currentUploadM = uploadMainManager.Get_Data(responseModel.CurrentUser.SelectedYear, responseModel.curcomID).OrderBy(x => x.MainMonth);
        if (chkErrormonthIDChk < 1)
        {
            responseModel.currentUploadM.Select(c => { c.ErrorCount = -1; return c; }).OrderBy(x => x.MainMonth).ToList();
        }
        else
        {
            responseModel.currentUploadM.Where(x => chkErrormonthID.Contains(x.MainMonth)).Select(c => { c.ErrorCount = -1; return c; }).OrderBy(x => x.MainMonth).ToList();
        }

        responseModel.currentUploadMOK = responseModel.currentUploadM.Where(x => x.ErrorCount > -1);
        responseModel.currentUploadMNoOK = responseModel.currentUploadM.Where(x => x.ErrorCount < 0);
        responseModel.currentMonth = responseModel.currentUploadMNoOK.FirstOrDefault();
        responseModel.currentUploadMMonth = new List<YearlyUploadResult>();
        if (responseModel.currentMonth != null)
        {
            responseModel.currentUploadMNoOK = responseModel.currentUploadMNoOK.Except(responseModel.currentUploadMMonth);
            responseModel.currentUploadMMonth.Add(responseModel.currentMonth);
        }
        
        
        return Task.FromResult(GenericResult<FinanceUploadMainOnGetResponse>.Success(new FinanceUploadMainOnGetResponse
        {
            InitialModel = responseModel
        }));

    }
}
