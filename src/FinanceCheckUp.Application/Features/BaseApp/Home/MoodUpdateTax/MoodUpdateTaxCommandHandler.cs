using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateTax;

public class MoodUpdateTaxCommandHandler(IMainDashManager mainDashManager, IErrorCheckMainManager errorCheckMainManager)
    : IRequestHandler<MoodUpdateTaxCommand, GenericResult<MoodUpdateTaxResponse>>
{
    public Task<GenericResult<MoodUpdateTaxResponse>> Handle(MoodUpdateTaxCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUpdateTaxRequest.PageIndex;
        try
        {
            int csvId = mainDashManager.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);
            errorCheckMainManager.Set_ReportSet(csvId);
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MoodUpdateTaxResponse>.Success(
                new MoodUpdateTaxResponse { ResultText = new JsonResult("nok_" + ex.ToString()) }));
        }

        return Task.FromResult(GenericResult<MoodUpdateTaxResponse>.Success(
            new MoodUpdateTaxResponse { ResultText = new JsonResult("ok") }));
    }
}
