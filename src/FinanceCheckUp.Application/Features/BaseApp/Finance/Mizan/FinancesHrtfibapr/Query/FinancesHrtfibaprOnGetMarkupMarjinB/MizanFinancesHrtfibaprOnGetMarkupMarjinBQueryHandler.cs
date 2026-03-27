using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinancesHrtfibapr.Query.FinancesHrtfibaprOnGetMarkupMarjinB;
public class MizanFinancesHrtfibaprOnGetMarkupMarjinBQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinancesHrtfibaprOnGetMarkupMarjinBQuery, GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinBResponse>>
{
 

    public Task<GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinBResponse>> Handle(MizanFinancesHrtfibaprOnGetMarkupMarjinBQuery request, CancellationToken cancellationToken)
    {
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTBMIFIBAPR(request.Request.compid).Where(x => x.IsHidden == 0).OrderBy(x => x.CounterZone);
       
                return Task.FromResult(GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinBResponse>.Success(
            new MizanFinancesHrtfibaprOnGetMarkupMarjinBResponse
            { 
                Response = DataSourceLoader.Load(chk, request.Request.options)
            }));
    }
}
