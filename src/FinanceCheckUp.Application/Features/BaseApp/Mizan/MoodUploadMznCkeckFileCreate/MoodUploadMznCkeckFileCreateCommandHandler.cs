using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Application.Dtos;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Client.ConnectApi;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Helper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.IO.Compression;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMznCkeckFileCreate;

public class MoodUploadMznCkeckFileCreateCommandHandle(
    IConnectApiClient connectApiClient,
    IOptions<AuthenticationSettings> authenticationSettings,
    ITBLMizanManager tBLMizanManager,
    IDashBilancoSetMizanManager dashBilancoSetMizanManager,
    IDataManager dataManager,
    IDashBilancoMizanManager dashBilancoMizanManager,
    IDashGelirTablosuMizanManager dashGelirTablosuMizanManager,
    IDashLikiditeViewMainMizanManager dashLikiditeViewMainMizanManager,
    IDashWCapitalViewMainMizanManager dashWCapitalViewMainMizanManager,
    IDashRasyoMizanManager dashRasyoMizanManager) : IRequestHandler<MoodUploadMznCkeckFileCreateCommand, GenericResult<MoodUploadMznCkeckFileCreateResponse>>
{
    private readonly AuthenticationSettings _authenticationSettings = authenticationSettings.Value;

    public async Task<GenericResult<MoodUploadMznCkeckFileCreateResponse>> Handle(MoodUploadMznCkeckFileCreateCommand request, CancellationToken cancellationToken)
    {

        string filePath = string.Empty;
        string folderPath = string.Empty;
        string folderPathsub = string.Empty;
        string filePathzet = string.Empty;
        var file = request.XMlook.file;
        List<string> nlistZipurl = new List<string>();
        Random rnd = new Random();
        int rndmonth = rnd.Next(10000000, 99999999);
        string uploads = Path.Combine(AppConst.EnvironmentValue, AppConst.FileUploadPath);
        byte nmonth = Convert.ToByte(request.XMlook.Caption.Split('_')[0]);

        long CompID = Convert.ToInt64(request.XMlook.ide);
        int nYear = request.XMlook.id; List<List<string>> pdfxcllista = new List<List<string>>();
        List<string> pdfxcllist = new List<string>();

        if (file != null && file.Count > 0)
        {
            foreach (var item in file)
            {
                filePath = System.IO.Path.Combine(uploads, rndmonth.ToString() + "-" + nYear.ToString() + System.IO.Path.GetExtension(item.FileName));
                folderPath = System.IO.Path.Combine(uploads, rndmonth.ToString() + "-" + nYear.ToString());
                folderPathsub = System.IO.Path.Combine(folderPath, "tables");
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                if (System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.Delete(folderPath);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                    System.IO.Directory.CreateDirectory(folderPathsub);
                }
                filePathzet = System.IO.Path.Combine(uploads, rndmonth.ToString() + "-" + nYear.ToString() + ".zip");
                if (System.IO.File.Exists(filePathzet))
                {
                    System.IO.File.Delete(filePathzet);
                }
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream).ConfigureAwait(false);
                }

            }

        }

        try
        {

            var result = await connectApiClient.UploadFile(_authenticationSettings.UserName, _authenticationSettings.Password, filePath, cancellationToken);
            var resulrret = await connectApiClient.GetFile(_authenticationSettings.UserName, _authenticationSettings.Password, rndmonth.ToString() + "-" + nYear.ToString() + ".zip", cancellationToken);
            var reminderAccount = JsonConvert.DeserializeObject<ReturnMainPdf>(resulrret);

            System.IO.File.WriteAllBytes(filePathzet, Convert.FromBase64String(reminderAccount.payload.ToString()));
            using (ZipArchive archive = ZipFile.OpenRead(filePathzet))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(System.IO.Path.Combine(folderPath, entry.FullName));
                }
            }

            string[] files = Directory.GetFiles(folderPath, "*.xlsx", SearchOption.AllDirectories);

            Tblmizan ncs = new Tblmizan();
            ncs.CompanyId = CompID;
            ncs.CreatedDate = DateTime.Now;
            ncs.DocumentDate = new DateTime(nYear, nmonth, 12);
            ncs.CsvName = filePath;
            ncs.Year = nYear;
            ncs.MainMonth = nmonth;
            ncs.Id = tBLMizanManager.Save_TBLMizan(ncs);

            dashBilancoSetMizanManager.Set_ReportSetResetMizanKayit(nYear, CompID);
            dashBilancoSetMizanManager.Set_ReportSetResetMizanKayitMOnth(nYear, CompID, nmonth);

            foreach (var itemz in files)
            {

                DataTable dt = ExcelHelper.ExcelToDataTable(itemz);
                IEnumerable<XmlExcel> nlist = ExcelHelper.CheckColumnPdfExcel(dt);
                nlist = nlist.Select(c => { c.AccountMainID = c.AccountMainID.Replace(",", ".").Replace("-", ".").Replace("_", "."); return c; }).ToList();

                List<string> nnlist = dashBilancoSetMizanManager.GetAccountList();

                nlist = nlist.Where(x => nnlist.Contains(x.AccountMainIDMain)).OrderBy(x => x.AccountMainID).ToList();

                List<XmlExcel> cchklist = nlist.Where(x => x.TextCount == 3).ToList();
                cchklist = cchklist.GroupBy(i => i.AccountMainID)
                                   .Select(g => g.First())
                                   .ToList();

                List<XmlExcel> cchklist1 = nlist.Where(x => x.TextCount >= 6).ToList();

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
                    //dataManager.SET_MIZANHEADER(nYear, CompID);
                }



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
            return GenericResult<MoodUploadMznCkeckFileCreateResponse>.Fail("nok " + ex.ToString());
        }

        return GenericResult<MoodUploadMznCkeckFileCreateResponse>.Success(new MoodUploadMznCkeckFileCreateResponse() { ResultText = new JsonResult("ok") });
    }

}