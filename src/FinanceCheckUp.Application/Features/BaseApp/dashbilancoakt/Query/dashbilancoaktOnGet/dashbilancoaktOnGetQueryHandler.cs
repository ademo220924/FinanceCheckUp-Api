using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.dashbilancoakt;
using FinanceCheckUp.Application.Models.Responses.dashbilancoakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Globalization;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGet;
public class dashbilancoaktOnGetQueryHandler(ICompanyManager companyManager, IHhvnUsersManager hhvnUsersManager, ITBLXmlManager tBLXmlManager, IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<dashbilancoaktOnGetQuery, GenericResult<dashbilancoaktOnGetResponse>>
{
    public dashbilancoaktRequest responseModel = new dashbilancoaktRequest();

    public async Task<GenericResult<dashbilancoaktOnGetResponse>> Handle(dashbilancoaktOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        responseModel.UserID = UserID;
        responseModel.mreqListCompany = companyManager.Getby_User(UserID);

        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID.Value, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID.Value);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        responseModel.myearResult = YearResult.getValue();

        responseModel.nRequestList = dashGelirTablosuManager.Get_MAINBilancoMznAkt(request.Request.myear, responseModel.CompID.Value);
        responseModel.nRequestListChk = responseModel.nRequestList;
        responseModel.val1 = responseModel.nRequestListChk.Where(x => x.TypeID == 111).Sum(x => x.SmmAfter);
        responseModel.val3 = responseModel.nRequestListChk.Where(x => x.TypeID == 2222).Sum(x => x.SmmAfter);
        if (responseModel.val3 < 0)
        { responseModel.val3 = responseModel.val3 * -1; }

        responseModel.NetIsletme = (responseModel.val1.Value - responseModel.val3.Value).ToString("0,0.00", new CultureInfo("en-US", false));
        var val5 = responseModel.nRequestListChk.Where(x => x.TypeID == 333).Sum(x => x.SmmAfter);

        if (val5 == 0)
        {
            val5 = 1;
        }
        responseModel.CariOranT = (Convert.ToDecimal(responseModel.nRequestListChk.Where(x => x.TypeID == 111).Sum(x => x.SmmAfter)) / Convert.ToDecimal(val5));
        if (responseModel.CariOranT < 0)
        {
            responseModel.CariOranT = responseModel.CariOranT * -1;
        }
        responseModel.CariOran = responseModel.CariOranT.Value.ToString("0,0.00", new CultureInfo("en-US", false));
        responseModel.NakitOran = (Convert.ToDecimal(responseModel.nRequestListChk.Where(x => (x.TypeID == 10 || x.TypeID == 11)).Sum(x => x.SmmAfter)) / Convert.ToDecimal(val5)).ToString("N2");

        return GenericResult<dashbilancoaktOnGetResponse>.Success(new dashbilancoaktOnGetResponse { InitialModel = responseModel });
    }
}