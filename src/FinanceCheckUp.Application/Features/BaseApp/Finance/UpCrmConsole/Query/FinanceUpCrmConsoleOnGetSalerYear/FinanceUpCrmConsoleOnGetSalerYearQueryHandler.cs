using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.UpCrmConsole;
using FinanceCheckUp.Application.Models.Responses.Finance.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpCrmConsole.Query.FinanceUpCrmConsoleOnGetSalerYear;
public class FinanceUpCrmConsoleOnGetSalerYearQueryHandler 
    : IRequestHandler<FinanceUpCrmConsoleOnGetSalerYearQuery, GenericResult<FinanceUpCrmConsoleOnGetSalerYearResponse>>
{
    public Task<GenericResult<FinanceUpCrmConsoleOnGetSalerYearResponse>> Handle(FinanceUpCrmConsoleOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
                return Task.FromResult(GenericResult<FinanceUpCrmConsoleOnGetSalerYearResponse>.Success(new FinanceUpCrmConsoleOnGetSalerYearResponse
        {
            Response = DataSourceLoader.Load(yearSetMonth, request.Request.options)
        }));
    }
}
