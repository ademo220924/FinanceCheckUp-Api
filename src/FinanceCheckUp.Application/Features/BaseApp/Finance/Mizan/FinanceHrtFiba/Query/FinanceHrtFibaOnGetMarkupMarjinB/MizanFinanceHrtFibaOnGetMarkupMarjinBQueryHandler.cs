using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtFiba;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtFiba.Query.FinanceHrtFibaOnGetMarkupMarjinB;
public class MizanFinanceHrtFibaOnGetMarkupMarjinBQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinanceHrtFibaOnGetMarkupMarjinBQuery, GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinBResponse>>
{ 
    public Task<GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinBResponse>> Handle(MizanFinanceHrtFibaOnGetMarkupMarjinBQuery request, CancellationToken cancellationToken)
    { 
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTBMIFIBA(request.Request.compid).Where(x => x.IsHidden == 0).OrderBy(x => x.CounterZone);
                return Task.FromResult(GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinBResponse>.Success(
            new MizanFinanceHrtFibaOnGetMarkupMarjinBResponse
            {
                Response =  DataSourceLoader.Load(chk, request.Request.options)
            }));
    }
}