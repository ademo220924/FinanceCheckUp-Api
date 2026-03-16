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
using FinanceCheckUp.Framework.Data;
using fincheckup.Helper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.IO.Compression;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMznCkeckFileUpdate;

public class MoodUploadMznCkeckFileUpdateCommandHandler
    (
    IConnectApiClient connectApiClient,
    IOptions<AuthenticationSettings> authenticationSettings,
    IGenericRepository<Tblmizan, long> tblMizanRepository,
    IMizanSqlOperationManager mizanSqlOperationManager,
    IDashBilancoSetMizanManager dashBilancoSetMizanManager,
    IDataManager dataManager,
    IDashBilancoMizanManager dashBilancoMizanManager,
    IDashGelirTablosuMizanManager dashGelirTablosuMizanManager,
    IDashLikiditeViewMainMizanManager dashLikiditeViewMainMizanManager,
    IDashWCapitalViewMainMizanManager dashWCapitalViewMainMizanManager,
    IDashRasyoMizanManager dashRasyoMizanManager
    ) : IRequestHandler<MoodUploadMznCkeckFileUpdateCommand, GenericResult<MoodUploadMznCkeckFileUpdateResponse>>
{
    private readonly AuthenticationSettings _authenticationSettings = authenticationSettings.Value;
    private readonly IGenericRepository<Tblmizan, long> _tblMizanRepository = tblMizanRepository;
    private readonly IMizanSqlOperationManager _mizanSqlOperationManager = mizanSqlOperationManager;

    public async Task<GenericResult<MoodUploadMznCkeckFileUpdateResponse>> Handle(MoodUploadMznCkeckFileUpdateCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.XMlook;
        var CompID = Convert.ToInt64(pageIndex.ide);
        var file = pageIndex.file;
        var filePath = string.Empty;
        var folderPath = string.Empty;
        var folderPathsub = string.Empty;
        var filePathzet = string.Empty;
        var nlistZipurl = new List<string>();
        var uploads = Path.Combine($"{Directory.GetCurrentDirectory()}/UploadFiles", "Documents"); ;
        var nmonth = Convert.ToByte(pageIndex.Caption.Split('_')[0]);
        var rnd = new Random();
        var month = rnd.Next(10000000, 99999999);
        var nYear = pageIndex.id;


        if (file != null && file.Count > 0)
        {
            foreach (var item in file)
            {
                filePath = System.IO.Path.Combine(uploads, month.ToString() + "-" + nYear.ToString() + System.IO.Path.GetExtension(item.FileName));
                folderPath = System.IO.Path.Combine(uploads, month.ToString() + "-" + nYear.ToString());
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
                filePathzet = System.IO.Path.Combine(uploads, month.ToString() + "-" + nYear.ToString() + ".zip");
                if (System.IO.File.Exists(filePathzet))
                {
                    System.IO.File.Delete(filePathzet);
                }
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
                }

            }

        }

        try
        {
            var result = await connectApiClient.UploadFile(_authenticationSettings.UserName, _authenticationSettings.Password, filePath, cancellationToken);
            var resulrret = await connectApiClient.GetFile(_authenticationSettings.UserName, _authenticationSettings.Password, month + "-" + nYear + ".zip", cancellationToken);
            var reminderAccount = JsonConvert.DeserializeObject<ReturnMainPdf>(resulrret);

            await System.IO.File.WriteAllBytesAsync(filePathzet, Convert.FromBase64String(reminderAccount.payload.ToString()), cancellationToken);
            using var archive = ZipFile.OpenRead(filePathzet);
            foreach (var entry in archive.Entries)
            {
                entry.ExtractToFile(Path.Combine(folderPath, entry.FullName));
            }

            var files = Directory.GetFiles(folderPath, "*.xlsx", SearchOption.AllDirectories);
            var ncs = new Tblmizan
            {
                CompanyId = CompID,
                CreatedDate = DateTime.Now,
                DocumentDate = new DateTime(nYear, nmonth, 12),
                CsvName = filePath,
                Year = nYear,
                MainMonth = nmonth
            };

            await _tblMizanRepository.AddAsync(ncs, cancellationToken);
            _mizanSqlOperationManager.Set_ReportSetResetMizanKayit(nYear, CompID);
            _mizanSqlOperationManager.Set_ReportSetResetMizanKayitMOnth(nYear, CompID, nmonth);

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
                    //Data.SET_MIZANHEADER(nYear, CompID);
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

            return GenericResult<MoodUploadMznCkeckFileUpdateResponse>.Success(new MoodUploadMznCkeckFileUpdateResponse() { ResultText = new JsonResult("ok") });
        }
        catch (Exception ex)
        {
            return GenericResult<MoodUploadMznCkeckFileUpdateResponse>.Fail("nok " + ex.ToString());
        }
    }
}