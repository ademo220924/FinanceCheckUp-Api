using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpload;

public class MoodUploadCommandHandler: IRequestHandler<MoodUploadCommand, GenericResult<MoodUploadResponse>>
{
    public Task<GenericResult<MoodUploadResponse>> Handle(MoodUploadCommand request, CancellationToken cancellationToken)
    {
        var file = pageIndex.file;
        string orjinalname = file[0].FileName;
        string filemonth = pageIndex.Caption.Split('_')[0];
        string fileyear = pageIndex.Caption.Split('_')[1];
        string filePath = string.Empty;
        string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        List<string> nlistZipurl = new List<string>();
        Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
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
            return Json("nok");
        }

        string pathToXmlFile = string.Empty;
        if (IsZip)
        {

            foreach (var item in file)
            {
                filePath = Path.Combine(uploads, Guid.NewGuid().ToString() + ".zip");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream).ConfigureAwait(false);
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
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                nlistZipurl.Add(filePath);
            }

            pathToXmlFile = filePath;

        }

        int UserID = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));



        try
        {
            string retval = string.Empty;
            if (TBLXml.GetComapnyIDByMonthCount(comp.ID, Convert.ToInt32(filemonth), Convert.ToInt32(fileyear)) > 0)
            {
                retval = XmlChecker.XmlCheck(IsZip, 1, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname);
            }
            else
            {
                retval = XmlChecker.XmlCheck(IsZip, 0, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname);

            }

            if (retval != "nok")
            {

                int fyear = Convert.ToInt32(fileyear);



                List<DashBilancoView> nRequestList = DashBilancoViewMain.getList(fyear, comp.ID);
                var tlist = Data.SetBilancoFromList(nRequestList, comp.ID, fyear);
                Data.RESET_DashBilancoView(fyear, comp.ID);
                Data.InsertBilnco(tlist);
                List<DashBilancoView> nRequestListRvn = DashGelirTablosuViewMain.getList(fyear, comp.ID);
                Data.RESET_REVENUEView(fyear, comp.ID);
                var tlistRvn = Data.SetBilancoFromList(nRequestListRvn, comp.ID, fyear);
                var WCapitalViez = DashWCapitalViewMain.getList(fyear, comp.ID);
                var WCapitalVie = Data.SetBilancoFromList(WCapitalViez, comp.ID, fyear);
                var nLiqudity = DashLikiditeViewMain.getList(fyear, comp.ID);
                var WLiqudity = Data.SetBilancoFromList(nLiqudity, comp.ID, fyear);
                Data.InsertLiquidity(WLiqudity);
                Data.InsertWCapital(WCapitalVie);
                Data.InsertRvn(tlistRvn);
                DashRasyo.GetDashRasyoAnaliz(fyear, comp.ID);
                DashRasyo.GetDashLikiditeRiskTrend(fyear, comp.ID);
                DashRasyo.GetDashOzetMali(fyear, comp.ID, Convert.ToInt32(filemonth));
                MainDash.Get_DatabyErrorV1(fyear, comp.ID, Convert.ToInt32(filemonth));


            }

            return Json(retval);
        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = comp.ID;
            lg.CsvID = 7777;
            lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
            var chk = ex;
            return Json("nok");

        }
    }
}
