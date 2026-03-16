using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Globalization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGet;
public class DashBilancoOnGetQueryHandler(ICompanyManager companyManager, IHhvnUsersManager hhvnUsersManager, ITBLXmlManager tBLXmlManager, IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<DashBilancoOnGetQuery, GenericResult<DashBilancoOnGetResponse>>
{
    public DashBilancoRequest responseModel = new();

    public Task<GenericResult<DashBilancoOnGetResponse>> Handle(DashBilancoOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        responseModel.UserID = UserID;

        responseModel.mreqListCompany = companyManager.Getby_User(UserID);

        var company = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        if (company != null)
            return Task.FromResult(GenericResult<DashBilancoOnGetResponse>.Fail("Company not found"));



        responseModel.CompID = company.Id;
        responseModel.CompName = company.CompanyName;
        hhvnUsersManager.SetYearMain(company.Id, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(company.Id);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        responseModel.myearResult = YearResult.getValue();

        responseModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULT(responseModel.CurrentUser.SelectedYear, company.Id);
        responseModel.nRequestListChk = responseModel.nRequestList;
        responseModel.val1 = responseModel.nRequestListChk.Where(x => x.TypeID == 111).Sum(x => x.OverViewTotal);
        responseModel.val3 = responseModel.nRequestListChk.Where(x => x.TypeID == 2222).Sum(x => x.OverViewTotal);
        if (responseModel.val3 < 0)
        { responseModel.val3 *= -1; }

        responseModel.NetIsletme = (responseModel.val1.Value - responseModel.val3.Value).ToString("0,0.00", new CultureInfo("en-US", false));
        var val5 = responseModel.nRequestListChk.Where(x => x.TypeID == 333).Sum(x => x.OverViewTotal);

        if (val5 == 0)
        {
            val5 = 1;
        }

        responseModel.CariOranT = (Convert.ToDecimal(responseModel.nRequestListChk.Where(x => x.TypeID == 111).Sum(x => x.OverViewTotal)) / Convert.ToDecimal(val5));

        if (responseModel.CariOranT < 0)
        {
            responseModel.CariOranT *= -1;
        }

        responseModel.CariOran = responseModel.CariOranT.Value.ToString("0,0.00", new CultureInfo("en-US", false));
        responseModel.NakitOran = (Convert.ToDecimal(responseModel.nRequestListChk.Where(x => (x.TypeID == 10 || x.TypeID == 11)).Sum(x => x.OverViewTotal)) / Convert.ToDecimal(val5)).ToString("N2");

        return Task.FromResult(GenericResult<DashBilancoOnGetResponse>.Success(new DashBilancoOnGetResponse { InitialModel = responseModel }));
    }
}