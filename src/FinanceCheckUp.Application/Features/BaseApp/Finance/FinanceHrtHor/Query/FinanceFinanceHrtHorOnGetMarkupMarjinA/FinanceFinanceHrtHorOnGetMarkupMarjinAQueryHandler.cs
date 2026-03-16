using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtHor;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGetMarkupMarjinA;
public class FinanceFinanceHrtHorOnGetMarkupMarjinAQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtHorOnGetMarkupMarjinAQuery, GenericResult<FinanceFinanceHrtHorOnGetMarkupMarjinAResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtHorOnGetMarkupMarjinAResponse>> Handle(FinanceFinanceHrtHorOnGetMarkupMarjinAQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTA(request.InitialModel.CompID).Where(x => x.IsHidden == 0).OrderBy(x => x.CounterZone);

        return Task.FromResult(GenericResult<FinanceFinanceHrtHorOnGetMarkupMarjinAResponse>.Success(new FinanceFinanceHrtHorOnGetMarkupMarjinAResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(chk, request.Request.options))
        }));

    }
}
