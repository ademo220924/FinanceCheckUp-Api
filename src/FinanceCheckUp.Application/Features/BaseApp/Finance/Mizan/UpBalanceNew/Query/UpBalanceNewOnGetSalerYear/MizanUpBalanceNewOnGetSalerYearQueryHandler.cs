using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetSalerYear;
public class MizanUpBalanceNewOnGetSalerYearQueryHandler : IRequestHandler<MizanUpBalanceNewOnGetSalerYearQuery, GenericResult<MizanUpBalanceNewOnGetSalerYearResponse>>
{
    public Task<GenericResult<MizanUpBalanceNewOnGetSalerYearResponse>> Handle(MizanUpBalanceNewOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
                return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetSalerYearResponse>.Success(new MizanUpBalanceNewOnGetSalerYearResponse
        {
            Response = DataSourceLoader.Load(yearSetMonth, request.Request.options)
        }));
    }
}
