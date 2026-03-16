using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnbtest.Query.upreportqnbtestOnGetSalerYear;
public class UpreportqnbtestOnGetSalerYearQueryHandler : IRequestHandler<upreportqnbtestOnGetSalerYearQuery, GenericResult<upreportqnbtestOnGetSalerYearResponse>>
{

    public async Task<GenericResult<upreportqnbtestOnGetSalerYearResponse>> Handle(upreportqnbtestOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
        return GenericResult<upreportqnbtestOnGetSalerYearResponse>.Success(new upreportqnbtestOnGetSalerYearResponse { Result = new JsonResult(DataSourceLoader.Load(YearSetm, request.Request.Options)) });
    }
}