using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtNeo.Query.FinanceHrtNeoOnGetMarkupMarjin;
public class MizanFinanceHrtNeoOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinanceHrtNeoOnGetMarkupMarjinQuery, GenericResult<FinanceHrtNeoOnGetMarkupMarjinResponse>>
{ 
    public Task<GenericResult<FinanceHrtNeoOnGetMarkupMarjinResponse>> Handle(MizanFinanceHrtNeoOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.Request.compid).Where(x => x.IsHidden == 0);
        
                return Task.FromResult(GenericResult<FinanceHrtNeoOnGetMarkupMarjinResponse>.Success(
            new FinanceHrtNeoOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(chk, request.Request.options)
            }));
    }
}
