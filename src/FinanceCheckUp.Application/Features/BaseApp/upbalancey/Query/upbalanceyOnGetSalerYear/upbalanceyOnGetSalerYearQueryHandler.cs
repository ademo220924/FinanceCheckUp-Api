using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGetSalerYear;
public class upbalanceyOnGetSalerYearQueryHandler : IRequestHandler<upbalanceyOnGetSalerYearQuery, GenericResult<upbalanceyOnGetSalerYearResponse>>
{

    public async Task<GenericResult<upbalanceyOnGetSalerYearResponse>> Handle(upbalanceyOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
        return GenericResult<upbalanceyOnGetSalerYearResponse>.Success(new upbalanceyOnGetSalerYearResponse { Result = new JsonResult(DataSourceLoader.Load(YearSetm, request.Request.Options)) });
    }
}