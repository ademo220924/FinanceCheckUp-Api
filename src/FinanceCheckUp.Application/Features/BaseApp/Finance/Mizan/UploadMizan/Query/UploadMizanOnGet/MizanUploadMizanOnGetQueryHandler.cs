using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMizan.Query.UploadMizanOnGet
{
    public class MizanUploadMizanOnGetQueryHandler(
        IUploadMainManager uploadMainManager,
        IMainDashManager mainDashManager,
        IMizanSqlOperationManager mizanSqlOperationManager ,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUploadMizanOnGetQuery, GenericResult<MizanUploadMizanOnGetResponse>>
    {
         
        public Task<GenericResult<MizanUploadMizanOnGetResponse>> Handle(MizanUploadMizanOnGetQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUploadMizanRequestInitialModel
            {  
                UserID = (int)userId,
                myearResult = YearResult.getValue()
            };


            var chkInt = new List<int>() { 3, 6, 9, 12 };
 
            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
            responseModel.currenCompanie = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
            responseModel.currentcompname = responseModel.currenCompanie.CompanyName;
            responseModel.curcomID = responseModel.currenCompanie.Id;
            responseModel.CompName = responseModel.currenCompanie.CompanyName;
            responseModel.curcomCount = responseModel.mreqListCompany.Count();
            responseModel.ncomparelist = mizanSqlOperationManager.GetMizanBeyanSame(responseModel.curcomID);
            if (responseModel.ncomparelist.Count() > 0)
            {
                responseModel.monthlist = responseModel.ncomparelist.Where(x => x.Year == responseModel.CurrentUser.SelectedYear).Select(y => y.MainMonth).ToList();
                responseModel.mnthcomparelist = String.Join(",", responseModel.monthlist.Select(i => i.ToString()).ToArray());
            }

            responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
            responseModel.CompCount = responseModel.mreqListCompany.Count();


            responseModel.curcomID = companyManager.Getby_User(responseModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            List<int> chkErrormonthIDChk = mainDashManager.Get_DatabyMOnthMizan(responseModel.CurrentUser.SelectedYear, responseModel.curcomID);
            responseModel.currentUploadM = uploadMainManager.Get_Data(responseModel.CurrentUser.SelectedYear, responseModel.curcomID).Where(x => chkInt.Contains(x.MainMonth)).OrderBy(x => x.MainMonth);
            if (chkErrormonthIDChk.Count() < 1)
            {
                responseModel.currentUploadM.Select(c => { c.ErrorCount = -1; return c; }).OrderBy(x => x.MainMonth).ToList();
            }
            else
            {
                responseModel.currentUploadM.Select(c => { c.ErrorCount = -1; return c; }).OrderBy(x => x.MainMonth).ToList();
                responseModel.currentUploadM.Where(x => chkErrormonthIDChk.Contains(x.MainMonth)).Select(c => { c.ErrorCount = 1; return c; }).OrderBy(x => x.MainMonth).ToList();
            }

            responseModel.currentUploadMOK = responseModel.currentUploadM.Where(x => x.ErrorCount > -1);
            responseModel.currentUploadMNoOK = responseModel.currentUploadM.Where(x => x.ErrorCount < 0);
            
            return Task.FromResult(GenericResult<MizanUploadMizanOnGetResponse>.Success(new MizanUploadMizanOnGetResponse
            {
                InitialModel = responseModel
            }));

        }
    }
}
