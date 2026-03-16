using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtView;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtView.Query.FinanceFinanceHrtViewOnGet;
public class FinanceFinanceHrtViewOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager,  
    ITBLXmlManager tBLXmlManager, 
    IBultenManager bultenManager, 
    IReportDashManager reportDashManager, 
    IDashBilancoManager dashBilancoManager) : IRequestHandler<FinanceFinanceHrtViewOnGetQuery, GenericResult<FinanceFinanceHrtViewOnGetResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtViewOnGetResponse>> Handle(FinanceFinanceHrtViewOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceFinanceHrtViewRequestInitialModel
        {
            UserID = userId
        };

        responseModel.mreqList = bultenManager.Get_BWarn();
        responseModel.myearResult = YearResult.getValue();
        responseModel.mrequestEntryView = new YearlyErrorResultView();
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        responseModel.mreqListCompany = companiesManager.Getby_User(userId);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.dashGrossProfit = reportDashManager.Get_Data_GrossProfit(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashFinancialDebit = reportDashManager.Get_Data_FinancialDebit(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashFinancialDebitMulti = reportDashManager.Get_Data_FinancialDebitMulti(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashFinancialCariOran = reportDashManager.Get_Data_FinancialCariOrAN(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        if (responseModel.dashFinancialCariOran == null)
        {
            responseModel.dashFinancialCariOran = new DashBilancoViewMarj();

        }
        responseModel.dDashReportMain = reportDashManager.DataReportMainKapak(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashFinancialOzkaynakAktif = reportDashManager.Get_Data_FinancialOzkaynakAktif(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashRevenue = reportDashManager.Get_Data_Revenue(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashDonemselKarzarar = reportDashManager.Get_Data_DonemselKarzarar(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashEbitMarjin = reportDashManager.Get_Data_EbitMarjin(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dDashFrossViewMarjBrut = reportDashManager.Get_Data_GrossProfitGraphic(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        DashYearlyResultWorkingCapital chk = reportDashManager.Get_Data_WorkingCapital(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        int lastmont = reportDashManager.Get_LastMonthYear(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        DashYearlyResultWorkingCapital chk1 = DashYearlyResultWorkingCapital.setProp(lastmont, chk);
        responseModel.dashWorkingCapital = DashYearlyResultChart.SetResultMain(chk1, responseModel.CurrentUser.SelectedYear);
        responseModel.NetEbitMarjin = ReportDashViewWCap.getRealyVal(responseModel.dashEbitMarjin);
        responseModel.NetDashDepth = ReportDashViewWCap.getRealyValDashDepth(responseModel.dashFinancialDebitMulti);
        responseModel.NetGrossProfit = ReportDashViewWCap.getRealyVal(responseModel.dashGrossProfit);
        responseModel.NetFinancialDebit = ReportDashViewWCap.getRealyVal(responseModel.dashFinancialDebit);
        responseModel.NetRevenue = ReportDashViewWCap.getRealyVal(responseModel.dashRevenue);
        responseModel.NetDonemselKarzarar = ReportDashViewWCap.getRealyVal(responseModel.dashDonemselKarzarar);
        responseModel.NetWorkingCapital = ReportDashViewWCap.getRealyValT(responseModel.dashWorkingCapital);
        float chkzzz = responseModel.dDashReportMain.Where(x => x.TypeID == 251).Select(x => x.TumYil).FirstOrDefault();
        responseModel.RetValScore = chkzzz.ToString("0.0");
        responseModel.NetGrossProfitGraphic = new DashRep();
        responseModel.NetGrossProfitGraphic.EntryCountTotal = Convert.ToDecimal(responseModel.NetRevenue.EntryCountTotal) == 0 ? "0" : "% " + String.Format("{0:0.##}", (Convert.ToDecimal(responseModel.NetGrossProfit.EntryCountTotal) / Convert.ToDecimal(responseModel.NetRevenue.EntryCountTotal) * 100));
        responseModel.NetGrossProfitGraphic.EntryCountBefore = Convert.ToDecimal(responseModel.NetRevenue.EntryCountBefore) == 0 ? "0" : "% " + String.Format("{0:0.##}", (Convert.ToDecimal(responseModel.NetGrossProfit.EntryCountBefore) / Convert.ToDecimal(responseModel.NetRevenue.EntryCountBefore) * 100));
        responseModel.NetGrossProfitGraphic.EntryCountLast = Convert.ToDecimal(responseModel.NetRevenue.EntryCountLast) == 0 ? "0" : "% " + String.Format("{0:0.##}", (Convert.ToDecimal(responseModel.NetGrossProfit.EntryCountLast) / Convert.ToDecimal(responseModel.NetRevenue.EntryCountLast) * 100));
        hhvnUsersManager.SetYearMain(responseModel.CompID, userId);
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


        return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetResponse>.Success(new FinanceFinanceHrtViewOnGetResponse
        {
            InitialModel = responseModel
        }));

    }
}
