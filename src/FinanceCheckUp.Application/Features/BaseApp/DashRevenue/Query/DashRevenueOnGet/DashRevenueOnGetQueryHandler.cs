using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGet;
public class DashRevenueOnGetQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    ITBLXmlManager tBLXmlManager,
    IReportDashManager reportDashManager) : IRequestHandler<DashRevenueOnGetQuery, GenericResult<DashRevenueOnGetResponse>>
{

    public async Task<GenericResult<DashRevenueOnGetResponse>> Handle(DashRevenueOnGetQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashRevenueRequest
        {
            UserID = UserID,
            mreqListCompany = companyManager.Getby_User(UserID)
        };

        responseModel.myearResult = YearResult.getValue();


        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
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

        return GenericResult<DashRevenueOnGetResponse>.Success(new DashRevenueOnGetResponse { InitialModel = responseModel });
    }
}