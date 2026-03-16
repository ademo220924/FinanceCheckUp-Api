using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOneUpdate;

public class MoodUploadOneUpdateCommandHandler: IRequestHandler<MoodUploadOneUpdateCommand, GenericResult<MoodUploadOneUpdateResponse>>
{
    public Task<GenericResult<MoodUploadOneUpdateResponse>> Handle(MoodUploadOneUpdateCommand request, CancellationToken cancellationToken)
    {
         try
        {
            var file = pageIndex.file;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];
            string orjinalname = file[0].FileName;
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

            string retval = XmlChecker.SapEntegratorSetUpdate(IsZip, comp.ID, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname);


            return Json(retval);
        }
        catch (Exception ex)
        {

            try
            {
                Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = comp.ID;
                lg.CsvID = 7777;
                lg.ERLOG = ex.ToString(); lg.Save_AppLogs();
                var chk = ex;
                return Json("nok");
            }
            catch (Exception)
            {

                ERRLOG lgt = new ERRLOG();
                lgt.CompanyID = 0;
                lgt.CsvID = 7777;
                lgt.ERLOG = ex.ToString(); lgt.Save_AppLogs();
                return Json("nok");
            }


        }

    }
}
