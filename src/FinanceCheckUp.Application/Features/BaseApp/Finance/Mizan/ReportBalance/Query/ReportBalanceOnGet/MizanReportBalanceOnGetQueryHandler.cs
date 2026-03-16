using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportBalance;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportBalance.Query.ReportBalanceOnGet;
public class MizanReportBalanceOnGetQueryHandler(
    IReportMizanCheckManager reportMizanCheckManager,
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IMizanResultManager mizanResultManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<MizanReportBalanceOnGetQuery, GenericResult<MizanReportBalanceOnGetResponse>>
{
     
    public Task<GenericResult<MizanReportBalanceOnGetResponse>> Handle(MizanReportBalanceOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanReportBalanceRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };
        
         
        responseModel.CCompanies = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.CompID = responseModel.CCompanies.Id;
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.ncheck = reportSetMainSqlOperationManager.Get_ReportSetBilanco(request.Request.nyear, responseModel.CompID);
        responseModel.mainreporttext = reportMizanCheckManager.GetComapanyCumulativeMizan(request.Request.nyear, responseModel.CompID);
        responseModel.header = responseModel.CCompanies.CompanyName + " " + request.Request.nyear.ToString() + " Yılı Kümülatif Mizan Raporu";
        responseModel.ncheck1 = mizanResultManager.Get_MizanResult(request.Request.nyear, responseModel.CompID);
        responseModel.ncheck2 = mizanResultManager.Get_DonuChk(request.Request.nyear, responseModel.CompID);
        responseModel.ncheck3 = mizanResultManager.Get_TicariAlıcıMizan(request.Request.nyear, responseModel.CompID);
        responseModel.ncheck4 = mizanResultManager.Get_TicariBorcluMizan(request.Request.nyear, responseModel.CompID);
         
        
        return Task.FromResult(GenericResult<MizanReportBalanceOnGetResponse>.Success(
            new MizanReportBalanceOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
