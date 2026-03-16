using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGetMarkupMarjinA;
public class MizanFinanceHrtOnGetMarkupMarjinAQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinanceHrtOnGetMarkupMarjinAQuery, GenericResult<MizanFinanceHrtOnGetMarkupMarjinAResponse>>
{ 
    public Task<GenericResult<MizanFinanceHrtOnGetMarkupMarjinAResponse>> Handle(MizanFinanceHrtOnGetMarkupMarjinAQuery request, CancellationToken cancellationToken)
    {
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTAMI(request.Request.compid)
                                                .Where(x => x.IsHidden == 0)
                                                .OrderBy(x => x.CounterZone);
        
        return Task.FromResult(GenericResult<MizanFinanceHrtOnGetMarkupMarjinAResponse>.Success(
            new MizanFinanceHrtOnGetMarkupMarjinAResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(chk, request.Request.options))
            }));
    }
}

