using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashWorkingCapital;
using FinanceCheckUp.Application.Models.Responses.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGet;
public class DashWorkingCapitalOnGetQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    ITBLXmlManager tBLXmlManager,
    IReportDashManager reportDashManager,
    IDashWCapitalManager dashWCapitalManager) : IRequestHandler<DashWorkingCapitalOnGetQuery, GenericResult<DashWorkingCapitalOnGetResponse>>
{

    public async Task<GenericResult<DashWorkingCapitalOnGetResponse>> Handle(DashWorkingCapitalOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashWorkingCapitalRequest
        {
            UserID = UserID,
            mreqListCompany = companyManager.Getby_User(UserID)
        };

        responseModel.myearResult = YearResult.getValue();
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        DashYearlyResultWorkingCapital chk = reportDashManager.Get_Data_WorkingCapital(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        int lastmont = reportDashManager.Get_LastMonthYear(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        DashYearlyResultWorkingCapital chk1 = DashYearlyResultWorkingCapital.setProp(lastmont, chk);
        responseModel.nRequestListViewMain = DashYearlyResultChart.SetResultMain(chk1, responseModel.CurrentUser.SelectedYear);
        responseModel.NetWorkingCapital = ReportDashViewWCap.getRealyValT(responseModel.nRequestListViewMain);
        responseModel.nRequestListViewChart = responseModel.nRequestListViewMain;
        responseModel.nRequestList = dashWCapitalManager.Get_getDataWcapFINAL(responseModel.CurrentUser.SelectedYear, responseModel.CompID);

        return GenericResult<DashWorkingCapitalOnGetResponse>.Success(new DashWorkingCapitalOnGetResponse { InitialModel = responseModel });
    }
}