using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadUpdate;

public class MoodUploadUpdateCommandHandle(
    ICompanyManager companiesManager,
    IFileOperationService fileOperationService,
    IERRLOGManager eRRLOGManager
    ) : IRequestHandler<MoodUploadUpdateCommand, GenericResult<MoodUploadUpdateResponse>>
{


    public async Task<GenericResult<MoodUploadUpdateResponse>> Handle(MoodUploadUpdateCommand request, CancellationToken cancellationToken)
    {
        var file = request.XMlook.file;
        string filemonth = request.XMlook.Caption.Split('_')[0];
        string fileyear = request.XMlook.Caption.Split('_')[1];
        string filePath = string.Empty;
        string uploads = Path.Combine(AppConst.EnvironmentValue, AppConst.FileUploadPath);

        Domain.Entities.Company comp = companiesManager.Get_Company(Convert.ToInt32(request.XMlook.ide));

        if (file != null && file.Count > 0)
        { }
        else
        {
            return GenericResult<MoodUploadUpdateResponse>.Success(new MoodUploadUpdateResponse { ResponseText = new JsonResult("nok") });
        }

        string pathToXmlFile = string.Empty;
        foreach (var item in file)
        {
            filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await item.CopyToAsync(fileStream).ConfigureAwait(false);
            }
        }

        pathToXmlFile = filePath;
        long CompID = Convert.ToInt64(request.XMlook.ide);
        int nYear = request.XMlook.id;

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
                return GenericResult<MoodUploadUpdateResponse>.Fail("Hatalı PDF Yükleme  GEÇİCİ VERGİ BEYANNAMESİ  Olmalı");

            }

            ReadPdfPg chhhk1 = CHKgROUP.Where(x => x.LineContent.Contains("Yıl ")).FirstOrDefault();
            ReadPdfPg chhhk1eposta = CHKgROUP.Where(x => x.LineContent.Contains("E-Posta Adresi")).FirstOrDefault();
            string vergino = CHKgROUP.Where(x => x.CounterNo == chhhk1eposta.CounterNo + 1).FirstOrDefault().LineContent;
            string txt1Yil = chhhk1.LineContent.Split(' ')[1].Trim();
            Domain.Entities.Company mainComp = companiesManager.Get_Company(CompID);

            if (Convert.ToInt32(txt1Yil) != nYear)
            {
                eRRLOGManager.Save_AppLogs(new ERRLOG
                {
                    CompanyID = CompID,
                    CsvID = nYear,
                    ERLOG = "Hatalı Yıl"
                });
                return GenericResult<MoodUploadUpdateResponse>.Fail("Hatalı Yıl");
            }
        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG
            {
                CompanyID = comp.Id,
                CsvID = 7777,
                ERLOG = ex.ToString()
            };
            lg.ID = eRRLOGManager.Save_AppLogs(lg);
            var chk = ex;
            return GenericResult<MoodUploadUpdateResponse>.Fail("nok");
        }

        return GenericResult<MoodUploadUpdateResponse>.Success(new MoodUploadUpdateResponse { ResponseText = new JsonResult("ok") });
    }
}