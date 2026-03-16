using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtView;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGet;
public class MizanFinanceHrtViewOnGetQueryHandler(IReportDashManager reportDashManager,IBultenManager bultenManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanFinanceHrtViewOnGetQuery, GenericResult<MizanFinanceHrtViewOnGetResponse>>
{
    
    public Task<GenericResult<MizanFinanceHrtViewOnGetResponse>> Handle(MizanFinanceHrtViewOnGetQuery request, CancellationToken cancellationToken)
    { 
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanFinanceHrtViewRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        }; 
        
        responseModel. mreqList = bultenManager.Get_BWarn();
        responseModel.myearResult = YearResult.getValue(); 
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID); 
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.dashRevenue = reportDashManager.Get_Data_GrossProfitMIZAN(responseModel.CompID).OrderByDescending(X => X.MainYear).Take(3);
        responseModel.dashGrossProfit = reportDashManager.Get_Data_BrutKarZararMIZAN(responseModel.CompID).OrderByDescending(X => X.MainYear).Take(3);
        responseModel.dashFinancialDebit = reportDashManager.Get_Data_BrutKarZararMIZAN(responseModel.CompID).OrderByDescending(X => X.MainYear).Take(3);
        responseModel.dashFinancialDebitMulti = reportDashManager.Get_Data_FinancialDebitMultiMIZAN(responseModel.CompID).OrderByDescending(X => X.MainYear);
        responseModel.dashFinancialCariOran = reportDashManager.Get_Data_FinancialCariOrANMIZAN(responseModel.CompID).OrderByDescending(X => X.MainYear).Take(3);
   
        if (responseModel.dashFinancialCariOran == null)
        {
            responseModel.dashFinancialCariOran = new List<YearlyReportDash>();

        }
        if (responseModel.dashFinancialDebitMulti == null)
        {
            responseModel.dashFinancialDebitMulti = new List<YearlyReportDash>();
        }

        responseModel.dDashReportMain = reportDashManager.DataReportMainKapakMIZAN(responseModel.CompID).OrderByDescending(x => x.Year);
        responseModel.dashFinancialOzkaynakAktif = reportDashManager.Get_Data_FinancialOzkaynakAktifMIZAN(responseModel.CompID);

        responseModel.dashDonemselKarzarar = reportDashManager.Get_Data_DonemselKarzararMIZAN(responseModel.CompID);
        responseModel.dashEbitMarjin = reportDashManager.Get_Data_EbitMarjinMIZAN(responseModel.CompID).OrderByDescending(X => X.Year).Take(3);
        responseModel.ResultWorkingCapital = reportDashManager.Get_Data_WorkingCapitalMIZAN(responseModel.CompID).OrderByDescending(X => X.Year).Take(3);
        responseModel.NetDashDepth = ReportDashViewWCap.getRealyValDashDepthMizan(responseModel.dashFinancialDebitMulti).OrderBy(x => x.MainMonth).ToList();
        
        var chkzzz = responseModel.dDashReportMain.Where(x => x.TypeID == 251).Select(x => x.TumYil).FirstOrDefault();
        responseModel.RetValScore = chkzzz.ToString("0.0");
        responseModel.NetGrossProfitGraphic = new DashRep();
       
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);

        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetResponse>.Success(
            new MizanFinanceHrtViewOnGetResponse
            {
                InitialModel = responseModel
            }));
 
    }
}
