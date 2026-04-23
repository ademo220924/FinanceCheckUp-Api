using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpCrmConsole.Query.UpCrmConsoleOnGetSalerYear
{
    public class MizanUpCrmConsoleOnGetSalerYearQueryHandler : IRequestHandler<MizanUpCrmConsoleOnGetSalerYearQuery, GenericResult<MizanUpCrmConsoleOnGetSalerYearResponse>>
    {
        public Task<GenericResult<MizanUpCrmConsoleOnGetSalerYearResponse>> Handle(MizanUpCrmConsoleOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
           
            return Task.FromResult(GenericResult<MizanUpCrmConsoleOnGetSalerYearResponse>.Success(new MizanUpCrmConsoleOnGetSalerYearResponse
            {
                Response = DataSourceLoader.Load(yearSetMonth, request.Request.options)
            }));

        }
    }
}
