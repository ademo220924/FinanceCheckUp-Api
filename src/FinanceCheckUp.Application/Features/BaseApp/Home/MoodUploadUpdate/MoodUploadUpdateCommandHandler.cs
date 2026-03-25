using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadUpdate;

public class MoodUploadUpdateCommandHandler(
    ICompanyManager companyManager,
    IXmlCheckerManager xmlCheckerManager,
    IDataManager dataManager,
    IDashGelirTablosuViewMainManager dashGelirTablosuViewMainManager,
    IDashWCapitalViewMainManager dashWCapitalViewMainManager,
    IDashLikiditeViewMainManager dashLikiditeViewMainManager,
    IDashRasyoManager dashRasyoManager,
    IMainDashManager mainDashManager,
    IERRLOGManager errlogManager)
    : IRequestHandler<MoodUploadUpdateCommand, GenericResult<MoodUploadUpdateResponse>>
{
    public async Task<GenericResult<MoodUploadUpdateResponse>> Handle(MoodUploadUpdateCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUploadUpdateRequest.PageIndex;
        var file = pageIndex.file;
        string orjinalname = file[0].FileName;
        string filemonth = pageIndex.Caption.Split('_')[0];
        string fileyear = pageIndex.Caption.Split('_')[1];
        string filePath = string.Empty;
        string uploads = Path.Combine(WebHelper.path, "wwwroot\\FileContent\\");
        List<string> nlistZipurl = new List<string>();
        var comp = companyManager.Get_Company(Convert.ToInt32(pageIndex.ide));
        bool IsZip = false;
        if (file != null && file.Count > 0)
        {
            string ext = System.IO.Path.GetExtension(file[0].FileName);
            if (ext.ToLower().Contains("zip"))
            {
                IsZip = true;
            }
        }
        else
        {
            return GenericResult<MoodUploadUpdateResponse>.Success(
                new MoodUploadUpdateResponse { ResultText = new JsonResult("nok") });
        }

        string pathToXmlFile = string.Empty;
        if (IsZip)
        {
            foreach (var item in file)
            {
                filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".zip");
                await using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
                }

                nlistZipurl.Add(filePath);
            }

            pathToXmlFile = uploads;
        }
        else
        {
            foreach (var item in file)
            {
                filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".xml");
                await using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
                }

                nlistZipurl.Add(filePath);
            }

            pathToXmlFile = filePath;
        }

        try
        {
            string retval = xmlCheckerManager.XmlCheck(IsZip, 1, comp.Id, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname, filemonth == "12");
            if (retval != "nok")
            {
                int fyear = Convert.ToInt32(fileyear);

                List<DashBilancoView> nRequestList = dashGelirTablosuViewMainManager.getList(fyear, comp.Id);
                var tlist = dataManager.SetBilancoFromList(nRequestList, comp.Id, fyear);
                dataManager.RESET_DashBilancoView(fyear, comp.Id);
                dataManager.InsertBilnco(tlist);
                List<DashBilancoView> nRequestListRvn = dashGelirTablosuViewMainManager.getList(fyear, comp.Id);
                var tlistRvn = dataManager.SetBilancoFromList(nRequestListRvn, comp.Id, fyear);
                dataManager.RESET_REVENUEView(fyear, comp.Id);
                var WCapitalViez = dashWCapitalViewMainManager.getList(fyear, comp.Id);
                var WCapitalVie = dataManager.SetBilancoFromList(WCapitalViez, comp.Id, fyear);
                var nLiqudity = dashLikiditeViewMainManager.getList(fyear, comp.Id);
                var WLiqudity = dataManager.SetBilancoFromList(nLiqudity, comp.Id, fyear);
                dataManager.InsertLiquidity(WLiqudity);
                dataManager.InsertWCapital(WCapitalVie);
                dataManager.InsertRvn(tlistRvn);
                dashRasyoManager.GetDashRasyoAnaliz(fyear, comp.Id);
                dashRasyoManager.GetDashLikiditeRiskTrend(fyear, comp.Id);
                dashRasyoManager.GetDashOzetMali(fyear, comp.Id, Convert.ToInt32(filemonth));
                mainDashManager.Get_DatabyErrorV1(fyear, comp.Id, Convert.ToInt32(filemonth));
            }

            return GenericResult<MoodUploadUpdateResponse>.Success(
                new MoodUploadUpdateResponse { ResultText = new JsonResult(retval) });
        }
        catch (Exception ex)
        {
            errlogManager.Save_AppLogs(new ERRLOG
            {
                CompanyID = comp.Id,
                CsvID = 7777,
                ERLOG = ex.ToString()
            });
            return GenericResult<MoodUploadUpdateResponse>.Success(
                new MoodUploadUpdateResponse { ResultText = new JsonResult("nok") });
        }
    }
}
