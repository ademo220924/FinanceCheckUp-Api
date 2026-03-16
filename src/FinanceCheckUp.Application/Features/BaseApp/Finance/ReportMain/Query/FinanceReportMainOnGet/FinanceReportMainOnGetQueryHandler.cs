using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.StaticManagers;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGet;
public class FinanceReportMainOnGetQueryHandler(
    IDashBilancoManager dashBilancoManager,
    IReportDashManager reportDashManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    IUserTypeManager userTypeManager, 
    ICompanyManager companyManager, 
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceReportMainOnGetQuery, GenericResult<FinanceReportMainOnGetResponse>>
{
    

    public Task<GenericResult<FinanceReportMainOnGetResponse>> Handle(FinanceReportMainOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceReportMainRequestInitialModel
        {  
            UserID = userId,
            myearResult = YearResult.getValue(),
            mrequestEntryView = new YearlyErrorResultView()
        };


        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.dashGrossProfit = reportDashManager.Get_Data_GrossProfit(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashRevenue = reportDashManager.Get_Data_Revenue(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashDonemselKarzarar = reportDashManager.Get_Data_DonemselKarzarar(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashEbitMarjin = reportDashManager.Get_Data_EbitMarjin(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dDashFrossViewMarjBrut = reportDashManager.Get_Data_GrossProfitGraphic(responseModel.CurrentUser.SelectedYear, responseModel.CompID);


        var chk = reportDashManager.Get_Data_WorkingCapital(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        var lastmont = reportDashManager.Get_LastMonthYear(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        var chk1 = DashYearlyResultWorkingCapital.setProp(lastmont, chk);
        responseModel.dashWorkingCapital = DashYearlyResultChart.SetResultMain(chk1, responseModel.CurrentUser.SelectedYear);


        responseModel.NetEbitMarjin = ReportDashViewWCap.getRealyVal(responseModel.dashEbitMarjin);
        responseModel.NetGrossProfit = ReportDashViewWCap.getRealyVal(responseModel.dashGrossProfit);
        responseModel.NetRevenue = ReportDashViewWCap.getRealyVal(responseModel.dashRevenue);
        responseModel.NetDonemselKarzarar = ReportDashViewWCap.getRealyVal(responseModel.dashDonemselKarzarar);
        responseModel.NetWorkingCapital = ReportDashViewWCap.getRealyValT(responseModel.dashWorkingCapital);



        var netGrossProfitGraphic = new DashRep
        {
            EntryCountTotal = Convert.ToDecimal(responseModel.NetRevenue.EntryCountTotal) == 0 ? "0" : "% " + String.Format("{0:0.##}", (Convert.ToDecimal(responseModel.NetGrossProfit.EntryCountTotal) / Convert.ToDecimal(responseModel.NetRevenue.EntryCountTotal) * 100)),
            EntryCountBefore = Convert.ToDecimal(responseModel.NetRevenue.EntryCountBefore) == 0 ? "0" : "% " + String.Format("{0:0.##}", (Convert.ToDecimal(responseModel.NetGrossProfit.EntryCountBefore) / Convert.ToDecimal(responseModel.NetRevenue.EntryCountBefore) * 100)),
            EntryCountLast = Convert.ToDecimal(responseModel.NetRevenue.EntryCountLast) == 0 ? "0" : "% " + String.Format("{0:0.##}", (Convert.ToDecimal(responseModel.NetGrossProfit.EntryCountLast) / Convert.ToDecimal(responseModel.NetRevenue.EntryCountLast) * 100))
        };

        responseModel.NetGrossProfitGraphic = netGrossProfitGraphic;
        
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);

        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();


        responseModel.dDashBilancoViewMarjBrut = dashBilancoManager.Get_MAINBrutKarZarar(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dDashBilancoViewMarjNet = dashBilancoManager.Get_MAINNetSatis(responseModel.CurrentUser.SelectedYear, responseModel.CompID);




        decimal docz = Convert.ToDecimal(responseModel.NetRevenue.EntryCountTotal);
        decimal doc = Convert.ToDecimal(responseModel.NetRevenue.EntryCountBefore.Replace(",", ""));
        decimal doc1 = Convert.ToDecimal(responseModel.NetRevenue.EntryCountLast.Replace(",", ""));

        if (docz == 0) { docz = 1; }
        if (doc == 0) { doc = 1; }
        if (doc1 == 0) { doc1 = 1; }
        if (responseModel.dDashBilancoViewMarjNet != null)
        {
            decimal valNet = responseModel.dDashBilancoViewMarjNet.OverViewTotal;
            if (valNet == 0)
            {
                valNet = 1;
            }

            responseModel.RetValGross = "% " + String.Format("{0:0.##}", (Convert.ToDecimal(responseModel.dDashBilancoViewMarjBrut.OverViewTotal) / Convert.ToDecimal(valNet)) * 100);
        }
        else
        {
            responseModel.RetValGross = "% " + 0;
        }
         

        return Task.FromResult(GenericResult<FinanceReportMainOnGetResponse>.Success(new FinanceReportMainOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
