using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnakt;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Globalization;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnakt.Query.dashbilancorvnaktOnGet;
public class dashbilancorvnaktOnGetQueryHandler(ICompanyManager companyManager, IHhvnUsersManager hhvnUsersManager, ITBLXmlManager tBLXmlManager, IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<dashbilancorvnaktOnGetQuery, GenericResult<dashbilancorvnaktOnGetResponse>>
{

    public async Task<GenericResult<dashbilancorvnaktOnGetResponse>> Handle(dashbilancorvnaktOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new dashbilancorvnaktRequest
        {
            UserID = UserID,
            mreqListCompany = companyManager.Getby_User(UserID)
        };

        responseModel.UserID = UserID;
        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();
        responseModel.nRequestList = dashGelirTablosuManager.Get_MAINRevenueMznAkt(request.Request.myear, responseModel.CompID).Where(x => x.SmmAfter != 0 && x.SmmBefore != 0);
        responseModel.nRequestListChk = responseModel.nRequestList;
        responseModel.val1 = responseModel.nRequestListChk.Where(x => x.TypeID == 111).Sum(x => x.SmmAfter);
        responseModel.val3 = responseModel.nRequestListChk.Where(x => x.TypeID == 2222).Sum(x => x.SmmAfter);

        if (responseModel.val3 < 0) { responseModel.val3 = responseModel.val3 * -1; }
        responseModel.NetIsletme = (responseModel.val1 - responseModel.val3).ToString("0,0.00", new CultureInfo("en-US", false));

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

        responseModel.CariOran = responseModel.CariOranT.ToString("0,0.00", new CultureInfo("en-US", false));
        responseModel.NakitOran = (Convert.ToDecimal(responseModel.nRequestListChk.Where(x => (x.TypeID == 10 || x.TypeID == 11)).Sum(x => x.SmmAfter)) / Convert.ToDecimal(val5)).ToString("N2");
        return GenericResult<dashbilancorvnaktOnGetResponse>.Success(new dashbilancorvnaktOnGetResponse { InitialModel = responseModel });
    }
}