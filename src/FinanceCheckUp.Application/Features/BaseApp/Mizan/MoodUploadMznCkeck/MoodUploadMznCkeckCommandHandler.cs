using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Helper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMznCkeck;

public class MoodUploadMznCkeckCommandHandler
     (
    ITBLMizanManager tBLMizanManager,
    IDashBilancoSetMizanManager dashBilancoSetMizanManager,
    IERRLOGManager eRRLOGManager
    ) : IRequestHandler<MoodUploadMznCkeckCommand, GenericResult<MoodUploadMznCkeckResponse>>
{


    public async Task<GenericResult<MoodUploadMznCkeckResponse>> Handle(MoodUploadMznCkeckCommand request, CancellationToken cancellationToken)
    {

        var file = request.XMlook.file;
        string filePath = string.Empty;
        List<string> nlistZipurl = new List<string>();
        string uploads = Path.Combine(AppConst.EnvironmentValue, AppConst.FileUploadPath);

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
            tBLMizanManager.Save_TBLMizan(ncs);

            DataTable dt = ExcelHelper.ExcelToDataTable(filePath);
            IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumn(dt);
            nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", "."); return c; }).ToList();
            List<string> nnlist = dashBilancoSetMizanManager.GetAccountList();
            List<string> nnlistsix = dashBilancoSetMizanManager.GetAccountListSix();
            nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain));
            List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
            List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 6).ToList();

            int fcount = cchklist.Where(x => x.CreditAmountFloat == 0).Count();

            int tcount = cchklist.Where(x => x.DebitAmountFloat == 0).Count();
            int chkcount = cchklist.Count();

            if (chkcount == tcount && chkcount > 1)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = "Mizan Şablon Hatası";
                eRRLOGManager.Save_AppLogs(lg);
                return GenericResult<MoodUploadMznCkeckResponse>.Fail("lock");
            }

            if (chkcount == fcount && chkcount > 1)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = CompID;
                lg.CsvID = nYear;
                lg.ERLOG = "Mizan Şablon Hatası";
                eRRLOGManager.Save_AppLogs(lg);
                return GenericResult<MoodUploadMznCkeckResponse>.Fail("lock");
            }
            List<string> nnlistcheck = cchklist.Where(x => nnlistsix.Contains(x.AccountMainID) && x.AmountBakiye != "0").Select(x => x.AccountMainID).ToList();
            if (nnlistcheck.Count < 4 && chkcount > 1)
            {
                List<string> mslist = new List<string>() { "690", "691", "692" };
                List<string> ttchek = nnlistcheck.Except(mslist).ToList();

                if (ttchek.Count < 1)
                {
                    ERRLOG lg = new ERRLOG();
                    lg.CompanyID = CompID;
                    lg.CsvID = nYear;
                    lg.ERLOG = "Kesin Mizan Hatası";
                    eRRLOGManager.Save_AppLogs(lg);
                    return GenericResult<MoodUploadMznCkeckResponse>.Fail("nok");
                }
            }
        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = CompID;
            lg.CsvID = nYear;
            lg.ERLOG = ex.ToString();
            eRRLOGManager.Save_AppLogs(lg);
            return GenericResult<MoodUploadMznCkeckResponse>.Fail("nok");
        }




        return GenericResult<MoodUploadMznCkeckResponse>.Success(new MoodUploadMznCkeckResponse() { ResultText = new JsonResult("ok") }); ;
    }
}