using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtFiba;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtFiba.Query.FinanceHrtFibaOnGetMarkupMarjinA;
public class MizanFinanceHrtFibaOnGetMarkupMarjinAQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinanceHrtFibaOnGetMarkupMarjinAQuery, GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinAResponse>>
{
    public Task<GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinAResponse>> Handle(MizanFinanceHrtFibaOnGetMarkupMarjinAQuery request, CancellationToken cancellationToken)
    { 
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTAMIFIBA(request.Request.compid).Where(x => x.IsHidden == 0);
        return Task.FromResult(GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinAResponse>.Success(
            new MizanFinanceHrtFibaOnGetMarkupMarjinAResponse
            {
                Response =  new JsonResult(DataSourceLoader.Load(chk, request.Request.options))
            }));
    }
}
