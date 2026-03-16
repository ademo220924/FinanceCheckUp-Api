using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtHor;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGetMarkupMarjinB;
public class FinanceFinanceHrtHorOnGetMarkupMarjinBQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtHorOnGetMarkupMarjinBQuery, GenericResult<FinanceFinanceHrtHorOnGetMarkupMarjinBResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtHorOnGetMarkupMarjinBResponse>> Handle(FinanceFinanceHrtHorOnGetMarkupMarjinBQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTB(request.InitialModel.CompID).Where(x => x.IsHidden == 0);

        return Task.FromResult(GenericResult<FinanceFinanceHrtHorOnGetMarkupMarjinBResponse>.Success(new FinanceFinanceHrtHorOnGetMarkupMarjinBResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(chk, request.Request.options))
        }));

    }
}
