using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOneProcess;

public class MoodUploadOneProcessCommandHandler: IRequestHandler<MoodUploadOneProcessCommand, GenericResult<MoodUploadOneProcessResponse>>
{
    public Task<GenericResult<MoodUploadOneProcessResponse>> Handle(MoodUploadOneProcessCommand request, CancellationToken cancellationToken)
    {
       var file = pageIndex.file;
        string filemonth = pageIndex.Caption.Split('_')[0];
        string fileyear = pageIndex.Caption.Split('_')[1];

        int UserID = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));


        try
        {
            string retval = "ok";

            int fyear = Convert.ToInt32(fileyear);

            int fmonth = Convert.ToInt32(filemonth);
            int xmlid = TBLXml.GetComapnyIDByMonth(comp.ID, fmonth, fyear);
            Data.SetOpener(xmlid, filemonth);

            Data dtx = new Data();

            dtx.SetHataLast(xmlid);

            dtx.SetHataLastz(xmlid);


            dtx.SetHataLastza(comp.ID, fyear);
            List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, comp.ID);
            var tlist = Data.SetBilancoFromList(nRequestList, comp.ID, fyear);
            Data.RESET_DashBilancoView(fyear, comp.ID);
            Data.InsertBilnco(tlist);
            List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(fyear, comp.ID);
            var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, comp.ID, fyear);
            Data.RESET_REVENUEView(fyear, comp.ID);
            var WCapitalViez = DashWCapitalViewMain.getList(fyear, comp.ID);
            var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, comp.ID, fyear);
            var nLiqudity = DashLikiditeViewMain.getList(fyear, comp.ID);
            var WLiqudity = Data.SetBilancoFromList(nLiqudity, comp.ID, fyear);
            Data.InsertLiquidity(WLiqudity);
            Data.InsertWCapital(WCapitalVie);
            Data.InsertRvn(tlistRvn);
            DashRasyo.GetDashRasyoAnaliz(fyear, comp.ID);
            DashRasyo.GetDashLikiditeRiskTrend(fyear, comp.ID);
            DashRasyo.GetDashOzetMali(fyear, comp.ID, Convert.ToInt32(filemonth));
            MainDash.Get_DatabyErrorV1(fyear, comp.ID, Convert.ToInt32(filemonth));
            return Json(retval);
        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = comp.ID;
            lg.CsvID = 7777;
            lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
            var chk = ex;
            return Json("nok");

        }
    }
}
