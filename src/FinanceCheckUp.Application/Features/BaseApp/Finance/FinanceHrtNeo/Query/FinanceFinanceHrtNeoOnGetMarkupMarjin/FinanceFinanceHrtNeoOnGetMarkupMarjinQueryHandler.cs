using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtNeo.Query.FinanceFinanceHrtNeoOnGetMarkupMarjin;
public class FinanceFinanceHrtNeoOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtNeoOnGetMarkupMarjinQuery, GenericResult<FinanceFinanceHrtNeoOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtNeoOnGetMarkupMarjinResponse>> Handle(FinanceFinanceHrtNeoOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.InitialModel.CompID).Where(x => x.IsHidden == 0);

        return Task.FromResult(GenericResult<FinanceFinanceHrtNeoOnGetMarkupMarjinResponse>.Success(new FinanceFinanceHrtNeoOnGetMarkupMarjinResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(chk, request.Request.options))
        }));

    }
}
