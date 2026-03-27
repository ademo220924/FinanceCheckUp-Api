using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalance.Query.UpBalanceOnGetSalerYear
{
    public class MizanUpBalanceOnGetSalerYearQueryHandler : IRequestHandler<MizanUpBalanceOnGetSalerYearQuery, GenericResult<MizanUpBalanceOnGetSalerYearResponse>>
    {
        public Task<GenericResult<MizanUpBalanceOnGetSalerYearResponse>> Handle(MizanUpBalanceOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
                        return Task.FromResult(GenericResult<MizanUpBalanceOnGetSalerYearResponse>.Success(new MizanUpBalanceOnGetSalerYearResponse
            {
                Response = DataSourceLoader.Load(yearSetm, request.Request.options)
            }));
 
        }
    }
}