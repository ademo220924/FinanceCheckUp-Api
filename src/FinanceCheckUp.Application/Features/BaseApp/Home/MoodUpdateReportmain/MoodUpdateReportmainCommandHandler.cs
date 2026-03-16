using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateReportmain;

public class MoodUpdateReportmainCommandHandler: IRequestHandler<MoodUpdateReportmainCommand, GenericResult<MoodUpdateReportmainResponse>>
{
    public Task<GenericResult<MoodUpdateReportmainResponse>> Handle(MoodUpdateReportmainCommand request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {

            return Json("nok");
        }

        try
        {
            ReportSetMain.Set_ReportSetMain(pageIndex.year, pageIndex.companyid);
            // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

        }
        catch (Exception ex)
        {

            return Json("nok_" + ex.ToString());
        }



        return Json("ok");
    }
}
