using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdate;

public class MoodUpdateCommandHandler: IRequestHandler<MoodUpdateCommand, GenericResult<MoodUpdateResponse>>
{
    public Task<GenericResult<MoodUpdateResponse>> Handle(MoodUpdateCommand request, CancellationToken cancellationToken)
    {
                try
        {
            var chka = TBLXml.GetComapnyIDByMonth(pageIndex.companyid, pageIndex.month, pageIndex.year);
            var test = Data.Get_AllbyCsvIDataz(chka, pageIndex.month);
            var retval = XmlChecker.UpdateChek(chka, test, pageIndex.month, pageIndex.companyid);
            if (retval != "nok")
            {
                int fyear = pageIndex.year;

                List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, pageIndex.companyid);
                var tlist = Data.SetBilancoFromList(nRequestList, pageIndex.companyid, fyear);
                Data.RESET_DashBilancoView(fyear, pageIndex.companyid);
                Data.InsertBilnco(tlist);
                List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(fyear, pageIndex.companyid);
                var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, pageIndex.companyid, fyear);
                Data.RESET_REVENUEView(fyear, pageIndex.companyid);
                var WCapitalViez = DashWCapitalViewMain.getList(fyear, pageIndex.companyid);

                var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, pageIndex.companyid, fyear);
                var nLiqudity = DashLikiditeViewMain.getList(fyear, pageIndex.companyid);
                var WLiqudity = Data.SetBilancoFromList(nLiqudity, pageIndex.companyid, fyear);
                Data.InsertLiquidity(WLiqudity);
                Data.InsertWCapital(WCapitalVie);

                Data.InsertRvn(tlistRvn);
                DashRasyo.GetDashRasyoAnaliz(fyear, pageIndex.companyid);
                DashRasyo.GetDashLikiditeRiskTrend(fyear, pageIndex.companyid);
                DashRasyo.GetDashOzetMali(fyear, pageIndex.companyid, pageIndex.month);
                MainDash.Get_DatabyErrorV1(fyear, pageIndex.companyid, pageIndex.month);

            }
        }
        catch (Exception ex)
        {

            return Json("nok_" + ex.ToString());
        }



        return Json("ok");
    }
}
