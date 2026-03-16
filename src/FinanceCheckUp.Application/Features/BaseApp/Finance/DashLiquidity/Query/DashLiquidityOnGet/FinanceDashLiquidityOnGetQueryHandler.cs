using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.DashLiquidity;
using FinanceCheckUp.Application.Models.Responses.Finance.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Globalization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashLiquidity.Query.DashLiquidityOnGet;
public class FinanceDashLiquidityOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    ITBLXmlManager tBLXmlManager, 
    IDashGelirTablosuManager dashGelirTablosuManager, 
    IDashLikiditeManager dashLikiditeManager, 
    IDashLikiditeViewMainManager dashLikiditeViewMainManager, 
    IDashLikiditeManager dashLikiditeManager1) : IRequestHandler<FinanceDashLiquidityOnGetQuery, GenericResult<FinanceDashLiquidityOnGetResponse>>
{
    public Task<GenericResult<FinanceDashLiquidityOnGetResponse>> Handle(FinanceDashLiquidityOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceDashLiquidityRequestInitialModel
        {
            UserID = userId
        };

        responseModel.myearResult = YearResult.getValue();
        responseModel.mreqListCompany = companiesManager.Getby_User(userId);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        hhvnUsersManager.SetYearMain(responseModel.CompID, userId);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
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
        
        DashBilancoView wwn = dashLikiditeManager1.Get_LikiditeORANT(responseModel.CurrentUser.SelectedYear, responseModel.CompID).FirstOrDefault();
        responseModel.nRequestListViewChart = DashWCapitalShortViewList.getListDashWChart(wwn);

        return Task.FromResult(GenericResult<FinanceDashLiquidityOnGetResponse>.Success(new FinanceDashLiquidityOnGetResponse
        {
            InitialModel = responseModel
        }));

    }
}
