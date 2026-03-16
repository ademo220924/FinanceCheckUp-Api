using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateTax;

public class MoodUpdateTaxCommandHandler: IRequestHandler<MoodUpdateTaxCommand, GenericResult<MoodUpdateTaxResponse>>
{
    public Task<GenericResult<MoodUpdateTaxResponse>> Handle(MoodUpdateTaxCommand request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {

            return Json("nok");
        }

        try
        {
            int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);
            ErrorCheckMain.Set_ReportSet(csvId);
        }
        catch (Exception ex)
        {

            return Json("nok_" + ex.ToString());
        }



        return Json("ok");
    }
}
