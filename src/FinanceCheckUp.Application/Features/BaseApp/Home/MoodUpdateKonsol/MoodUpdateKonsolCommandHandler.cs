using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateKonsol;

public class MoodUpdateKonsolCommandHandler: IRequestHandler<MoodUpdateKonsolCommand, GenericResult<MoodUpdateKonsolResponse>>
{
    public Task<GenericResult<MoodUpdateKonsolResponse>> Handle(MoodUpdateKonsolCommand request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {

            return Json("nok");
        }

        try
        {
            ReportSetMain.Set_ReportSetKon(pageIndex.year, pageIndex.companyid);
            // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

        }
        catch (Exception ex)
        {

            return Json("nok_" + ex.ToString());
        }



        return Json("ok");
    }
}
