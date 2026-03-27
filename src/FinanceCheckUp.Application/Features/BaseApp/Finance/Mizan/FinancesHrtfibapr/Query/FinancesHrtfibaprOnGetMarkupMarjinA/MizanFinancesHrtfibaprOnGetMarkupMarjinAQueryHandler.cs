using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinancesHrtfibapr.Query.FinancesHrtfibaprOnGetMarkupMarjinA;
public class MizanFinancesHrtfibaprOnGetMarkupMarjinAQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinancesHrtfibaprOnGetMarkupMarjinAQuery, GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinAResponse>>
{
    public Task<GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinAResponse>> Handle(MizanFinancesHrtfibaprOnGetMarkupMarjinAQuery request, CancellationToken cancellationToken)
    {
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTAMIFIBAPR(request.Request.compid).Where(x => x.IsHidden == 0).OrderBy(x => x.CounterZone);
        
                return Task.FromResult(GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinAResponse>.Success(
            new MizanFinancesHrtfibaprOnGetMarkupMarjinAResponse
            { 
                Response = DataSourceLoader.Load(chk, request.Request.options)
            }));
    }
}
