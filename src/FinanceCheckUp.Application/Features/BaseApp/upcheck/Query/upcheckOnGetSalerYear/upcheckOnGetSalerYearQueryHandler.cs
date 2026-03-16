using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upcheck;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetSalerYear;
public class upcheckOnGetSalerYearQueryHandler : IRequestHandler<upcheckOnGetSalerYearQuery, GenericResult<upcheckOnGetSalerYearResponse>>
{

    public async Task<GenericResult<upcheckOnGetSalerYearResponse>> Handle(upcheckOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
        return GenericResult<upcheckOnGetSalerYearResponse>.Success(new upcheckOnGetSalerYearResponse { Result = new JsonResult(DataSourceLoader.Load(YearSetm, request.Request.Options)) });
    }
}