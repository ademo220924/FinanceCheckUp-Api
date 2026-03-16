using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGetMarkupMarjinB;
public class MizanFinanceHrtOnGetMarkupMarjinBQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinanceHrtOnGetMarkupMarjinBQuery, GenericResult<MizanFinanceHrtOnGetMarkupMarjinBResponse>>
{
    public Task<GenericResult<MizanFinanceHrtOnGetMarkupMarjinBResponse>> Handle(MizanFinanceHrtOnGetMarkupMarjinBQuery request, CancellationToken cancellationToken)
    {
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTBMI(request.Request.compid)
            .Where(x => x.IsHidden == 0)
            .OrderBy(x => x.CounterZone);
        
        return Task.FromResult(GenericResult<MizanFinanceHrtOnGetMarkupMarjinBResponse>.Success(
            new MizanFinanceHrtOnGetMarkupMarjinBResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(chk, request.Request.options))
            }));
    }
}
