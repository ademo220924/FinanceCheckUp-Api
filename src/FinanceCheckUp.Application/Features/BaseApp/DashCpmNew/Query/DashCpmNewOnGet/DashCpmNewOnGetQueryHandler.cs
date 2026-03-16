using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashCpmNew;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGet;
public class DashCpmNewOnGetQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    IBultenManager bultenManager,
    ITBLXmlManager tBLXmlManager,
    IRasyoAnalizMainManager rasyoAnalizMainManager) : IRequestHandler<DashCpmNewOnGetQuery, GenericResult<DashCpmNewOnGetResponse>>
{

    public async Task<GenericResult<DashCpmNewOnGetResponse>> Handle(DashCpmNewOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashCpmNewRequest
        {
            UserID = UserID,
            mreqListCompany = companyManager.Getby_User(UserID),
            myearResult = YearResult.getValue(),
            RasyoAnalizView = new DashYearlyResultChart(),
            OzetMaliView = new DashYearlyResultChart(),
            LikiditeRiskTrendView = new DashYearlyResultChart(),
            mreqList = bultenManager.Get_BWarnCPM()
        };

        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.RasyoAnalizViewCrm102 = new DashYearlyResultChartCRM();
        responseModel.RasyoAnalizCRM102 = rasyoAnalizMainManager.CRMAnalizTOTAL102(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.RasyoAnalizViewCrm102.SetResultA(responseModel.RasyoAnalizCRM102, responseModel.CurrentUser.SelectedYear);
        responseModel.RasyoAnalizCRM102t = responseModel.RasyoAnalizViewCrm102.nresult.OrderByDescending(z => z.Value).Take(5).ToList();
        responseModel.RasyoAnalizViewCRM101 = new DashYearlyResultChartCRM();
        responseModel.RasyoAnalizCRM101 = rasyoAnalizMainManager.CRMAnalizTOTAL101(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.RasyoAnalizViewCRM101.SetResultA(responseModel.RasyoAnalizCRM101, responseModel.CurrentUser.SelectedYear);
        responseModel.RasyoAnalizCRM101t = responseModel.RasyoAnalizViewCRM101.nresult.OrderByDescending(z => z.Value).Take(5).ToList();
        responseModel.RasyoAnalizViewCRM103 = new DashYearlyResultChartCRM();
        responseModel.RasyoAnalizCRM103 = rasyoAnalizMainManager.CRMAnalizTOTAL103(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.RasyoAnalizViewCRM103.SetResultA(responseModel.RasyoAnalizCRM103, responseModel.CurrentUser.SelectedYear);
        responseModel.RasyoAnalizCRM103t = responseModel.RasyoAnalizViewCRM103.nresult.OrderByDescending(z => z.Value).Take(5).ToList();
        responseModel.RasyoAnalizViewCRM120 = new DashYearlyResultChartCRM();
        responseModel.RasyoAnalizCRM120 = rasyoAnalizMainManager.CRMAnalizTOTAL120(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.RasyoAnalizViewCRM120.SetResultA(responseModel.RasyoAnalizCRM120, responseModel.CurrentUser.SelectedYear);
        responseModel.RasyoAnalizCRM120t = responseModel.RasyoAnalizViewCRM120.nresult.OrderByDescending(z => z.Value).Take(5).ToList();
        responseModel.RasyoAnalizViewCRM320 = new DashYearlyResultChartCRM();
        responseModel.RasyoAnalizCRM320 = rasyoAnalizMainManager.CRMAnalizTOTAL320(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.RasyoAnalizViewCRM320.SetResultA(responseModel.RasyoAnalizCRM320, responseModel.CurrentUser.SelectedYear);
        responseModel.RasyoAnalizCRM320t = responseModel.RasyoAnalizViewCRM320.nresult.OrderByDescending(z => z.Value).Take(5).ToList();

        return GenericResult<DashCpmNewOnGetResponse>.Success(new DashCpmNewOnGetResponse { InitialModel = responseModel });
    }
}