using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMain;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMain.Query.ReportMainOnGet;
public class MizanReportMainOnGetQueryHandler(IReportDashMizanManager reportDashMizanManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanReportMainOnGetQuery, GenericResult<MizanReportMainOnGetResponse>>
{
 

    public Task<GenericResult<MizanReportMainOnGetResponse>> Handle(MizanReportMainOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanReportMainRequestInitialModel
        {  
            UserID = userId,
            mrequestEntryView = new YearlyErrorResultView()
        };

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.mreqListCompany = companiesManager.Getby_User(responseModel.UserID);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.dashGrossProfit = reportDashMizanManager.Get_Data_GrossProfit(responseModel.CompID).Where(x => x.Amount != 0);
        responseModel.dashRevenue = reportDashMizanManager.Get_Data_Revenue(responseModel.CompID).Where(x => x.Amount != 0);
        responseModel.dashDonemselKarzarar = reportDashMizanManager.Get_Data_DonemselKarzarar(responseModel.CompID).Where(x => x.Amount != 0);
        responseModel.dashEbitMarjin = reportDashMizanManager.Get_Data_EbitMarjin(responseModel.CompID).Where(x => x.Amount != 0);
        responseModel.dashWorkingCapital = reportDashMizanManager.Get_Data_WorkingCapital(responseModel.CompID).Where(x => x.Amount != 0);
        responseModel.dDashFrossViewMarjBrut = reportDashMizanManager.Get_Data_GrossProfitGraphic(responseModel.CompID).Where(x => x.Amount != 0);
        responseModel.dashEbitMarjinastr = responseModel.dashEbitMarjin.Count() > 0 ? responseModel.dashEbitMarjin.OrderByDescending(x => x.Year).FirstOrDefault().Amount.ToString("n0") : "";
        responseModel.dashGrossProfitstr = responseModel.dashGrossProfit.Count() > 0 ? responseModel.dashGrossProfit.OrderByDescending(x => x.Year).FirstOrDefault().Amount.ToString("n0") : "";
        responseModel.dashRevenuestr = responseModel.dashRevenue.Count() > 0 ? responseModel.dashRevenue.OrderByDescending(x => x.Year).FirstOrDefault().Amount.ToString("n0") : "";
        responseModel.dashDonemselKarzararstr = responseModel.dashDonemselKarzarar.Count() > 0 ? responseModel.dashDonemselKarzarar.OrderByDescending(x => x.Year).FirstOrDefault().Amount.ToString("n0") : "";
        responseModel.dDashFrossViewMarjBrutstr = responseModel.dDashFrossViewMarjBrut.Count() > 0 ? responseModel.dDashFrossViewMarjBrut.OrderByDescending(x => x.Year).FirstOrDefault().Amount.ToString("n2") : "";
        responseModel.dashWorkingCapitalstr = responseModel.dashWorkingCapital.Count() > 0 ? responseModel.dashWorkingCapital.OrderByDescending(x => x.Year).FirstOrDefault().Amount.ToString("n0") : "";
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
 
        return Task.FromResult(GenericResult<MizanReportMainOnGetResponse>.Success(new MizanReportMainOnGetResponse { InitialModel = responseModel }));
        
    }
}
