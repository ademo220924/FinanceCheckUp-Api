using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinancesHrtfibapr.Query.FinancesHrtfibaprOnGetMarkupMarjin;
public class MizanFinancesHrtfibaprOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinancesHrtfibaprOnGetMarkupMarjinQuery, GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinResponse>> Handle(MizanFinancesHrtfibaprOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.Request.compid).Where(x => x.IsHidden == 0);
                return Task.FromResult(GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinResponse>.Success(
            new MizanFinancesHrtfibaprOnGetMarkupMarjinResponse
            { 
                Response = DataSourceLoader.Load(chk, request.Request.options)
            }));
    }
}
