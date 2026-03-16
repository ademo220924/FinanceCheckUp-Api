using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadBeyannameCreate;

public class MoodUploadBeyannameCreateCommandHandle(
    IBeyannameChkManager beyannameChkManager,
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companiesManager,
    IFileOperationService fileOperationService,
    IERRLOGManager eRRLOGManager,
    ITBLMizanManager tBLMizanManager,
    IDashBilancoBeyanManager dashBilancoBeyanManager,
    IDataManager dataManager,
    IDashGelirTablosuMizanManager dashGelirTablosuMizanManager,
    IDashLikiditeViewMainMizanManager dashLikiditeViewMainMizanManager,
    IDashWCapitalViewMainMizanManager dashWCapitalViewMainMizanManager,
    IDashBilancoSetMizanManager dashBilancoSetMizanManager,
    IDashRasyoMizanManager dashRasyoMizanManager,
    IDashRasyoManager dashRasyoManager) : IRequestHandler<MoodUploadBeyannameCreateCommand, GenericResult<BeyannameMoodUploadCreateResponse>>
{


    public async Task<GenericResult<BeyannameMoodUploadCreateResponse>> Handle(MoodUploadBeyannameCreateCommand request, CancellationToken cancellationToken)
    {
        bool ISNoAdmin = true;
        var currentUser = int.Parse(request.UserId);
        var isusrAdmn = hhvnUsersManager.GetRow_User(currentUser);
        if (isusrAdmn.UserTypeID == 1001)
        {
            ISNoAdmin = false;
        }
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

            Domain.Entities.Company mainComp = companiesManager.Get_Company(CompID);
            bool ISGeciciVergi = false;



            var CHKgROUP = (await fileOperationService.ReadPdfFileAsync(filePath, cancellationToken))!.Data.ToList();
            string checkvalt = string.Empty;
            string checkval = string.Empty;
            string checkval1 = string.Empty;
            List<ReadPdfPg> nliste = new List<ReadPdfPg>();
            List<ReadPdfPg> nliste1 = new List<ReadPdfPg>();
            bool chekSource = false;
            bool chekSource1 = false;


            ReadPdfPg chhhk = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Contains("KURUMLAR VERGISI BEYANNAMES")).FirstOrDefault();
            ReadPdfPg chhhkt = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Replace("Ç", "C").Contains("GECICI VERGI BEYANNAMES")).FirstOrDefault();
            ReadPdfPg chhhkt1 = CHKgROUP.Where(x => x.LineContent.Replace("İ", "I").Contains("YILLIK GELIR VERGISI BEYANNAMES")).FirstOrDefault();

            if (chhhk == null && chhhkt == null && chhhkt1 == null)
            {
                eRRLOGManager.Save_AppLogs(new ERRLOG
                {
                    CompanyID = CompID,
                    CsvID = nYear,
                    ERLOG = "Hatalı PDF Yükleme  -KURUMLAR VERGİSİ BEYANNAMESİ -GEÇİCİ VERGİ BEYANNAMESİ-YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı "
                });
                return GenericResult<BeyannameMoodUploadCreateResponse>.Fail("Hatalı PDF Yükleme - KURUMLAR VERGİSİ BEYANNAMESİ - GEÇİCİ VERGİ BEYANNAMESİ - YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı");

            }

            if (chhhkt != null)
            {
                eRRLOGManager.Save_AppLogs(new ERRLOG
                {
                    CompanyID = CompID,
                    CsvID = nYear,
                    ERLOG = "Hatalı PDF Yükleme - Yalnızca  KURUMLAR VERGİSİ BEYANNAMESİ Bu alandan Yüklenebilir"
                });
                return GenericResult<BeyannameMoodUploadCreateResponse>.Fail("Hatalı PDF Yükleme - Yalnızca  KURUMLAR VERGİSİ BEYANNAMESİ Bu alandan Yüklenebilir");
            }

            ReadPdfPg chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yıl ")).FirstOrDefault();
            ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
            string vergino = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault().LineContent;
            string txt1Yil = chhhk1.LineContent.Split(' ')[1].Trim();

            string chkyil1 = string.Empty;
            string chkyil3 = string.Empty;
            if (ISNoAdmin)
            {
                if (vergino.Trim() != mainComp.TaxId.Trim())
                {
                    eRRLOGManager.Save_AppLogs(new ERRLOG
                    {
                        CompanyID = CompID,
                        CsvID = nYear,
                        ERLOG = "Hatalı Vergi No"
                    });
                    return GenericResult<BeyannameMoodUploadCreateResponse>.Fail("Hatalı Vergi No");
                }
            }


            if (ISGeciciVergi)
            {
                chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yılı")).FirstOrDefault();
                var chhhkyilt = CHKgROUP.Where(x => x.CounterNo == chhhk1.CounterNo + 2).FirstOrDefault();
                chkyil1 = chhhkyilt.LineContent.Trim();
                chkyil3 = chhhk1.LineContent.Split(' ')[chhhk1.LineContent.Split(' ').Length - 1].Trim();
                var chhhk1yy = CHKgROUP.Where(x => x.LineContent.Contains("Onay Zamanı ")).FirstOrDefault();
                txt1Yil = chhhk1yy.LineContent.Replace("Onay Zamanı", string.Empty).Replace(":", string.Empty).Split('-')[0].Trim().Split('.')[2];
            }
            else
            {
                txt1Yil = chhhk1.LineContent.Split(' ')[1].Trim();
            }


            if (chkyil1 != nYear.ToString())
            {
                if (chkyil3 != nYear.ToString())
                {

                    if (Convert.ToInt32(txt1Yil) != nYear)
                    {
                        eRRLOGManager.Save_AppLogs(new ERRLOG
                        {
                            CompanyID = CompID,
                            CsvID = nYear,
                            ERLOG = "Hatalı Yıl"
                        });
                        return GenericResult<BeyannameMoodUploadCreateResponse>.Fail("Hatalı Yıl");
                    }

                }
            }


            Tblmizan ncs = new Tblmizan
            {
                CompanyId = CompID,
                CreatedDate = DateTime.Now,
                DocumentDate = new DateTime(nYear, 12, 12),
                CsvName = filePath,
                Year = nYear,
                MainMonth = nmonth
            };
            ncs.Id = tBLMizanManager.Save_TBLMizan(ncs);

            CHKgROUP = CHKgROUP.Where(x => x.LineContent.Length > 11).ToList();

            for (int i = 0; i < CHKgROUP.Count; i++)
            {

                if (CHKgROUP[i].LineContent.Contains("Dönen Varlıklar"))
                {
                    checkvalt = "I";
                    chekSource = true;
                }

                if (CHKgROUP[i].LineContent.Contains("PASİF TOPLAMI"))
                {
                    CHKgROUP[i].MainID = "I";
                    CHKgROUP[i].SubID = "PASİF TOPLAMI";
                    nliste.Add(CHKgROUP[i]);
                    chekSource = false;
                }


                if (chekSource)
                {
                    checkval = CHKgROUP[i].LineContent.Length > 1 ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                    if (!DigitExtensions.IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU"))
                    {

                        checkval1 = checkval;

                    }


                    CHKgROUP[i].SubID = checkval1;
                    if (CHKgROUP[i].LineContent.Contains("AKTİF TOPLAMI") || CHKgROUP[i].LineContent.Contains("II") || CHKgROUP[i].LineContent.Contains("III") || CHKgROUP[i].LineContent.Contains("IV") || CHKgROUP[i].LineContent.Contains("V."))
                    {
                        if (CHKgROUP[i].LineContent.Contains("III"))
                        {
                            checkvalt = "III";
                        }
                        else if (CHKgROUP[i].LineContent.Contains("II"))
                        {
                            checkvalt = "II";
                        }
                        else if (CHKgROUP[i].LineContent.Contains("IV"))
                        {
                            checkvalt = "IV";
                        }
                        else if (CHKgROUP[i].LineContent.Contains("V"))
                        {
                            checkvalt = "V";
                        }

                        CHKgROUP[i].SubID = BeyannameChkGecici.RemoveEmpty(CHKgROUP[i].LineContent);
                    }
                    CHKgROUP[i].MainID = checkvalt;
                    nliste.Add(CHKgROUP[i]);
                }

                if (ISGeciciVergi)
                {
                    if (CHKgROUP[i].LineContent != null && CHKgROUP[i].LineContent.Contains("GELİR TABLOSU"))
                    {

                        chekSource1 = true;
                    }
                }
                else
                {
                    if ((CHKgROUP[i].LineContent != null && CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && (CHKgROUP[i].LineContent.Trim().Length > 23) == false))
                    {

                        chekSource1 = true;
                    }
                }


                if (!ISGeciciVergi)
                {
                    if (CHKgROUP[i].LineContent.Contains("Dönem Net Karı veya Zararı"))
                    {
                        CHKgROUP[i].MainID = "Z";
                        CHKgROUP[i].SubID = "D";
                        CHKgROUP[i].IsRevenue = 1;
                        nliste.Add(CHKgROUP[i]);
                        chekSource1 = false;
                    }
                }



                if (chekSource1)
                {
                    checkval = CHKgROUP[i].LineContent.Length > 1 ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                    if (!DigitExtensions.IsNumeric(checkval) && !CHKgROUP[i].LineContent.Contains("GELİR TABLOSU"))
                    {
                        checkval1 = checkval;
                    }
                    CHKgROUP[i].MainID = "Z";
                    CHKgROUP[i].SubID = checkval1;
                    CHKgROUP[i].IsRevenue = 1;
                    nliste.Add(CHKgROUP[i]);
                }

            }
            var chkssst = nliste;

            nliste.Select(c => { c.IsGecici = 0; return c; }).ToList();

            BeyannameChk btnchk = new BeyannameChk();
            beyannameChkManager.Delete(CompID, nYear);
            if (ISGeciciVergi)
            {
                nliste.Select(c => { c.IsGecici = 1; return c; }).ToList();
                foreach (var item in nliste)
                {
                    btnchk = new BeyannameChk
                    {
                        IsGecici = item.IsGecici,
                        AccountMainDescriptionChk = item.LineContent,
                        CompanyID = CompID,
                        IsRevenue = item.IsRevenue,
                        SubID = item.SubID,
                        MainID = item.MainID,
                        Year = nYear
                    };
                    btnchk.ID = beyannameChkManager.Save_Beyanname(btnchk);
                    Thread.Sleep(50);
                }
            }
            else
            {
                foreach (var item in nliste)
                {
                    btnchk = new BeyannameChk
                    {
                        AccountMainDescriptionChk = item.LineContent,
                        CompanyID = CompID,
                        IsRevenue = item.IsRevenue,
                        SubID = item.SubID,
                        MainID = item.MainID,
                        Year = nYear
                    };
                    btnchk.ID = beyannameChkManager.Save_Beyanname(btnchk);
                    Thread.Sleep(50);
                }

            }
            beyannameChkManager.DeleteLast(CompID, nYear);
            var chkkGrplst = beyannameChkManager.Get_BeyannameResultLst(CompID, nYear);

            foreach (var item in chkkGrplst)
            {
                beyannameChkManager.LastSet(item.ID);
            }
            beyannameChkManager.LastFinished(CompID, nYear, nmonth);
            var chk = CHKgROUP;


            if (!ISGeciciVergi)
            {
                List<DashBilancoViewMizan> nRequestList1 = dashBilancoBeyanManager.getList(nYear, CompID);
                var tlist1 = dataManager.SetBilancoFromListMizan(nRequestList1, CompID, nYear);
                dataManager.RESET_DashBilancoViewMizan(nYear, CompID);
                dataManager.InsertBilncoMzn(tlist1);
            }

            List<DashBilancoViewMizan> nRequestListRvn1 = dashGelirTablosuMizanManager.getListBYN(nYear, CompID);
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
            dashRasyoManager.GetDashRasyoAnaliz(nYear, CompID);
            dashRasyoManager.GetDashLikiditeRiskTrend(nYear, CompID);
            dashRasyoMizanManager.GetDashOzetMali(nYear, CompID);
            //DashOzetMaliMizan.OzetMali9(nYear, CompID);


            if (!ISGeciciVergi)
            {
                List<DashBilancoViewMizan> nRequestList1a = dashBilancoBeyanManager.getList(nYear - 1, CompID);
                if (nRequestList1a.Count < 1)
                {
                    return GenericResult<BeyannameMoodUploadCreateResponse>.Success(new BeyannameMoodUploadCreateResponse { ResponseText = new JsonResult("ok") });

                }
                var tlist1a = dataManager.SetBilancoFromListMizan(nRequestList1a, CompID, nYear - 1);
                dataManager.RESET_DashBilancoViewMizan(nYear - 1, CompID);
                dataManager.InsertBilncoMzn(tlist1a);

                List<DashBilancoViewMizan> nRequestListRvn1a = dashGelirTablosuMizanManager.getListBYN(nYear - 1, CompID);
                var tlistRvn1a = dataManager.SetBilancoFromListMizan(nRequestListRvn1a, CompID, nYear - 1);
                dataManager.RESET_REVENUEViewMzn(nYear - 1, CompID);
                dataManager.InsertRvnMzn(tlistRvn1a);
                var WLikiditeVieza = dashLikiditeViewMainMizanManager.getList(nYear - 1, CompID);
                var WCapitalVieza = dashWCapitalViewMainMizanManager.getList(nYear - 1, CompID);
                var WCapitalViea = dataManager.SetBilancoFromListMizan(WCapitalVieza, CompID, nYear - 1);
                var WLikiditeViea = dataManager.SetBilancoFromListMizan(WLikiditeVieza, CompID, nYear - 1);

                if (WCapitalViea.Count > 0)
                {
                    dataManager.InsertWCapitalMzn(WCapitalViea);
                    dataManager.InsertLiquidityMzn(WLikiditeViea);
                    dashBilancoSetMizanManager.Set_ReportSetMainSMM(nYear - 1, CompID);
                    dashRasyoManager.GetDashRasyoAnaliz(nYear - 1, CompID);
                    dashRasyoManager.GetDashLikiditeRiskTrend(nYear - 1, CompID);
                    dashRasyoMizanManager.GetDashOzetMali(nYear - 1, (int)CompID);
                }
            }
        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG
            {
                CompanyID = CompID,
                CsvID = nYear,
                ERLOG = ex.ToString()
            };
            lg.ID = eRRLOGManager.Save_AppLogs(lg);
            return GenericResult<BeyannameMoodUploadCreateResponse>.Fail(ex.ToString());

        }
        return GenericResult<BeyannameMoodUploadCreateResponse>.Success(new BeyannameMoodUploadCreateResponse { ResponseText = new JsonResult("ok") });
    }

}
