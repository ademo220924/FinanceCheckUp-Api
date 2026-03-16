using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upreportmainy;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upreportmainy.Query.upreportmainyOnGetSalerYear;
public class UpreportmainyOnGetSalerYearQueryHandler : IRequestHandler<upreportmainyOnGetSalerYearQuery, GenericResult<upreportmainyOnGetSalerYearResponse>>
{

    public async Task<GenericResult<upreportmainyOnGetSalerYearResponse>> Handle(upreportmainyOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
        return GenericResult<upreportmainyOnGetSalerYearResponse>.Success(new upreportmainyOnGetSalerYearResponse { Result = new JsonResult(DataSourceLoader.Load(YearSetm, request.Request.Options)) });
    }
}