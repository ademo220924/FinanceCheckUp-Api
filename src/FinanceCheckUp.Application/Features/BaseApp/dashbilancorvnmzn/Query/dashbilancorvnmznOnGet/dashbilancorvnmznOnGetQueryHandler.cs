using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnmzn;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Globalization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmzn.Query.dashbilancorvnmznOnGet;
public class dashbilancorvnmznOnGetQueryHandler(ICompanyManager companyManager, IHhvnUsersManager hhvnUsersManager, ITBLXmlManager tBLXmlManager, IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<dashbilancorvnmznOnGetQuery, GenericResult<dashbilancorvnmznOnGetResponse>>
{

    public async Task<GenericResult<dashbilancorvnmznOnGetResponse>> Handle(dashbilancorvnmznOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new dashbilancorvnmznRequest
        {
            UserID = UserID,
            mreqListCompany = companyManager.Getby_User(UserID)
        };


        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();
        responseModel.nRequestList = dashGelirTablosuManager.Get_MAINRevenueMznSmm(request.Request.myear, responseModel.CompID).Where(x => x.SmmAfter != 0 && x.SmmBefore != 0);
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

        return GenericResult<dashbilancorvnmznOnGetResponse>.Success(new dashbilancorvnmznOnGetResponse { InitialModel = responseModel });
    }
}