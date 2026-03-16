using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Helper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadUpdateMzn;

public class MoodUploadUpdateMznCommandHandler
    (
    IDashBilancoSetMizanManager dashBilancoSetMizanManager,
    IDataManager dataManager,
    IDashBilancoMizanManager dashBilancoMizanManager,
    IDashGelirTablosuMizanManager dashGelirTablosuMizanManager,
    IDashLikiditeViewMainMizanManager dashLikiditeViewMainMizanManager,
    IDashWCapitalViewMainMizanManager dashWCapitalViewMainMizanManager,
    IDashRasyoMizanManager dashRasyoMizanManager,
    ITBLMizanManager tBLMizanManager,
    IERRLOGManager eRRLOGManager
    ) : IRequestHandler<MoodUploadUpdateMznCommand, GenericResult<MoodUploadUpdateMznResponse>>
{


    public async Task<GenericResult<MoodUploadUpdateMznResponse>> Handle(MoodUploadUpdateMznCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.XMlook;
        long CompID = Convert.ToInt64(pageIndex.ide);
        int nYear = pageIndex.id;
        var file = pageIndex.file;
        string filePath = string.Empty;
        var uploads = Path.Combine(Directory.GetCurrentDirectory(), "Documents"); ;
        int nmonth = Convert.ToInt32(pageIndex.Caption.Split('_')[0]);
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
        try
        {

            Tblmizan ncs = new Tblmizan();
            ncs.CompanyId = CompID;
            ncs.CreatedDate = DateTime.Now;
            ncs.DocumentDate = new DateTime(nYear, 12, 12);
            ncs.CsvName = filePath;
            ncs.Year = nYear;
            ncs.MainMonth = nmonth;
            ncs.Id = tBLMizanManager.Save_TBLMizan(ncs);

            DataTable dt = ExcelHelper.ExcelToDataTable(filePath);
            IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumn(dt);
            nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", "."); return c; }).ToList();

            List<string> nnlist = dashBilancoSetMizanManager.GetAccountList();
            //   var tlista = nlist.Where(x => (x.CreditAmountFloat == x.AmountBakiyeFloat) && x.CreditAmountFloat == 0).ToList();

            nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain)).OrderBy(x => x.AccountMainID).ToList();

            //nlist = nlist.Except(tlista);
            List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
            cchklist = cchklist.GroupBy(i => i.AccountMainID)
                               .Select(g => g.First())
                               .ToList();

            List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 6).ToList();

            //cchklist = cchklist.OrderBy(x => x.AccountMainID).ToList();
            //cchklist1 = cchklist1.Where(x =>  (x.CreditAmountFloat == x.DebitAmountFloat )&&  x.CreditAmountFloat == 0).ToList();
            //cchklist = cchklist.Where(x =>  (x.CreditAmountFloat == x.DebitAmountFloat) && x.CreditAmountFloat == 0).ToList();
            var tlist = dataManager.SetBilancoFromListMizanExcel(cchklist, CompID, nYear, nmonth);
            foreach (var item in cchklist1)
            {
                try
                {
                    if (item.AmountBakiye != (DigitExtensions.ConvertDec(item.DebitAmount) - Math.Abs(DigitExtensions.ConvertDec(item.CreditAmount))).ToString("n2"))
                    {
                        item.AmountBakiye = (DigitExtensions.ConvertDec(item.DebitAmount) - Math.Abs(DigitExtensions.ConvertDec(item.CreditAmount))).ToString("n2");
                    }
                }
                catch (Exception ex)
                {

                    var chk = ex;
                }

            }

            dashBilancoSetMizanManager.Set_ReportSetResetMizanKayit(nYear, CompID);
            if (cchklist1.Count > 0)
            {
                var tlistsub = dataManager.SetBilancoFromListMizanExcelSub(cchklist1, CompID, nYear);
                dataManager.InsertDataMizanSub(tlistsub);
            }


            if (tlist.Count > 0)
            {
                dataManager.InsertDataMizan(tlist);
            }
            else
            {
                dataManager.SET_MIZANHEADER(nYear, CompID);
            }

            List<DashBilancoViewMizan> nRequestList1 = dashBilancoMizanManager.getList(nYear, CompID);
            var tlist1 = dataManager.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
            dataManager.RESET_DashBilancoViewMizan(nYear, CompID);
            dataManager.InsertBilncoMzn(tlist1);
            List<DashBilancoViewMizan> nRequestListRvn1 = dashGelirTablosuMizanManager.getList(nYear, CompID);
            var tlistRvn1 = dataManager.SetBilancoFromListMizan(nRequestListRvn1, CompID, nYear);
            dataManager.RESET_REVENUEViewMzn(nYear, CompID);
            dataManager.InsertRvnMzn(tlistRvn1);
            var WLikiditeViez = dashLikiditeViewMainMizanManager.getList(nYear, CompID);
            var WCapitalViez = dashWCapitalViewMainMizanManager.getList(nYear, CompID);
            var WCapitalVie = dataManager.SetBilancoFromListMizan(WCapitalViez, CompID, nYear);
            var WLikiditeVie = dataManager.SetBilancoFromListMizan(WLikiditeViez, CompID, nYear);
            dataManager.InsertWCapitalMzn(WCapitalVie);
            dataManager.InsertLiquidityMzn(WLikiditeVie);
            dashBilancoSetMizanManager.Set_ReportSetMainSMM(nYear, CompID);
            dashRasyoMizanManager.GetDashRasyoAnaliz(nYear, CompID);
            dashRasyoMizanManager.GetDashLikiditeRiskTrend(nYear, CompID);
            dashRasyoMizanManager.GetDashOzetMali(nYear, CompID);

        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = CompID;
            lg.CsvID = nYear;
            lg.ERLOG = ex.ToString();
            eRRLOGManager.Save_AppLogs(lg);
            return GenericResult<MoodUploadUpdateMznResponse>.Fail(ex.ToString());
        }

        return GenericResult<MoodUploadUpdateMznResponse>.Success(new MoodUploadUpdateMznResponse() { ResultText = new JsonResult("ok") });

    }
}