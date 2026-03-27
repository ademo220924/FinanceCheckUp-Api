using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetSalerYear;
public class FinanceUpBalanceOnGetSalerYearQueryHandler : IRequestHandler<FinanceUpBalanceOnGetSalerYearQuery, GenericResult<FinanceUpBalanceOnGetSalerYearResponse>>
{
    public Task<GenericResult<FinanceUpBalanceOnGetSalerYearResponse>> Handle(FinanceUpBalanceOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
                return Task.FromResult(GenericResult<FinanceUpBalanceOnGetSalerYearResponse>.Success(new FinanceUpBalanceOnGetSalerYearResponse
        {
            Response = DataSourceLoader.Load(yearSetMonth, request.Request.options)
        }));

    }
}
