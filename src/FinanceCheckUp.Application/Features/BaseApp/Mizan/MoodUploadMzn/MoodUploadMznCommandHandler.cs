using FinanceCheckUp.Application.Common.Constants;
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

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMzn;

public class MoodUploadMznCommandHandler
    (
    ITBLMizanManager tBLMizanManager,
    IDashBilancoSetMizanManager dashBilancoSetMizanManager,
    IDataManager dataManager,
    IDashBilancoMizanManager dashBilancoMizanManager,
    IDashGelirTablosuMizanManager dashGelirTablosuMizanManager,
    IDashLikiditeViewMainMizanManager dashLikiditeViewMainMizanManager,
    IDashWCapitalViewMainMizanManager dashWCapitalViewMainMizanManager,
    IDashRasyoMizanManager dashRasyoMizanManager,
    IERRLOGManager eRRLOGManager
    ) : IRequestHandler<MoodUploadMznCommand, GenericResult<MoodUploadMznResponse>>
{

    public async Task<GenericResult<MoodUploadMznResponse>> Handle(MoodUploadMznCommand request, CancellationToken cancellationToken)
    {

        var file = request.XMlook.file;
        string filePath = string.Empty;
        List<string> nlistZipurl = new List<string>();
        string uploads = Path.Combine(AppConst.EnvironmentValue, AppConst.FileUploadPath);
        int nmonth = Convert.ToInt32(request.XMlook.Caption.Split('_')[0]);
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

        long CompID = Convert.ToInt64(request.XMlook.ide);
        int nYear = request.XMlook.id;
        try
        {
            Tblmizan ncs = new Tblmizan();
            ncs.CompanyId = CompID;
            ncs.CreatedDate = DateTime.Now;
            ncs.DocumentDate = new DateTime(nYear, 12, 12); ;
            ncs.CsvName = filePath;
            ncs.Year = nYear;
            ncs.MainMonth = nmonth;
            tBLMizanManager.Save_TBLMizan(ncs);

            DataTable dt = ExcelHelper.ExcelToDataTable(filePath);
            IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumn(dt);
            nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", ".").Trim(); return c; }).ToList();
            List<string> nnlist = dashBilancoSetMizanManager.GetAccountList();
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

            var tlist = dataManager.SetBilancoFromListMizanExcel(cchklist, CompID, nYear, nmonth);

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

            return GenericResult<MoodUploadMznResponse>.Success(new MoodUploadMznResponse() { ResultText = new JsonResult("ok") });
        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = CompID;
            lg.CsvID = nYear;
            lg.ERLOG = ex.ToString();
            eRRLOGManager.Save_AppLogs(lg);

            return GenericResult<MoodUploadMznResponse>.Fail(ex.ToString());
        }
    }
}