using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOne;

public class MoodUploadOneCommandHandler(
    ICompanyManager companyManager,
    IXmlCheckerManager xmlCheckerManager,
    IERRLOGManager errlogManager)
    : IRequestHandler<MoodUploadOneCommand, GenericResult<MoodUploadOneResponse>>
{
    public async Task<GenericResult<MoodUploadOneResponse>> Handle(MoodUploadOneCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUploadOneRequest.PageIndex;
        try
        {
            var file = pageIndex.file;
            string filemonth = pageIndex.Caption.Split('_')[0];
            string fileyear = pageIndex.Caption.Split('_')[1];
            string filePath = string.Empty;
            string uploads = Path.Combine(WebHelper.path, "wwwroot\\FileContent\\");
            List<string> nlistZipurl = new List<string>();
            var comp = companyManager.Get_Company(Convert.ToInt32(pageIndex.ide));
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
                return GenericResult<MoodUploadOneResponse>.Success(
                    new MoodUploadOneResponse { ResultText = new JsonResult("nok") });
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

            string retval = xmlCheckerManager.SapEntegratorSet(IsZip, comp.Id, pathToXmlFile, filemonth, fileyear, nlistZipurl, orjinalname);

            return GenericResult<MoodUploadOneResponse>.Success(
                new MoodUploadOneResponse { ResultText = new JsonResult(retval) });
        }
        catch (Exception ex)
        {
            try
            {
                var comp = companyManager.Get_Company(Convert.ToInt32(pageIndex.ide));
                errlogManager.Save_AppLogs(new ERRLOG
                {
                    CompanyID = comp.Id,
                    CsvID = 7777,
                    ERLOG = ex.ToString()
                });
            }
            catch (Exception)
            {
                errlogManager.Save_AppLogs(new ERRLOG
                {
                    CompanyID = 0,
                    CsvID = 7777,
                    ERLOG = ex.ToString()
                });
            }

            return GenericResult<MoodUploadOneResponse>.Success(
                new MoodUploadOneResponse { ResultText = new JsonResult("nok") });
        }
    }
}
