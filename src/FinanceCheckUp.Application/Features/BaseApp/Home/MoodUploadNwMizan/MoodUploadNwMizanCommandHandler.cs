using System.Data;
using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.ExtensionHelpers;
using fincheckup.Helper;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadNwMizan;

public class MoodUploadNwMizanCommandHandler(
    ITBLXmlManager tblXmlManager,
    IDashBilancoSetMizanManager dashBilancoSetMizanManager,
    IDataManager dataManager,
    IDashBilancoMizanManager dashBilancoMizanManager,
    IDashGelirTablosuMizanManager dashGelirTablosuMizanManager,
    IDashLikiditeViewMainMizanManager dashLikiditeViewMainMizanManager,
    IDashWCapitalViewMainMizanManager dashWCapitalViewMainMizanManager,
    IDashRasyoMizanManager dashRasyoMizanManager,
    IERRLOGManager errlogManager)
    : IRequestHandler<MoodUploadNwMizanCommand, GenericResult<MoodUploadNwMizanResponse>>
{
    public async Task<GenericResult<MoodUploadNwMizanResponse>> Handle(MoodUploadNwMizanCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUploadNwMizanRequest.PageIndex;
        string filemonth = pageIndex.Caption.Split('_')[0];
        string fileyear = pageIndex.Caption.Split('_')[1];
        var file = pageIndex.file;
        string filePath = string.Empty;
        string uploads = Path.Combine(WebHelper.path, "wwwroot\\FileContent\\");
        int monID = Convert.ToInt32(filemonth);
        long compId = Convert.ToInt64(pageIndex.ide);
        int nYear = Convert.ToInt32(fileyear);

        if (file != null && file.Count > 0)
        {
            foreach (var item in file)
            {
                filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + Path.GetExtension(item.FileName));
                await using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        try
        {
            var ncs = new Tblxml
            {
                CompanyId = compId,
                CreatedDate = DateTime.Now,
                DocumentDate = new DateTime(nYear, monID, 21),
                CsvName = filePath,
                Year = nYear,
                XmlDocName = file[0].FileName
            };
            tblXmlManager.Save_TBLXml(ncs);

            DataTable dt = ExcelHelper.ExcelToDataTable(filePath);
            IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumn(dt);
            nlist = nlist.Select(c =>
            {
                c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", ".").Trim();
                return c;
            }).ToList();
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
                catch (Exception)
                {
                    // preserved
                }
            }

            var tlist = dataManager.SetBilancoFromListMizanExcelNew(cchklist, compId, nYear);

            if (cchklist1.Count > 0)
            {
                var tlistsub = dataManager.SetBilancoFromListMizanExcelSub(cchklist1, compId, nYear);
                dataManager.InsertDataMizanSub(tlistsub);
            }

            if (tlist.Count > 0)
            {
                foreach (XmlExcel us in tlist)
                {
                    us.MainMonth = monID;
                    us.CsvId = ncs.Id;
                }

                dataManager.InsertDataMizanNew(tlist);
            }
            else
            {
                dataManager.SET_MIZANHEADER(nYear, compId);
            }

            dataManager.SetHataLast(ncs.Id);
            dataManager.SetHataLastz(ncs.Id);
            dataManager.SetHataLastza(compId, nYear);

            List<DashBilancoViewMizan> nRequestList1 = dashBilancoMizanManager.getList(nYear, compId);
            var tlist1 = dataManager.SetBilancoFromListMizan(nRequestList1, compId, nYear);
            dataManager.RESET_DashBilancoViewMizan(nYear, compId);
            dataManager.InsertBilncoMzn(tlist1);
            List<DashBilancoViewMizan> nRequestListRvn1 = dashGelirTablosuMizanManager.getList(nYear, compId);
            var tlistRvn1 = dataManager.SetBilancoFromListMizan(nRequestListRvn1, compId, nYear);
            dataManager.RESET_REVENUEViewMzn(nYear, compId);
            dataManager.InsertRvnMzn(tlistRvn1);
            var wLikiditeViez = dashLikiditeViewMainMizanManager.getList(nYear, compId);
            var wCapitalViez = dashWCapitalViewMainMizanManager.getList(nYear, compId);
            var wCapitalVie = dataManager.SetBilancoFromListMizan(wCapitalViez, compId, nYear);
            var wLikiditeVie = dataManager.SetBilancoFromListMizan(wLikiditeViez, compId, nYear);
            dataManager.InsertWCapitalMzn(wCapitalVie);
            dataManager.InsertLiquidityMzn(wLikiditeVie);
            dashBilancoSetMizanManager.Set_ReportSetMainSMM(nYear, compId);
            dashRasyoMizanManager.GetDashRasyoAnaliz(nYear, compId);
            dashRasyoMizanManager.GetDashLikiditeRiskTrend(nYear, compId);
            dashRasyoMizanManager.GetDashOzetMali(nYear, compId);

            return GenericResult<MoodUploadNwMizanResponse>.Success(
                new MoodUploadNwMizanResponse { ResultText = new JsonResult("ok") });
        }
        catch (Exception ex)
        {
            errlogManager.Save_AppLogs(new ERRLOG
            {
                CompanyID = compId,
                CsvID = nYear,
                ERLOG = ex.ToString()
            });
            return GenericResult<MoodUploadNwMizanResponse>.Success(
                new MoodUploadNwMizanResponse { ResultText = new JsonResult(ex.ToString()) });
        }
    }
}
