using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtNeo.Query.FinanceHrtNeoOnGetMarkupMarjinB;
public class MizanFinanceHrtNeoOnGetMarkupMarjinBQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinanceHrtNeoOnGetMarkupMarjinBQuery, GenericResult<MizanFinanceHrtNeoOnGetMarkupMarjinBResponse>>
{
    public Task<GenericResult<MizanFinanceHrtNeoOnGetMarkupMarjinBResponse>> Handle(MizanFinanceHrtNeoOnGetMarkupMarjinBQuery request, CancellationToken cancellationToken)
    {
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTB(request.Request.compid)
            .Where(x => x.IsHidden == 0)
            .OrderBy(x => x.CounterZone);
        
                return Task.FromResult(GenericResult<MizanFinanceHrtNeoOnGetMarkupMarjinBResponse>.Success(
            new MizanFinanceHrtNeoOnGetMarkupMarjinBResponse
            {
                Response = DataSourceLoader.Load(chk, request.Request.options)
            }));
    }
}
