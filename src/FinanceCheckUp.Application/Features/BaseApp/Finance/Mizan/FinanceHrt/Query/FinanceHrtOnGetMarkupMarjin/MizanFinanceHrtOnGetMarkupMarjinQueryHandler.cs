using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGetMarkupMarjin;
public class MizanFinanceHrtOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinanceHrtOnGetMarkupMarjinQuery, GenericResult<MizanFinanceHrtOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanFinanceHrtOnGetMarkupMarjinResponse>> Handle(MizanFinanceHrtOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    { 
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.Request.compid).Where(x => x.IsHidden == 0);
                return Task.FromResult(GenericResult<MizanFinanceHrtOnGetMarkupMarjinResponse>.Success(
            new MizanFinanceHrtOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(chk, request.Request.options)
            }));
    }
}
