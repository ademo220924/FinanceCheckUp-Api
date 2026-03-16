using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadCreate;

public class MoodUploadCreateCommandHandle(
    ICompanyManager companiesManager,
    IFileOperationService fileOperationService,
    IERRLOGManager eRRLOGManager,
    IDataManager dataManager,
    IDashRasyoManager dashRasyoManager,
    IBeyannameChkGeciciManager beyannameChkGeciciManager,
    ITBLXmlManager tBLXmlManager,
    IDatazRepository datazRepository,
    IDashGelirTablosuViewMainManager dashGelirTablosuViewMainManager,
    IDashWCapitalViewMainManager dashWCapitalViewMainManager,
    IDashLikiditeViewMainManager dashLikiditeViewMainManager
    ) : IRequestHandler<MoodUploadCreateCommand, GenericResult<MoodUploadCreateResponse>>
{


    public async Task<GenericResult<MoodUploadCreateResponse>> Handle(MoodUploadCreateCommand request, CancellationToken cancellationToken)
    {

        //var file = request.XMlook.file;
        //    string filemonth = request.XMlook.Caption.Split('_')[0];
        //    string fileyear = request.XMlook.Caption.Split('_')[1];
        //    string filePath = string.Empty;
        //    string uploads = Path.Combine(AppConst.EnvironmentValue, AppConst.FileUploadPath);

        //var query = $"SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.Id  where  Company.Id={request.XMlook.ide}";
        //var response=  companyRepository.QueryOfList<Domain.Entities.Company>(query);

        var file = request.XMlook.file;
        string filemonth = request.XMlook.Caption.Split('_')[0];
        string fileyear = request.XMlook.Caption.Split('_')[1];
        string filePath = string.Empty;
        string uploads = Path.Combine(AppConst.EnvironmentValue, AppConst.FileUploadPath);

        Domain.Entities.Company comp = companiesManager.Get_Company(Convert.ToInt32(request.XMlook.ide));

        string checkvalt = string.Empty;
        string checkval = string.Empty;
        string checkval1 = string.Empty;
        bool chekSource = false;
        bool chekSource1 = false;
        if (file == null || file.Count==0)
        {
            return GenericResult<MoodUploadCreateResponse>.Fail("nok");
        }
       

        string pathToXmlFile = string.Empty;



        foreach (var item in file)
        {
            filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".pdf");
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await item.CopyToAsync(fileStream).ConfigureAwait(false);
            }
        }
        pathToXmlFile = filePath;




        long CompID = Convert.ToInt64(request.XMlook.ide);
        int nYear = Convert.ToInt32(fileyear);

        int nMonth = Convert.ToInt32(filemonth);

        DateTime docDate = new DateTime(nYear, nMonth, 1);

        try
        {

            var CHKgROUP = (await fileOperationService.ReadPdfFileAsync(filePath, cancellationToken))!.Data.ToList();



            List<ReadPdfPg> nliste = new List<ReadPdfPg>();
            List<ReadPdfPg> nliste1 = new List<ReadPdfPg>();



            ReadPdfPg chhhkt = CHKgROUP.Where(x => x.LineContent.Contains("GEÇİCİ VERGİ BEYANNAMESİ")).FirstOrDefault();

            if (chhhkt == null)
            {
                eRRLOGManager.Save_AppLogs(new ERRLOG
                {
                    CompanyID = CompID,
                    CsvID = nYear,
                    ERLOG = "Hatalı PDF Yükleme  GEÇİCİ VERGİ BEYANNAMESİ  Olmalı"
                });
                return GenericResult<MoodUploadCreateResponse>.Fail("Hatalı PDF Yükleme  GEÇİCİ VERGİ BEYANNAMESİ  Olmalı");

            }



            ReadPdfPg chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yılı")).FirstOrDefault();
            ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
            string vergino = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault().LineContent;
            string txt1Yil = CHKgROUP.Where(x => x.CounterNo == 7).FirstOrDefault().LineContent;
            Domain.Entities.Company mainComp = companiesManager.Get_Company(CompID);
            if (vergino.Trim() != mainComp.TaxId.Trim())
            {
                eRRLOGManager.Save_AppLogs(new ERRLOG
                {
                    CompanyID = CompID,
                    CsvID = nYear,
                    ERLOG = "Hatalı Vergi No"
                });
                return GenericResult<MoodUploadCreateResponse>.Fail("Hatalı Vergi No");
            }

            if (Convert.ToInt32(txt1Yil) != nYear)
            {
                eRRLOGManager.Save_AppLogs(new ERRLOG
                {
                    CompanyID = CompID,
                    CsvID = nYear,
                    ERLOG = "Hatalı Yıl"
                });
                return GenericResult<MoodUploadCreateResponse>.Fail("Hatalı Yıl");
            }



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
                    if (!DigitExtensions.IsNumeric(checkval))
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

                if ((CHKgROUP[i].LineContent != null && CHKgROUP[i].LineContent.Contains("GELİR TABLOSU") && (CHKgROUP[i].LineContent.Trim().Length > 23) == false))
                {

                    chekSource1 = true;
                }

                if (CHKgROUP[i].LineContent.Contains("Dönem Net Karı veya Zararı"))
                {
                    CHKgROUP[i].MainID = "Z";
                    CHKgROUP[i].SubID = "D";
                    CHKgROUP[i].IsRevenue = 1;
                    nliste.Add(CHKgROUP[i]);
                    chekSource1 = false;
                }


                if (chekSource1)
                {
                    checkval = CHKgROUP[i].LineContent.Length > 1 ? CHKgROUP[i].LineContent.Replace(". ", string.Empty).Substring(0, 1) : string.Empty;
                    if (!DigitExtensions.IsNumeric(checkval))
                    {
                        checkval1 = checkval;
                    }
                    CHKgROUP[i].MainID = "Z";
                    CHKgROUP[i].SubID = checkval1;
                    CHKgROUP[i].IsRevenue = 1;
                    nliste.Add(CHKgROUP[i]);
                }
                if (CHKgROUP[i].LineContent.Contains("KAR DAĞITIM TABLOSU"))
                {

                    break;
                }
            }


            BeyannameChkGecici btnchk = new BeyannameChkGecici();
            beyannameChkGeciciManager.Delete(-1 * CompID, nYear);
            foreach (var item in nliste)
            {
                btnchk = new BeyannameChkGecici
                {
                    AccountMainDescriptionChk = item.LineContent,
                    CompanyID = -1 * CompID,
                    IsRevenue = item.IsRevenue,
                    SubID = item.SubID,
                    MainID = item.MainID,
                    Year = nYear
                };
                btnchk.ID = beyannameChkGeciciManager.Save_Beyanname(btnchk);
                Thread.Sleep(50);
            }
            beyannameChkGeciciManager.DeleteLast(-1 * CompID, nYear);
            var chkkGrplst = beyannameChkGeciciManager.Get_BeyannameResultLst(-1 * CompID, nYear);

            foreach (var item in chkkGrplst)
            {
                beyannameChkGeciciManager.LastSet(item.ID);
            }
            beyannameChkGeciciManager.LastFinished(-1 * CompID, nYear, nMonth);

            var nbeyanname = beyannameChkGeciciManager.Get_BeyannameResultMulti(-1 * CompID, nYear);



            Tblxml ncs = new Tblxml();
            ncs.CompanyId = CompID;
            ncs.CreatedDate = DateTime.Now;
            ncs.DocumentDate = docDate;
            ncs.Year = nYear;
            ncs.CsvName = pathToXmlFile;
            ncs.Id = tBLXmlManager.Save_TBLXml(ncs);

            var ttest = DatazHelper.SetValueFromBeyanname(nbeyanname, ncs.Id, docDate);
            ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

            datazRepository.BulkInsert(new Domain.Common.BulkUploadToSqlOptions()
            {
                InternalStore = ttest,
                TableName = "[TBLXMLSource]",
                CommitBatchSize = 50000,
            }, cancellationToken);


            List<DashBilancoView> nRequestListRvn = dashGelirTablosuViewMainManager.getList(nYear, comp.Id);
            var tlistRvn = dataManager.SetBilancoFromList(nRequestListRvn, comp.Id, nYear);
            dataManager.RESET_REVENUEView(nYear, comp.Id);
            var WCapitalViez = dashWCapitalViewMainManager.getList(nYear, comp.Id);
            var WCapitalVie = dataManager.SetBilancoFromList(WCapitalViez, comp.Id, nYear);
            var nLiqudity = dashLikiditeViewMainManager.getList(nYear, comp.Id);
            var WLiqudity = dataManager.SetBilancoFromList(nLiqudity, comp.Id, nYear);
            dataManager.InsertLiquidity(WLiqudity);
            dataManager.InsertWCapital(WCapitalVie);
            dataManager.InsertRvn(tlistRvn);
            dashRasyoManager.GetDashRasyoAnalizBeyanname(nYear, comp.Id);
            dashRasyoManager.GetDashLikiditeRiskTrend(nYear, comp.Id);
            dashRasyoManager.GetDashOzetMali(nYear, comp.Id, Convert.ToInt32(filemonth));

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
            return GenericResult<MoodUploadCreateResponse>.Fail(ex.ToString());


        }
        return GenericResult<MoodUploadCreateResponse>.Success(new MoodUploadCreateResponse { ResponseText = new JsonResult("ok") });
    }


}