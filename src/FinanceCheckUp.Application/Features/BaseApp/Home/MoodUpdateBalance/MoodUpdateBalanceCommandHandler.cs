using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateBalance;

public class MoodUpdateBalanceCommandHandler: IRequestHandler<MoodUpdateBalanceCommand, GenericResult<MoodUpdateBalanceResponse>>
{
    public Task<GenericResult<MoodUpdateBalanceResponse>> Handle(MoodUpdateBalanceCommand request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {

            return Json("nok");
        }

        try
        {
            ReportSetMain.Set_ReportSet(pageIndex.year, pageIndex.companyid);
            // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

        }
        catch (Exception ex)
        {

            return Json("nok_" + ex.ToString());
        }



        return Json("ok");
    }
}
