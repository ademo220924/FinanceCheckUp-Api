using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOneGoOn;

public class MoodUploadOneGoOnCommandHandler: IRequestHandler<MoodUploadOneGoOnCommand, GenericResult<MoodUploadOneGoOnResponse>>
{
    public Task<GenericResult<MoodUploadOneGoOnResponse>> Handle(MoodUploadOneGoOnCommand request, CancellationToken cancellationToken)
    {
        var file = pageIndex.file;
        string filemonth = pageIndex.Caption.Split('_')[0];
        string fileyear = pageIndex.Caption.Split('_')[1];

        List<string> nlistZipurl = new List<string>();
        Companies comp = Companies.Get_Company(Convert.ToInt32(pageIndex.ide));

        int UserID = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        try
        {
            string retval = XmlChecker.SapEntegratorSetUpon(comp.ID, filemonth, fileyear, Convert.ToInt32(pageIndex.idexml));


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
