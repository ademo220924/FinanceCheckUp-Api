using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashCrm;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Linq;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashCrm.Query.DashCrmOnGet;
public class MizanDashCrmOnGetQueryHandler(
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companiesManager,
    IUserTypeManager userTypeManager,
    ICompanyManager companyManager,
    ITBLXmlManager tBLXmlManager,
    IRasyoAnalizMainManager rasyoAnalizMainManager)
    : IRequestHandler<MizanDashCrmOnGetQuery, GenericResult<MizanDashCrmOnGetResponse>>
{
    private static List<DashYearlyResultCRM> BuildOrderedCrmPivotRows(List<DashYearlyResultCRMMain>? source, int selectedYear)
    {
        var chartCrm = new DashYearlyResultChartCRM();
        chartCrm.SetResult(source ?? new List<DashYearlyResultCRMMain>(), selectedYear);
        return chartCrm.nresult.OrderByDescending(z => z.Value).ToList();
    }

    public Task<GenericResult<MizanDashCrmOnGetResponse>> Handle(MizanDashCrmOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashCrmRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId),
            myearResult = YearResult.getValue(),
            RasyoAnalizView = new DashYearlyResultChart(),
            OzetMaliView = new DashYearlyResultChart(),
            LikiditeRiskTrendView = new DashYearlyResultChart()
        };


        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        var selectedYear = responseModel.CurrentUser.SelectedYear;
        var compId = responseModel.CompID;
        var yearForCrm = MizanDashCrmCrmDataYearResolver.Resolve(selectedYear, tBLXmlManager.GetMaxYearTblXmlSourceOneT(compId));
        responseModel.CrmPivot102Rows = BuildOrderedCrmPivotRows(rasyoAnalizMainManager.CRMAnalizTOTAL102Mizan(yearForCrm, compId), yearForCrm);
        responseModel.CrmPivot103Rows = BuildOrderedCrmPivotRows(rasyoAnalizMainManager.CRMAnalizTOTAL103Mizan(yearForCrm, compId), yearForCrm);
        responseModel.CrmPivot101Rows = BuildOrderedCrmPivotRows(rasyoAnalizMainManager.CRMAnalizTOTAL101Mizan(yearForCrm, compId), yearForCrm);
        responseModel.CrmPivot120Rows = BuildOrderedCrmPivotRows(rasyoAnalizMainManager.CRMAnalizTOTAL120Mizan(yearForCrm, compId), yearForCrm);

        return Task.FromResult(GenericResult<MizanDashCrmOnGetResponse>.Success(
            new MizanDashCrmOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
