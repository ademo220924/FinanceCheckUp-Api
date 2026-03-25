using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdate;

public class MoodUpdateCommandHandler(
    ITBLXmlManager tblXmlManager,
    IDataManager dataManager,
    IXmlCheckerManager xmlCheckerManager,
    IDashGelirTablosuViewMainManager dashGelirTablosuViewMainManager,
    IDashWCapitalViewMainManager dashWCapitalViewMainManager,
    IDashLikiditeViewMainManager dashLikiditeViewMainManager,
    IDashRasyoManager dashRasyoManager,
    IMainDashManager mainDashManager): IRequestHandler<MoodUpdateCommand, GenericResult<MoodUpdateResponse>>
{
    public async Task<GenericResult<MoodUpdateResponse>> Handle(MoodUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var pageIndex= request.MoodUpdateRequest.PageIndex;
            
            var chka = tblXmlManager.GetComapnyIDByMonth(pageIndex.companyid, pageIndex.month, pageIndex.year);
            var test = dataManager.Get_AllbyCsvIDataz(chka, pageIndex.month);
            var retval = xmlCheckerManager.UpdateChek(chka, test, pageIndex.month, pageIndex.companyid);
            if (retval != "nok")
            {
                int fyear = pageIndex.year;

                List<DashBilancoView> nRequestList = dashGelirTablosuViewMainManager.getList(fyear, pageIndex.companyid);
                var tlist = dataManager.SetBilancoFromList(nRequestList, pageIndex.companyid, fyear);
                dataManager.RESET_DashBilancoView(fyear, pageIndex.companyid);
                dataManager.InsertBilnco(tlist);
                List<DashBilancoView> nRequestListRvn = dashGelirTablosuViewMainManager.getList(fyear, pageIndex.companyid);
                var tlistRvn = dataManager.SetBilancoFromList(nRequestListRvn, pageIndex.companyid, fyear);
                dataManager.RESET_REVENUEView(fyear, pageIndex.companyid);
                var WCapitalViez = dashWCapitalViewMainManager.getList(fyear, pageIndex.companyid);

                var WCapitalVie = dataManager.SetBilancoFromList(WCapitalViez, pageIndex.companyid, fyear);
                var nLiqudity = dashLikiditeViewMainManager.getList(fyear, pageIndex.companyid);
                var WLiqudity = dataManager.SetBilancoFromList(nLiqudity, pageIndex.companyid, fyear);
                dataManager.InsertLiquidity(WLiqudity);
                dataManager.InsertWCapital(WCapitalVie);

                dataManager.InsertRvn(tlistRvn);
                dashRasyoManager.GetDashRasyoAnaliz(fyear, pageIndex.companyid);
                dashRasyoManager.GetDashLikiditeRiskTrend(fyear, pageIndex.companyid);
                dashRasyoManager.GetDashOzetMali(fyear, pageIndex.companyid, pageIndex.month);
                mainDashManager.Get_DatabyErrorV1(fyear, pageIndex.companyid, pageIndex.month);

            }
        }
        catch (Exception ex)
        {
            return GenericResult<MoodUpdateResponse>.Success(new MoodUpdateResponse() { ResultText = new JsonResult("nok_" + ex.ToString()) });
        }

        return GenericResult<MoodUpdateResponse>.Success(new MoodUpdateResponse() { ResultText = new JsonResult("ok")});
    }
}
