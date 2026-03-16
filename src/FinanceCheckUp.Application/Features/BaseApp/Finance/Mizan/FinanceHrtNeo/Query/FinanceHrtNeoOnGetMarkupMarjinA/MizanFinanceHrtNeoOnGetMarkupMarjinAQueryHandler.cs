using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtNeo.Query.FinanceHrtNeoOnGetMarkupMarjinA;
public class MizanFinanceHrtNeoOnGetMarkupMarjinAQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinanceHrtNeoOnGetMarkupMarjinAQuery, GenericResult<MizanFinanceHrtNeoOnGetMarkupMarjinAResponse>>
{
    public Task<GenericResult<MizanFinanceHrtNeoOnGetMarkupMarjinAResponse>> Handle(MizanFinanceHrtNeoOnGetMarkupMarjinAQuery request, CancellationToken cancellationToken)
    { 
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTA(request.Request.compid)
            .Where(x => x.IsHidden == 0)
            .OrderBy(x => x.CounterZone);
        
        return Task.FromResult(GenericResult<MizanFinanceHrtNeoOnGetMarkupMarjinAResponse>.Success(
            new MizanFinanceHrtNeoOnGetMarkupMarjinAResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(chk, request.Request.options))
            }));
    }
}
