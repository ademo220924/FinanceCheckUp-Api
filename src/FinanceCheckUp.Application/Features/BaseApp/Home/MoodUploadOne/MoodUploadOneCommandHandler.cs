using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOne;

public class MoodUploadOneCommandHandler: IRequestHandler<MoodUploadOneCommand, GenericResult<MoodUploadOneResponse>>
{
    public Task<GenericResult<MoodUploadOneResponse>> Handle(MoodUploadOneCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var file = pageIndex.file;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];
            string filePath = string.Empty;
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            List<string> nlistZipurl = new List<string>();
            Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
            string orjinalname = file[0].FileName;
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
            }


            pathToXmlFile = uploads;


            int UserID = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));


            string retval = XmlChecker.SapEntegratorSet(IsZip, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname);


            return Json(retval);
        }
        catch (Exception ex)
        {
            try
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = Convert.ToInt32(pageIndex.ide);
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
            }
            catch (Exception)
            {

                ERRLOG lg = new ERRLOG();
                lg.CompanyID = 0;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
            }

            return Json("nok");
    }
}
