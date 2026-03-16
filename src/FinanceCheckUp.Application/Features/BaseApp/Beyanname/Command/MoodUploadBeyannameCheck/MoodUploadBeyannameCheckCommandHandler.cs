using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadBeyannameCheck;

public class MoodUploadBeyannameCheckCommandHandle(
    IBeyannameChkManager beyannameChkManager,
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companiesManager,
    IFileOperationService fileOperationService,
    IERRLOGManager eRRLOGManager,
    ITBLMizanManager tBLMizanManager) : IRequestHandler<MoodUploadBeyannameCheckCommand, GenericResult<BeyannameMoodUploadCheckResponse>>
{

    public async Task<GenericResult<BeyannameMoodUploadCheckResponse>> Handle(MoodUploadBeyannameCheckCommand request, CancellationToken cancellationToken)
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
            //for (int page = 1; page <= reader.NumberOfPages; page++)
            //{
            //    text  = PdfTextExtractor.GetTextFromPage(reader, page);
            //    nlist.Add(text);
            //}
            //reader.Close();
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
                return GenericResult<BeyannameMoodUploadCheckResponse>.Fail("nok_Hatalı PDF Yükleme - KURUMLAR VERGİSİ BEYANNAMESİ - GEÇİCİ VERGİ BEYANNAMESİ - YILLIK GELİR VERGİSİ BEYANNAMESİ Olmalı");
            }

            if (chhhkt != null)
            {
                ISGeciciVergi = true;
            }

            ReadPdfPg chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yıl ")).FirstOrDefault();
            string txt1Yil = string.Empty;
            string chkyil1 = string.Empty;
            string chkyil3 = string.Empty;

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
            ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
            string vergino = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault().LineContent;



            if (ISNoAdmin)
            {
                if (vergino.Trim() != mainComp.TaxId.Trim())
                {
                    eRRLOGManager.Save_AppLogs(new ERRLOG
                    {
                        CompanyID = CompID,
                        CsvID = nYear,
                        ERLOG = "Hatalı Vergi No  "
                    });
                    return GenericResult<BeyannameMoodUploadCheckResponse>.Fail("nok_Hatalı Vergi No");
                }
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
                            ERLOG = "Hatalı Yıl  "
                        });
                        return GenericResult<BeyannameMoodUploadCheckResponse>.Fail("nok_Hatalı Yıl  ");
                    }

                }
            }

            //if (TBLMizan.DeleteComapnyCountMizanByn(CompID, nYear) > 3)
            //{
            //    //ERRLOG lg = new ERRLOG();
            //    //lg.CompanyID = CompID;
            //    //lg.CsvID = nYear;
            //    //lg.ERLOG = "_Yalnızca Kapalı Mizanlarda Beyanname Yüklenebilir  "; lg.Save_AppLogs();
            //    //return Json("nok_Yalnızca Kapalı Mizanlarda Beyanname Yüklenebilir");
            //}

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

            //var chkkGrp2 = mizanResultManager.Get_MizanResult();
            //var tt = CHKgROUP.Where(x => chkkGrp2.Any(z => x.LineContent.Trim().Replace(" ", string.Empty).Contains(z.MainDescription.Trim().Replace(" ", string.Empty))));
            var chkssst = nliste;


            nliste.Select(c => { c.IsGecici = 0; return c; }).ToList();
            //TBLMizan.DeleteComapnyCountMizanByn(CompID, nYear);
            BeyannameChk btnchk = new BeyannameChk();
            beyannameChkManager.DeleteChk(CompID, nYear);
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
                    btnchk.ID = beyannameChkManager.Save_BeyannameChk(btnchk);
                    Thread.Sleep(50);
                }
            }
            else
            {
                foreach (var item in nliste.Where(x => x.IsRevenue == 1))
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
                    btnchk.ID = beyannameChkManager.Save_BeyannameChk(btnchk);
                    Thread.Sleep(50);
                }

            }

            beyannameChkManager.DeleteLastChk(CompID, nYear);
            var chkkGrplst = beyannameChkManager.Get_BeyannameResultLstChk(CompID, nYear);

            foreach (var item in chkkGrplst)
            {
                beyannameChkManager.LastSetChk(item.ID);
            }
            beyannameChkManager.LastFinishedChk(CompID, nYear, nmonth);
            var chk = CHKgROUP;

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
            return GenericResult<BeyannameMoodUploadCheckResponse>.Fail(ex.ToString());
        }


        return GenericResult<BeyannameMoodUploadCheckResponse>.Success(new BeyannameMoodUploadCheckResponse { ResponseText = new JsonResult("ok") });
    }
}

