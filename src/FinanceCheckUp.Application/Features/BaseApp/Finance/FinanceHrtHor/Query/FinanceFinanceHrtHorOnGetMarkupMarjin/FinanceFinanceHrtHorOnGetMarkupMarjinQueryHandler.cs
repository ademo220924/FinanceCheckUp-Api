using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtHor;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGetMarkupMarjin;
public class FinanceFinanceHrtHorOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtHorOnGetMarkupMarjinQuery, GenericResult<FinanceFinanceHrtHorOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtHorOnGetMarkupMarjinResponse>> Handle(FinanceFinanceHrtHorOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.InitialModel.CompID).Where(x => x.IsHidden == 0);

        return Task.FromResult(GenericResult<FinanceFinanceHrtHorOnGetMarkupMarjinResponse>.Success(new FinanceFinanceHrtHorOnGetMarkupMarjinResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(chk, request.Request.options))
        }));

    }
}
