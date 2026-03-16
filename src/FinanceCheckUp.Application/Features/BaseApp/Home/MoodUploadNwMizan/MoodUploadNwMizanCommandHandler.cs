using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadNwMizan;

public class MoodUploadNwMizanCommandHandler: IRequestHandler<MoodUploadNwMizanCommand, GenericResult<MoodUploadNwMizanResponse>>
{
    public Task<GenericResult<MoodUploadNwMizanResponse>> Handle(MoodUploadNwMizanCommand request, CancellationToken cancellationToken)
    {
      string filemonth = pageIndex.Caption.Split('_')[0];
        string fileyear = pageIndex.Caption.Split('_')[1];
        Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
        var file = pageIndex.file;
        string filePath = string.Empty;
        List<string> nlistZipurl = new List<string>();
        string uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

        if (file != null && file.Count > 0)
        {
            foreach (var item in file)
            {
                filePath = System.IO.Path.Combine(uploads, Guid.NewGuid().ToString() + System.IO.Path.GetExtension(item.FileName));
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream).ConfigureAwait(false);
                }

            }

        }
        int monID = Convert.ToInt32(filemonth);
        long CompID = Convert.ToInt64(pageIndex.ide);
        int nYear = Convert.ToInt32(fileyear);
        try
        {


            TBLXml ncs = new TBLXml();
            ncs.CompanyID = CompID;
            ncs.CreatedDate = DateTime.Now;
            ncs.DocumentDate = new DateTime(nYear, monID, 21); ;
            ncs.CsvName = filePath;
            ncs.Year = nYear;
            ncs.XmlDocName = file[0].FileName;
            ncs.Save_TBLXml();

            DataTable dt = ExcelHelper.ExcelToDataTable(filePath);
            IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumn(dt);
            nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", ".").Trim(); return c; }).ToList();
            List<string> nnlist = DashBilancoSetMizan.GetAccountList();
            //   var tlista = nlist.Where(x => (x.CreditAmountFloat == x.AmountBakiyeFloat) && x.CreditAmountFloat == 0).ToList();
            nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain));
            List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
            cchklist = cchklist.GroupBy(i => i.AccountMainID)
                           .Select(g => g.First())
                           .ToList();
            List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 6).ToList();

            foreach (var item in cchklist1)
            {
                try
                {
                    if (item.AmountBakiye != (ConvertDec(item.DebitAmount) - Math.Abs(ConvertDec(item.CreditAmount))).ToString("n2"))
                    {
                        item.AmountBakiye = (ConvertDec(item.DebitAmount) - Math.Abs(ConvertDec(item.CreditAmount))).ToString("n2");
                    }
                }
                catch (Exception ex)
                {

                    var chk = ex;
                }



            }


            var tlist = Data.SetBilancoFromListMizanExcelNew(cchklist, CompID, nYear);

            if (cchklist1.Count > 0)
            {
                var tlistsub = Data.SetBilancoFromListMizanExcelSub(cchklist1, CompID, nYear);
                Data.InsertDataMizanSub(tlistsub);
            }

            if (tlist.Count > 0)
            {
                foreach (XmlExcel us in tlist)
                {
                    us.MainMonth = monID;
                    us.CsvId = ncs.ID;
                }

                Data.InsertDataMizanNew(tlist);
            }
            else
            {
                Data.SET_MIZANHEADER(nYear, CompID);
            }



            //Data.SetOpener(ncs.ID, monID.ToString());

            Data dtx = new Data();

            dtx.SetHataLast(ncs.ID);

            dtx.SetHataLastz(ncs.ID);


            dtx.SetHataLastza(Convert.ToInt32(ncs.CompanyID), nYear);


            return Json("nok");

#pragma warning disable CS0162 // Unreachable code detected
            List<DashBilancoViewMizan> nRequestList1 = DashBilancoMizan.getList(nYear, CompID);
#pragma warning restore CS0162 // Unreachable code detected
            var tlist1 = Data.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
            Data.RESET_DashBilancoViewMizan(nYear, CompID);
            Data.InsertBilncoMzn(tlist1);
            List<DashBilancoViewMizan> nRequestListRvn1 = DashGelirTablosuMizan.getList(nYear, CompID);
            var tlistRvn1 = Data.SetBilancoFromListMizan(nRequestListRvn1, CompID, nYear);
            Data.RESET_REVENUEViewMzn(nYear, CompID);
            Data.InsertRvnMzn(tlistRvn1);
            var WLikiditeViez = DashLikiditeViewMainMizan.getList(nYear, CompID);
            var WCapitalViez = DashWCapitalViewMainMizan.getList(nYear, CompID);
            var WCapitalVie = Data.SetBilancoFromListMizan(WCapitalViez, CompID, nYear);
            var WLikiditeVie = Data.SetBilancoFromListMizan(WLikiditeViez, CompID, nYear);
            Data.InsertWCapitalMzn(WCapitalVie);
            Data.InsertLiquidityMzn(WLikiditeVie);
            DashBilancoSetMizan.Set_ReportSetMainSMM(nYear, CompID);
            DashRasyoMizan.GetDashRasyoAnaliz(nYear, CompID);
            DashRasyoMizan.GetDashLikiditeRiskTrend(nYear, CompID);
            DashRasyoMizan.GetDashOzetMali(nYear, CompID);
        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = CompID;
            lg.CsvID = nYear;
            lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
            return Json(ex.ToString());
        }

#pragma warning disable CS0162 // Unreachable code detected
        return Json("ok");
#pragma warning restore CS0162 // Unreachable code detected

    }
}
