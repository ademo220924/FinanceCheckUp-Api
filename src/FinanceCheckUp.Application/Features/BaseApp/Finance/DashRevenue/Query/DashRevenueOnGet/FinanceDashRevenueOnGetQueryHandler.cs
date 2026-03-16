using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRevenue.Query.DashRevenueOnGet;
public class FinanceDashRevenueOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager,  
    ITBLXmlManager tBLXmlManager, 
    IReportDashManager reportDashManager) : IRequestHandler<FinanceDashRevenueOnGetQuery, GenericResult<FinanceDashRevenueOnGetResponse>>
{
    public Task<GenericResult<FinanceDashRevenueOnGetResponse>> Handle(FinanceDashRevenueOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashRevenueRequestInitialModel
        {
            UserID = userId
        };
        responseModel.myearResult = YearResult.getValue();
        responseModel.mreqListCompany = companiesManager.Getby_User(userId);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        hhvnUsersManager.SetYearMain(responseModel.CompID, userId);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.dashGrossProfit = reportDashManager.Get_Data_GrossProfit(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashRevenue = reportDashManager.Get_Data_Revenue(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashDonemselKarzarar = reportDashManager.Get_Data_DonemselKarzarar(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.dashEbitMarjin = reportDashManager.Get_Data_EbitMarjin(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.NetEbitMarjin = ReportDashViewWCap.getRealyVal(responseModel.dashEbitMarjin);
        responseModel.NetGrossProfit = ReportDashViewWCap.getRealyVal(responseModel.dashGrossProfit);
        responseModel.NetRevenue = ReportDashViewWCap.getRealyVal(responseModel.dashRevenue);
        responseModel.NetDonemselKarzarar = ReportDashViewWCap.getRealyVal(responseModel.dashDonemselKarzarar);

        var doc = Convert.ToDecimal(responseModel.NetRevenue.EntryCountTotal);
        if (doc == 0)
        {
            doc = 1;
        }

        responseModel.brutkarzararstr = "%" + String.Format("{0:0.##}", (Convert.ToDecimal(responseModel.NetGrossProfit.EntryCountTotal) / doc * 100));
        responseModel.ebitstr = "%" + String.Format("{0:0.##}", (Convert.ToDecimal(responseModel.NetEbitMarjin.EntryCountTotal) / doc * 100));
        responseModel.donemkarzararstr = "%" + String.Format("{0:0.##}", (Convert.ToDecimal(responseModel.NetDonemselKarzarar.EntryCountTotal) / doc * 100));

        return Task.FromResult(GenericResult<FinanceDashRevenueOnGetResponse>.Success(new FinanceDashRevenueOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
