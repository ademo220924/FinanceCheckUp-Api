using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Responses.Finance.DashBilanco;
using FinanceCheckUp.Application.Models.Requests.Finance.DashBilanco;
using System.Globalization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashBilanco.Query.FinanceDashBilancoOnGet;
public class FinanceDashBilancoOnGetQueryHandler(IDashGelirTablosuManager dashGelirTablosu,
    IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceDashBilancoOnGetQuery, GenericResult<FinanceDashBilancoOnGetResponse>>
{
    public Task<GenericResult<FinanceDashBilancoOnGetResponse>> Handle(FinanceDashBilancoOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashBilancoRequestInitialModel
        {
            UserID = userId
        };

        responseModel.mreqListCompany = companyManager.Getby_User(userId);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, userId);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();
        responseModel.nRequestList = dashGelirTablosu.Get_MAINRESULT(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.nRequestListChk = responseModel.nRequestList;
        responseModel.val1 = responseModel.nRequestListChk.Where(x => x.TypeID == 111).Sum(x => x.OverViewTotal);
        responseModel.val3 = responseModel.nRequestListChk.Where(x => x.TypeID == 2222).Sum(x => x.OverViewTotal);
        if (responseModel.val3 < 0) { responseModel.val3 = responseModel.val3 * -1; }
        responseModel.NetIsletme = (responseModel.val1 - responseModel.val3).ToString("0,0.00", new CultureInfo("en-US", false));
        var val5 = responseModel.nRequestListChk.Where(x => x.TypeID == 333).Sum(x => x.OverViewTotal);
        if (val5 == 0)
        {
            val5 = 1;
        }
        responseModel.CariOranT = (Convert.ToDecimal(responseModel.nRequestListChk.Where(x => x.TypeID == 111).Sum(x => x.OverViewTotal)) / Convert.ToDecimal(val5));
        if (responseModel.CariOranT < 0)
        {
            responseModel.CariOranT = responseModel.CariOranT * -1;
        }
        responseModel.CariOran = responseModel.CariOranT.ToString("0,0.00", new CultureInfo("en-US", false));
        responseModel.NakitOran = (Convert.ToDecimal(responseModel.nRequestListChk.Where(x => (x.TypeID == 10 || x.TypeID == 11)).Sum(x => x.OverViewTotal)) / Convert.ToDecimal(val5)).ToString("N2");

        return Task.FromResult(GenericResult<FinanceDashBilancoOnGetResponse>.Success(new FinanceDashBilancoOnGetResponse
        {
            InitialModel = responseModel
        }));


    }
}
