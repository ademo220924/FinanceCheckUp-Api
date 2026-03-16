using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateKonsolMizan;

public class MoodUpdateKonsolMizanCommandHandler: IRequestHandler<MoodUpdateKonsolMizanCommand, GenericResult<MoodUpdateKonsolMizanResponse>>
{
    public Task<GenericResult<MoodUpdateKonsolMizanResponse>> Handle(MoodUpdateKonsolMizanCommand request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {

            return Json("nok");
        }

        try
        {
            ReportSetMain.Set_ReportSetKonM(pageIndex.year, pageIndex.companyid);
            // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

        }
        catch (Exception ex)
        {

            return Json("nok_" + ex.ToString());
        }



        return Json("ok");
    }
}
