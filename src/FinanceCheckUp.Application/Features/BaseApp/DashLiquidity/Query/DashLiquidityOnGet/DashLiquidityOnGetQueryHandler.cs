using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.DashLiquidity;
using FinanceCheckUp.Application.Models.Responses.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Globalization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGet;
public class DashLiquidityOnGetQueryHandler(
    ICompanyManager companyManager,
    IHhvnUsersManager hhvnUsersManager,
    ITBLXmlManager tBLXmlManager,
    IDashGelirTablosuManager dashGelirTablosuManager,
    IDashLikiditeManager dashLikiditeManager,
    IDashLikiditeViewMainManager dashLikiditeViewMainManager) : IRequestHandler<DashLiquidityOnGetQuery, GenericResult<DashLiquidityOnGetResponse>>
{

    public async Task<GenericResult<DashLiquidityOnGetResponse>> Handle(DashLiquidityOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashLiquidityRequest
        {
            UserID = UserID,
            mreqListCompany = companyManager.Getby_User(UserID),
            myearResult = YearResult.getValue()
        };

        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.nRequestListChk = dashGelirTablosuManager.Get_MAINRESULT(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        var chkkkt = dashLikiditeManager.Get_MainList(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        if (chkkkt.Count < 1)
        {
            responseModel.nRequestList = dashLikiditeViewMainManager.getList(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        }
        else
        {
            responseModel.nRequestList = chkkkt;
        }

        try
        {
            if (responseModel.nRequestListChk.Count > 0)
            {
                var val5 = responseModel.nRequestListChk.Where(x => x.TypeID == 333).FirstOrDefault().getTotalInt();
                if (val5 == 0)
                {
                    val5 = 1;
                }
                decimal chkt = Convert.ToDecimal(responseModel.nRequestListChk.Where(x => (x.TypeID == 111)).FirstOrDefault().getTotalInt() - responseModel.nRequestListChk.Where(x => (x.TypeID == 15)).FirstOrDefault().getTotalInt());
                responseModel.NetIsletmeT = chkt / Convert.ToDecimal(val5);
                if (responseModel.NetIsletmeT < 0)
                {
                    responseModel.NetIsletmeT = responseModel.NetIsletmeT * -1;
                }

                responseModel.NetIsletme = responseModel.NetIsletmeT.ToString("F", new CultureInfo("en-US", false));
            }
        }
        catch (Exception)
        {
            responseModel.NetIsletme = (0).ToString("F", new CultureInfo("en-US", false));
        }
        DashBilancoView wwn = dashLikiditeManager.Get_LikiditeORANT(responseModel.CurrentUser.SelectedYear, responseModel.CompID).FirstOrDefault();
        responseModel.nRequestListViewChart = DashWCapitalShortViewList.getListDashWChart(wwn);

        return GenericResult<DashLiquidityOnGetResponse>.Success(new DashLiquidityOnGetResponse { InitialModel = responseModel });
    }
}